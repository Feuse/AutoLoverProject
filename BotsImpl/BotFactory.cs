
using Interfaces;
using Models;
using System;

namespace BotsImpl
{
    public class BotFactory : IBotFactory
     {
        private ICredentialDb _db;
        public BotFactory(ICredentialDb db)
        {
            _db = db;
        }
        public IBot GetBot(Service service)
        {
            switch (service)
            {
                case Service.OkCupid:
                    return new OkCupidBot();
                case Service.Grinder:
                    return new GrinderBot();
                case Service.Badoo:
                    return new BadooBot(_db);
                default:
                    break;
            }
            throw new Exception("Service error");
        }
    }
}
