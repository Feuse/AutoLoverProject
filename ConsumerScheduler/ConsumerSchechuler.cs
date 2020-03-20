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
        private string _uniqueId { get; set; }
        private string _userId = String.Empty;
        //
        public ConsumerSchechuler()
        {
            _scheduler = QuartzInstance.Instance;
        }

        public async Task StartSchedule(int messageId, int likes, DateTime time, Service service)
        {
            if (time == DateTime.MinValue)
            {
                time = DateTime.UtcNow;
            }
            _uniqueId = Guid.NewGuid().ToString();
            IJobDetail job = JobBuilder.Create<ConsumerSchedulerJob>().WithIdentity(_uniqueId, "consumer").Build();
            job.JobDataMap.Put("message", new MessageWithoutUser { MessageId = messageId, UserId = _userId, Likes = likes, Time = time, Service = service });
            ITrigger trigger = TriggerBuilder.Create().WithIdentity(_uniqueId, "consumer")
                                                      .StartNow()
                                                      .Build();
            await _scheduler.ScheduleJob(job, trigger);
        }


    }
}
