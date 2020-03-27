
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace JobsImpl
{
    public class DailyCleanUpJob : IJob
    {
        private readonly AppDbContext _context;
        public DailyCleanUpJob(AppDbContext context)
        {
            _context = context;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            DateTime time = new DateTime(1993, 12, 03, 11, 12, 22);
            await Task.Yield();
            _context.CookieModel.RemoveRange(_context.CookieModel.Where(x => x.Expiry > time));
            _context.SaveChanges();
        }
    }
}
