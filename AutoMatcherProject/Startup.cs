using System.Collections.Specialized;
using BotsImpl;
using DbServices;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("AutoLoverDbConnection"),x => x.MigrationsAssembly("AutoMatcherProjectAss")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<ISche, SchedulerImpl>();
            services.AddTransient<IQueue, QueueImpl>();
            services.AddTransient<SchedulerJob>();
            services.AddTransient<IBotFactory,BotFactory>();
            services.AddTransient<ICredentialSaver, CredentialSaver>();
            services.AddSingleton(provider => _scheduler);
            services.AddAuthentication().AddFacebook(options => {
                options.AppId = "2975433209152858";
                options.AppSecret = "61a40260163846bab0672bbf5bf6c8a8";
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
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
