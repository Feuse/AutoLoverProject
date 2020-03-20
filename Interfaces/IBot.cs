
using Models;
using System;

namespace Interfaces
{
    public interface IBot
    {
        public void ChangeDescription();
        public int ExecuteLikes(int _mssageId, string _userId, int _likes, Service _service, DateTime _time);
        public string Login(string username, string password);
        public void Like(int likes, string url);
        public void ShutDown();
    }
}
