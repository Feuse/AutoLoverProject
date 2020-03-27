using Interfaces;
using JobsImpl;
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

        public async Task Schedule(string userId,DateTime time, int likes, Service service, IdentityUser user)
        {
            if (time == DateTime.MinValue)
            {
                time = DateTime.UtcNow;
            }
            
            await StartSchedule(userId, likes, time, service);

        }

        public async Task StartSchedule(string userId, int likes, DateTime time, Service service)
        {
            if (time == DateTime.MinValue)
            {
                time = DateTime.UtcNow;
            }
            _uniqueId = Guid.NewGuid().ToString();
            IJobDetail job = JobBuilder.Create<SchedulerJob>().WithIdentity(_uniqueId, "bots").Build();
            job.JobDataMap.Put("message", new MessageWithoutUser {UserId = userId, Likes = likes, Time = time, Service = service });
            ITrigger trigger = TriggerBuilder.Create().WithIdentity(_uniqueId, "bots")
                                                      .StartNow()
                                                      .Build();
            await _scheduler.ScheduleJob(job, trigger);
        }

        public async Task DailyCleanUp(DateTime time)
        {
            _uniqueId = Guid.NewGuid().ToString();
            IJobDetail job = JobBuilder.Create<DailyCleanUpJob>().WithIdentity(_uniqueId, "clean").Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(_uniqueId, "clean").StartNow()
                                                      .Build();
            //.WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(21, 05))
            //.ForJob(job.Key)
            //.Build();

            await _scheduler.ScheduleJob(job, trigger);
        }
    }
}
