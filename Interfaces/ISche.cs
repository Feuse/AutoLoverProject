
using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISche
    {
        public Task Schedule(string userId, DateTime time, int likes, Service service, IdentityUser user);
        public Task StartSchedule(string userId, int likes, DateTime time, Service service);
        public Task DailyCleanUp(DateTime time);
    }
}