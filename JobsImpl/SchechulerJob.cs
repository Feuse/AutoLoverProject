using Interfaces;
using Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobsImpl
{
    public class SchedulerJob : IJob
    {
        private IQueue _queue;
        public SchedulerJob(IQueue queue)
        {
            _queue = queue;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Yield();
            JobDataMap jobMap = context.JobDetail.JobDataMap;
            MessageWithoutUser message = (MessageWithoutUser)jobMap.Get("message");

            _queue.Queue(message);
        }

    }
}
