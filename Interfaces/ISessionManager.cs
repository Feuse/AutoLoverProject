using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ISessionManager
    {

        public string GetSession(Service service);
        public void SetSession(Service servicem, CookieModel cookie);
        public string GetUserId(Service service);
        public void SetUserId(Service service, CookieModel cookie);
    }
}
