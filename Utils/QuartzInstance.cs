using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Utils
{
    public class QuartzInstance
    {
        private static IScheduler instace = null;
        private static readonly object padlock = new object();
        public static IScheduler Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instace == null)
                    {
                        StdSchedulerFactory sche = new StdSchedulerFactory(SetPropeties());
                        instace = sche.GetScheduler().GetAwaiter().GetResult();
                        instace.Start();
                    }
                }
                return instace;
            }
        }

        public static NameValueCollection SetPropeties()
        {
            return new NameValueCollection
            {
                {"quartz.scheduler.instanceName","QuartzConsumer" },
                {"quartz.scheduler.instanceId","QuartzConsumer" },
                {"quartz.jobStore.type","Quartz.Impl.AdoJobStore.JobStoreTX, Quartz" },
                {"quartz.jobStore.dataSource","default" },
                {"quartz.jobStore.tablePrefix","QRTZ_" },
                {"quartz.dataSource.default.connectionString","server=(localdb)\\MSSQLLocalDB; database = databasename; Trusted_Connection = true" },
                {"quartz.dataSource.default.provider","SqlServer" },
                {"quartz.serializer.type","json" }
            };
        }
    }
}
