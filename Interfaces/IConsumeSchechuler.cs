using Models;
using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IConsumeSchechuler
    {
        public Task StartSchedule(int messageId, int likes, Service service);
    }
}
