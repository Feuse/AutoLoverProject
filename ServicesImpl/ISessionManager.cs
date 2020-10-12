using Models;
using OpenQA.Selenium;

namespace ServicesImpl
{
    public interface ISessionManager
    {
        public string GetUserId(Service service);
        public void SetUserId(Service service, CookieModel cookie);

        public void SetCookieSession(Service service, CookieModel cookie);

        public string GetCookieSession(Service service);

        /// <summary>
        /// Gets the external website session id.
        /// </summary>
        /// <param name="service">the service that is currently running</param>
        /// <param name="driver">selenium web driver instance</param>
        /// <returns></returns>
        public string GetExternalWebsiteSession(Service service, IWebDriver driver);
        public string GetServiceSessionName(Service service);
        public string GetServiceUserIdName(Service service);
        public void SetSession(string key, string value);
        public string GetSession(string key);
        public void ClearSession();
        public void SetChangedDescriptionCount(string count, Service service);
        public string GetChangedDescriptionCount(Service service);
        public InstagramUserModel GetInstagramModel();
        public void SaveInstagramModel(InstagramUserModel model);
    }

}