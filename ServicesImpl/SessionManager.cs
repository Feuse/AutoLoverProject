using Interfaces;
using Microsoft.AspNetCore.Http;
using Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesImpl
{
    public class ClientSIdeSessionManager : ISessionManager
    {
        private IHttpContextAccessor _httpContextAccessor;
        public ClientSIdeSessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId(Service service)
        {
            var userString = GetServiceUserIdName(service);
            return _httpContextAccessor.HttpContext.Request.Cookies[userString];
        }

        public void SetUserId(Service service, CookieModel cookie)
        {
            var userString = GetServiceUserIdName(service);
            CookieOptions options = new CookieOptions { Expires = cookie.Expiry };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(userString, cookie.UserId, options);
        }

        public void SetSession(Service service, CookieModel cookie)
        {
            var sessionString = GetServiceSessionName(service);
            _httpContextAccessor.HttpContext.Session.SetString(sessionString, cookie.SessionId);
        }

        public string GetSession(Service service)
        {
            var sessionString = GetServiceSessionName(service);
            var ss = _httpContextAccessor.HttpContext.Session.GetString(sessionString);
            return _httpContextAccessor.HttpContext.Session.GetString(sessionString);
        }

        /// <summary>
        /// Gets the external website session id.
        /// </summary>
        /// <param name="service">the service that is currently running</param>
        /// <param name="driver">selenium web driver instance</param>
        /// <returns></returns>
        public string GetExternalWebsiteSession(Service service, IWebDriver driver)
        {
            var sessionString = GetServiceSessionName(service);
            return driver.Manage().Cookies.GetCookieNamed(sessionString).ToString();
        }
        public string GetServiceSessionName(Service service)
        {
            const string BADOO_SESSION_ID = "Badoo-Session-id";
            const string TINDER_SESSION_ID = "Tinder-Session-id";
            const string GRINDER_RSESSION_ID = "Grinder-Session-id";
            const string OKCUPID_SESSION_ID = "OkCupid-Session-id";

            switch (service)
            {
                case Service.Badoo:
                    return BADOO_SESSION_ID;
                case Service.Tinder:
                    return TINDER_SESSION_ID;
                case Service.Grinder:
                    return GRINDER_RSESSION_ID;
                case Service.OkCupid:
                    return OKCUPID_SESSION_ID;
                default:
                    break;
            }
            throw new Exception("Session Service error");
        }
        public string GetServiceUserIdName(Service service)
        {
            const string BADOO_USER_ID = "Badoo-user-id";
            const string TINDER_USER_ID = "Tinder-Session-id";
            const string GRINDER_USER_ID = "Grinder-Session-id";
            const string OKCUPID_USER_ID = "OkCupid-Session-id";

            switch (service)
            {
                case Service.Badoo:
                    return BADOO_USER_ID;
                case Service.Tinder:
                    return TINDER_USER_ID;
                case Service.Grinder:
                    return GRINDER_USER_ID;
                case Service.OkCupid:
                    return OKCUPID_USER_ID;
                default:
                    break;
            }
            throw new Exception("Session Service error");
        }
    }
}
