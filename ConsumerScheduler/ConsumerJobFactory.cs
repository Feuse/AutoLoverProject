using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Autofac;

namespace ConsumerScheduler
{
    public class ConsumerJobFactory : IJobFactory
    {
        private IScheduler _scheduler;
        private readonly IContainer _container;
        public ConsumerJobFactory(IContainer container)
        {
            _container = container;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {

            // var service =  _container.ResolveOptional<ConsumerSchechulerJob>();

            return (IJob)_container.Resolve(bundle.JobDetail.JobType);
        }

        public void ReturnJob(IJob job) { }
    }
}
