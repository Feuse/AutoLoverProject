using Interfaces;
using Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace BotsImpl
{
    public class BadooBot : IBot
    {
        private int _likesLeft;
        private static IWebDriver _driver;
        private Random random;
        private const string URL = "https://badoo.com/signin/";
        private string _username;
        private string _password;
        public BadooBot()
        {
            _driver = new ChromeDriver(new ChromeOptions() { PageLoadStrategy = PageLoadStrategy.Normal });
        }
        public void ChangeDescription()
        {
            //change description
        }

        public int ExecuteLikes(int mssageId, string userId, int likes, Service service, DateTime time)
        {
            _likesLeft = likes;

            try
            {
                var url = Login(_username, _password);
                Like(likes, url);
            }
            catch (Exception)
            {
                return _likesLeft;
            }

            return _likesLeft;
        }

        public void Like(int likes, string url)
        {
            var rand = random.Next(5, 10);
           

            while (_likesLeft > 0)
            {
                TimeSpan ts = TimeSpan.FromSeconds(rand);
                _driver.Manage().Timeouts().ImplicitWait = ts;


                _driver.FindElement(By.ClassName("js-profile-header-vote-yes")).Click();
                try
                {
                    var but = _driver.FindElement(By.ClassName("js-chrome-pushes-deny"));
                    but.Click();
                }
                catch (Exception)
                {

                    
                }
                _likesLeft--;
            }
            ShutDown();
        }

        public string Login(string username, string password)
        {
            random = new Random();
            try
            {
                _driver.Navigate().GoToUrl(URL);
                _driver.FindElement(By.ClassName("js-signin-login")).Clear();
                _driver.FindElement(By.ClassName("js-signin-login")).SendKeys("Feuse135@gmail.com");
                _driver.FindElement(By.ClassName("js-signin-password")).SendKeys("121233054Ro");
                _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                if (_driver.Url == "https://badoo.com/promo/spp")
                {
                    _driver.FindElement(By.ClassName("js-spp-close")).Click();
                }else if(_driver.Url == URL)
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return URL;
            }

            _username = username;
            _password = password;

            return _driver.Url;
        }

        public void ShutDown()
        {
            _driver.Dispose();
            _driver.Close();

        }
    }
}
