using System;
using System.Collections.Specialized;
using BotsImpl;
using DbServices;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Quartz;
using Quartz.Impl;
using ServicesImpl;
using Utils;

namespace AutoMatcherProject
{
    public class Startup
    {
        private IScheduler _scheduler { get; }
        private const string APP_ID = "2975433209152858";
        private const string APP_SECRET = "61a40260163846bab0672bbf5bf6c8a8";
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
            // _scheduler = QuartzInstance.Instance;
            _scheduler = QuartzInstance.Instance;
        }

        public IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.User.AllowedUserNameCharacters = null).AddEntityFrameworkStores<AppDbContext>();
            services.AddControllersWithViews();
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("AutoLoverDbConnection"), x => x.MigrationsAssembly("AutoMatcherProjectAss")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<ISessionManager, ClientSIdeSessionManager>();
            services.AddHttpContextAccessor();
            services.AddSession();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);//You can set Time   
                options.Cookie.HttpOnly = true;
            });
            services.AddTransient<ISche, SchedulerImpl>();
            services.AddTransient<IQueue, QueueImpl>();
            services.AddTransient<SchedulerJob>();
            services.AddTransient<IBotFactory, BotFactory>();
            services.AddTransient<ICredentialDb, CredentialDb>();
            services.AddSingleton(provider => _scheduler);
            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = APP_ID;
                options.AppSecret = APP_SECRET;
                options.SaveTokens = true;
               
            });
            _scheduler.Clear();
        }

        private void OnShutDown()
        {
            if (_scheduler.IsShutdown) _scheduler.Shutdown();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            _scheduler.JobFactory = new AspnetCoreJobFactory(app.ApplicationServices);
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Users}/{action=Dashboard}/{id?}");
            });
        }

        public static IScheduler Scheduler()
        {
            NameValueCollection props = new NameValueCollection
            {
                {"quartz.scheduler.instanceName","QuartzWithCore" },
                {"quartz.scheduler.instanceId","QuartzWithCore" },
                {"quartz.jobStore.type","Quartz.Impl.AdoJobStore.JobStoreTX, Quartz" },
                {"quartz.jobStore.dataSource","default" },
                {"quartz.jobStore.tablePrefix","QRTZ_" },
                {"quartz.dataSource.default.connectionString","server=(localdb)\\MSSQLLocalDB; database = databasename; Trusted_Connection = true" },
                {"quartz.dataSource.default.provider","SqlServer" },
              //  {"quartz.threadPool.threadCount","1" },
                {"quartz.serializer.type","json" }
            };

            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            var sched = factory.GetScheduler().Result;
            sched.Start().Wait();
            return sched;
        }

    }
}
