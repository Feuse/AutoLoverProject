using Interfaces;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQListener.AppWrapper
{
    public class Application : IApplication
    {
        IListenerQueue _queue;
        ISche _sche;

        public Application(IListenerQueue queue, IScheduler sche, ISche cleanup)
        {
            _queue = queue;
            _sche = cleanup;
        }

        public void Run()
        {
            //_sche.DailyCleanUp(DateTime.Now);
            _queue.StartListening();
        }
    }
}
