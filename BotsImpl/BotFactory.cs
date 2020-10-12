using Interfaces;
using Microsoft.Extensions.Logging;
using Models;
using System;

namespace BotsImpl
{
    public class BotFactory : IBotFactory
    {
        private ICredentialDb Db;
        private IJsonFactory Factory;
        private IMailer Mailer;
        private ILogger<BadooBot> Logger;
        public BotFactory(ICredentialDb db, IJsonFactory factory, IMailer mailer, ILogger<BadooBot> logger)
        {
            Db = db;
            Factory = factory;
            Mailer = mailer;
            Logger = logger;
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
                    return new BadooBot(Db, Factory, Mailer, Logger);
                case Service.Tinder:
                    return new TinderBot(Db, Factory);
                default:
                    break;
            }
            throw new Exception("Service error");
        }
    }
}
