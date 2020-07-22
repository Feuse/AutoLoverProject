
using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISche
    {
        public Task Schedule(int userId, DateTime time, int likes, Service service, IdentityUser user);
        public Task StartSchedule(int messageId, int likes, DateTime time, Service service);
    }
}