using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICredentialSaver
    {
        public void Save(UsersCredentialsModel model);
        public UsersCredentialsModel Get(string username, string password,Service service);
        public bool CheckHash(string id);
        public UsersCredentialsModel GetById(string id);
        public void SaveSessionId(CookieModel cookie);
        public CookieModel GetCookie(string userId, Service service);
    }
}
