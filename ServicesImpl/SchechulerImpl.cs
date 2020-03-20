using Interfaces;
using Microsoft.AspNetCore.Identity;
using Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImpl
{
    public class SchedulerImpl : ISche
    {
        private IScheduler _scheduler;
        private string _uniqueId { get; set; }
        private string _userId;

        public SchedulerImpl(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }
        public string GetUser(IdentityUser user)
        {
            return user.Id;
        }

        public async Task Schedule(int messageId, DateTime time, int likes, Service service, IdentityUser user)
        {
            if (time == DateTime.MinValue)
            {
                time = DateTime.UtcNow;
            }
            _uniqueId = Guid.NewGuid().ToString();
            _userId = GetUser(user);
            await StartSchedule(messageId, likes, time, service);

        }

        public async Task StartSchedule(int messageId, int likes, DateTime time, Service service)
        {
            if (time == DateTime.MinValue)
            {
                time = DateTime.UtcNow;
            }
            _uniqueId = Guid.NewGuid().ToString();
            IJobDetail job = JobBuilder.Create<SchedulerJob>().WithIdentity(_uniqueId, "bots").Build();
            job.JobDataMap.Put("message", new MessageWithoutUser { MessageId = messageId, UserId = _userId, Likes = likes, Time = time, Service = service });
            ITrigger trigger = TriggerBuilder.Create().WithIdentity(_uniqueId, "bots")
                                                      .StartNow()
                                                      .Build();
            await _scheduler.ScheduleJob(job, trigger);
        }



    }
}
