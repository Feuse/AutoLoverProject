using System;
using System.Collections.Specialized;
using AutoMatcherProject1.Migrations;
using BotsImpl;
using DbServices;
using Factories;
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
using Microsoft.AspNetCore.Cors;
using UtilModels;
using System.Configuration;

namespace AutoMatcherProject
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private IScheduler _scheduler { get; }
        public IConfiguration _config { get; }
        public string FACEBOOK_APP_ID { get; private set; }
        public string FACEBOOK_APP_SECRET { get; private set; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
            // _scheduler = QuartzInstance.Instance;
            _scheduler = QuartzInstance.Instance;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            FACEBOOK_APP_ID = _config.GetValue<string>("FACEBOOK_APP_ID");
            FACEBOOK_APP_SECRET = _config.GetValue<string>("FACEBOOK_APP_SECRET");
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 49000;
            });
            services.AddHttpClient();
            services.AddCors();
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.User.AllowedUserNameCharacters = null).AddEntityFrameworkStores<AppDbContext>();
            services.AddControllersWithViews();
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("AutoLoverDbConnection"), x => x.MigrationsAssembly("AutoMatcherProjectAss")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddTransient<AppDbContext>();
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
            services.Configure<StmpSettings>(_config.GetSection("StmpSettings"));
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
            services.AddTransient<IJsonFactory, JsonFactory>();
            services.AddTransient<ICredentialDb, CredentialDb>();
            services.AddSingleton(provider => _scheduler);
            services.AddSingleton<IMailer, Mailer>();
            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = FACEBOOK_APP_ID;
                options.AppSecret = FACEBOOK_APP_SECRET;
                options.SaveTokens = true;
            });

            //}).AddInstagram(options =>
            //{
            //    //options.AuthorizationEndpoint = "https://www.instagram.com/oauth/authorize?client_id=346912513373650&redirect_uri=https://localhost:44300/Actions/Test/&scope=user_profile,user_media&response_type=code";
            //    options.ClientId = "346912513373650";
            //    //options.Scope.Add("user_profile,user_media");
            //    options.ClientSecret = "7455bf4a5f09c4c9ef289eb292f9f522";
            //});
            _scheduler.Clear();
            services.AddMvc(options => options.EnableEndpointRouting = false);

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
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseCors(builder =>
    builder.WithOrigins("https://instagram.com"));
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
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
