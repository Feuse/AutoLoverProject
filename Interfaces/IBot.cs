
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBot
    {
        public Task<int> ExecuteLikes(int likes);
        public Task<List<PictureUrlModel>> GetImages(string sessionId, string userId);
        public Task<LocalProjectionModel> LoginWithApi(string username, string password, string? sessionId);
        public CookieModel Login(string username, string password, string userId="");
        public Task<List<string>> GetCities(string input, string sessionId);
        public Task GetCountryId(string input, string sessionId);
        public Task SaveLocation(string location, string sessionId);
        public Task ChangeDescription(string proffesion, string companyName, string school, string sessionId);
        public void ShutDown();
        public Task<LocalProjectionModel> GetLast(LocalProjectionModel projList, string sessionId);
        public Task InitializeBot(UsersCredentialsModel user, MessageWithoutUser message);
        public Task ChangeDescriptions(string description, Service services,string sessionId);
    }
}
