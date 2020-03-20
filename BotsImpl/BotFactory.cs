
using Interfaces;
using Models;
using System;

namespace BotsImpl
{
    public class BotFactory : IBotFactory
     {
        public IBot GetBot(Service service)
        {
            switch (service)
            {
                case Service.OkCupid:
                    return new OkCupidBot();
                case Service.Grinder:
                    return new GrinderBot();
                case Service.Badoo:
                    return new BadooBot();
                default:
                    break;
            }
            throw new Exception("Service error");
        }
    }
}
