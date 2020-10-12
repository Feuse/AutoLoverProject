using Autofac;
using Autofac.Extras.Quartz;
using BotsImpl;
using ConsumerScheduler;
using DbServices;
using Factories;
using Interfaces;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Models;
using NLog;
using QueuesImpl;
using RabbitMQListener.AppWrapper;
using ServicesImpl;
using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace RabbitMQListener.Installer
{
    public class InstallerClass
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static IContainer Startup()
        {
            var builder = new ContainerBuilder();
            var contextOptions = new DbContextOptionsBuilder<AppDbContext>();
            contextOptions.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=databasename;Trusted_Connection=true");
            builder.RegisterInstance(contextOptions.Options).As<DbContextOptions<AppDbContext>>();
            builder.RegisterType<CredentialDb>().As<ICredentialDb>();
            builder.RegisterType<IdentityDbContext>();
            builder.RegisterType<AppDbContext>();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<RabbitMQImpl>().As<IListenerQueue>().SingleInstance();
            builder.RegisterType<BotFactory>().As<IBotFactory>();
            builder.RegisterType<JsonFactory>().As<IJsonFactory>();
            var instance = QuartzInstance.Instance;
            builder.RegisterType<QueueImpl>().AsImplementedInterfaces();
            builder.RegisterType<ConsumerSchechuler>().AsImplementedInterfaces();
            builder.RegisterType<SchedulerImpl>().AsImplementedInterfaces();
            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(ConsumerSchedulerJob).Assembly)).RegisterAssemblyModules();
            //builder.RegisterModule(new QuartzAutofacJobsModule(typeof(DailyCleanUpJob).Assembly)).RegisterAssemblyModules();
            builder.RegisterInstance(QuartzInstance.Instance).AsImplementedInterfaces();
            return builder.Build();

        }
    }
}
