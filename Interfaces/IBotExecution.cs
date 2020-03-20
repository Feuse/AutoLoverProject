using Models;
using System;

namespace Interfaces
{
    public interface IBotExecution
    {
        public int Execute(int mssageId, string userId, int likes, Service service, DateTime time);
        public string Login(string username, string password );
        public void Like(int likes, string url);
    }
}
