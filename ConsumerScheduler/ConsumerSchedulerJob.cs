using Interfaces;
using Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerScheduler
{
    public class ConsumerSchedulerJob : IJob
    {
        private IQueue _queue;
        public ConsumerSchedulerJob(IQueue queue)
        {
            _queue = queue;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            JobDataMap jobMap = context.JobDetail.JobDataMap;
            MessageWithoutUser message = (MessageWithoutUser)jobMap.Get("message");
            _queue.Queue(message);
        }
    }
}
