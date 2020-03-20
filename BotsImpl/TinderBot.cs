
using Interfaces;
using Models;
using System;

namespace BotsImpl
{
    public class TinderBot : IBot
    {
        public void ChangeDescription()
        {
            throw new NotImplementedException();
        }

        public int ExecuteLikes(int MessageId, string UserId, int Likes, Service Service, DateTime Time)
        {
            return 0;
        }

        public void Like(int likes, string url)
        {
            throw new NotImplementedException();
        }

        public string Login()
        {
            throw new NotImplementedException();
        }

        public string Login(string username, string password)
        {
            throw new NotImplementedException();
        }
        public void ShutDown()
        {
            //_driver.Dispose();
            //_driver.Close();
        }
    }
}
