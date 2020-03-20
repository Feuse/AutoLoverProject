using Autofac;
using Autofac.Extras.Quartz;
using BotsImpl;
using ConsumerScheduler;
using Interfaces;
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
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<RabbitMQImpl>().As<IListenerQueue>().SingleInstance();
            builder.RegisterType<BotFactory>().As<IBotFactory>();
            var instance = QuartzInstance.Instance;
            builder.RegisterType<QueueImpl>().AsImplementedInterfaces();
            builder.RegisterType<ConsumerSchechuler>().AsImplementedInterfaces();
            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(ConsumerSchedulerJob).Assembly)).RegisterAssemblyModules();
            builder.RegisterInstance(QuartzInstance.Instance).AsImplementedInterfaces();
            return builder.Build();

        }
    }
}
