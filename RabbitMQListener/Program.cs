using Autofac;
using ConsumerScheduler;
using Quartz;
using RabbitMQListener.AppWrapper;
using RabbitMQListener.Installer;
using System;

namespace RabbitMQListener
{
    class Program
    {
        static void Main(string[] args)
        {

            var container = InstallerClass.Startup();
            using (var scope = container.BeginLifetimeScope())
            {

                var app = scope.Resolve<IApplication>();
                var _scheduler = container.Resolve<IScheduler>();
                _scheduler.JobFactory = new ConsumerJobFactory(container);
                app.Run();

            }
        }
    }
}
