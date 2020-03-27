
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBot
    {
        public int ExecuteLikes(int _mssageId, string _userId, int _likes, DateTime _time,string sessionId);
        public Task<List<PictureUrlModel>> GetImages(string sessionId, string userId);
        public CookieModel Login(string username, string password, string userId="");
        public void Like(int likes, string url);
        public Task<List<string>> GetCities(string input, string sessionId);
        public Task GetCountryId(string input, string sessionId);
        public Task SaveLocation(string location, string sessionId);
        public Task ChangeDescription(string proffesion, string companyName, string school, string sessionId);
        public void ShutDown();
    }
}
