using Interfaces;
using Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace ConsumerScheduler
{
    public class ConsumerSchechuler : IConsumeSchechuler
    {
        private IScheduler _scheduler;
        private string UniqueId = String.Empty;
        private string UserId = String.Empty;
        public ConsumerSchechuler()
        {
            _scheduler = QuartzInstance.Instance;
        }

        public async Task StartSchedule(int messageId, int likes, Service service)
        {
            var time = DateTime.UtcNow;
            UniqueId = Guid.NewGuid().ToString();
            IJobDetail job = JobBuilder.Create<ConsumerSchedulerJob>().WithIdentity(UniqueId, "consumer").Build();
            job.JobDataMap.Put("message", new MessageWithoutUser { MessageId = messageId, UserId = UserId, Likes = likes, Time = time, Service = service });
            ITrigger trigger = TriggerBuilder.Create().WithIdentity(UniqueId, "consumer")
                                                      .StartNow()
                                                      .Build();
            await _scheduler.ScheduleJob(job, trigger);
        }
    }
}
