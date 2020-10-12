using Microsoft.AspNetCore.Http;
using Models;
using UtilModels;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBot
    {
        public Task<int> ExecuteLikes(MessageWithoutUser likes);
        public Task<List<PictureUrlModel>> GetImages(string sessionId, string userId);
        public Task<LocalProjectionModel> LoginWithApi(string username, string password, string? sessionId);
        public CookieModel Login(string username, string password, string userId="");
        public Task<List<string>> GetCities(string input, string sessionId);
        public Task GetCountryId(string input, string sessionId);
        public Task SaveLocation(string location, string sessionId);
        public Task ChangeDescription(string proffesion, string companyName, string school, string sessionId);
        public Task<LocalProjectionModel> GetLast(LocalProjectionModel projList, string sessionId);
        public Task InitializeBot(ServiceCredentialsModel user, MessageWithoutUser message);
        public void ShutDown();
        public Task ChangeAboutMe(string sessionId, string input);
        public Task<LoginResponseModel> GetUser(string sessionId);
        Task<string> UploadImage(string sessionId, List<InstagramPartialModel> images,string url);
        Task RemoveImage(string sessionId, string imgId);
        Task<GetSearchSettingResponseModel> GetUserSettings(string sessionId);
        Task UpdateUserSearchSettings(long ageStart, long ageEnd, long distance, long[] genders, string sessionId);
        public Task AuthenticateBadooInstagram(string sessionId);
        public Task<AppStartupModelResponseModel> StartupBot(string sessionId);
    }
}
