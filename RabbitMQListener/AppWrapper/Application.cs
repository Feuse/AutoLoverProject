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

        public Application(IListenerQueue queue, IScheduler sche)
        {
            _queue = queue;

        }

        public void Run()
        {
            _queue.StartListening();
        }
    }
}
