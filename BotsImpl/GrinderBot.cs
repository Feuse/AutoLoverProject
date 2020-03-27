using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotsImpl
{
    public class GrinderBot : IBot
    {
        public Task ChangeDescription(string sessionId, string proffesion, string companyName, string school)
        {
            throw new NotImplementedException();
        }

        public int ExecuteLikes(int _mssageId, string _userId, int _likes, DateTime _time)
        {
            throw new NotImplementedException();
        }

        public int ExecuteLikes(int _mssageId, string _userId, int _likes, Service _service, DateTime _time)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetCities(string sessionId, string input)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetCities(string input)
        {
            throw new NotImplementedException();
        }

        public Task GetCountryId(string sessionId, string input)
        {
            throw new NotImplementedException();
        }

        public Task<List<PictureUrlModel>> GetImages(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PictureUrlModel>> GetImages(string sessionId, string userId)
        {
            throw new NotImplementedException();
        }

        public void Like(int likes, string url)
        {
            throw new NotImplementedException();
        }

        public CookieModel Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public CookieModel Login(string username, string password, string userId)
        {
            throw new NotImplementedException();
        }

        public Task SaveLocation(string sessionId, string location)
        {
            throw new NotImplementedException();
        }

        public void ShutDown()
        {
            throw new NotImplementedException();
        }
    }
}