using Interfaces;
using Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExecutingBots
{
    public class ExecuteBadooBot : IBotExecution
    {
        private int _likesLeft;
        private static IWebDriver _driver;
        private Random random;
        private const string URL = "https://badoo.com/signin/";
        private string _username;
        private string _password;

        static ExecuteBadooBot()
        {
            _driver = new ChromeDriver(new ChromeOptions() { PageLoadStrategy = PageLoadStrategy.Normal });
        }

        public void ChangeDescription()
        {
            //change description
        }

        public int Execute(int mssageId, string userId, int likes, Service service, DateTime time)
        {
            _likesLeft = likes;

            try
            {
                var url = Login(_username, _password);
                Like(likes, url);
            }
            catch (Exception e)
            {
                return _likesLeft;
            }

            return _likesLeft;
        }

        public void Like(int likes, string url)
        {
            var rand = random.Next(1, 5);
            _driver.Navigate().GoToUrl(url);

            while (likes > 0)
            {
                Thread.Sleep(rand);
                try
                {
                _driver.FindElement(By.ClassName("js-profile-header-vote-yes"));
                    Dispose();
                    break;
                }
                catch (Exception)
                {
                    Dispose();
                    throw;
                }
                
                _likesLeft--;
            }
        }
        public static void Dispose()
        {
            _driver.Dispose();
            _driver.Close();
        }

        public string Login(string username, string password)
        {
            random = new Random();
            try
            {
                _driver.Navigate().GoToUrl(URL);
                _driver.FindElement(By.ClassName("js-signin-login")).SendKeys("Feuse135@gmail.com");
                _driver.FindElement(By.ClassName("js-signin-password")).SendKeys("121233054Ro");
                _driver.FindElement(By.ClassName("btn__loader")).Click();
            }
            catch (Exception e)
            {
                return "";
            }

            _username = username;
            _password = password;

            return _driver.Url;
        }
    }
}
