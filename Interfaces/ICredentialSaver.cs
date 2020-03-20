using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICredentialSaver
    {
        public void Save(UsersCredentialsModel model);
        public UsersCredentialsModel Get(string username, string password);
        public bool CheckHash(string id);
    }
}
