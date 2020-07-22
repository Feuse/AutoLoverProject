
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotsImpl
{
    public class TinderBot : IBot
    {
        public TinderBot()
        {
        }

        public Task ChangeDescription(string sessionId, string proffesion, string companyName, string school)
        {
            throw new NotImplementedException();
        }

        public Task ChangeDescriptions(string description, Service services, string sessionId)
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

        public int ExecuteLikes(int _mssageId, string _userId, int _likes, DateTime _time, string sessionId)
        {
            throw new NotImplementedException();
        }

        public int ExecuteLikes(int _mssageId, string _userId, int _likes, DateTime _time, string sessionId, List<string> projections)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteLikes(int likes)
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

        public Task<ProjectionModel> GetLast(ProjectionModel projList, string sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<LocalProjectionModel> GetLast(LocalProjectionModel projList, string sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<ServicePropertiesModel> InitializeBot(UsersCredentialsModel user, MessageWithoutUser message)
        {
            throw new NotImplementedException();
        }

        public void Like(int likes, string url)
        {
            throw new NotImplementedException();
        }

        public CookieModel Login(string username, string password, string userId)
        {
            return null;
        }

        public Task<List<long>> LoginWithApi(string username, string password, string sessionId)
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

        Task IBot.ChangeDescription(string proffesion, string companyName, string school, string sessionId)
        {
            throw new NotImplementedException();
        }


        Task<int> IBot.ExecuteLikes(int likes)
        {
            throw new NotImplementedException();
        }

        Task<List<string>> IBot.GetCities(string input, string sessionId)
        {
            throw new NotImplementedException();
        }

        Task IBot.GetCountryId(string input, string sessionId)
        {
            throw new NotImplementedException();
        }

        Task<List<PictureUrlModel>> IBot.GetImages(string sessionId, string userId)
        {
            throw new NotImplementedException();
        }

        Task<LocalProjectionModel> IBot.GetLast(LocalProjectionModel projList, string sessionId)
        {
            throw new NotImplementedException();
        }

        Task IBot.InitializeBot(UsersCredentialsModel user, MessageWithoutUser message)
        {
            throw new NotImplementedException();
        }

       
        CookieModel IBot.Login(string username, string password, string userId)
        {
            throw new NotImplementedException();
        }

    

        Task<LocalProjectionModel> IBot.LoginWithApi(string username, string password, string sessionId)
        {
            throw new NotImplementedException();
        }

        Task IBot.SaveLocation(string location, string sessionId)
        {
            throw new NotImplementedException();
        }

        void IBot.ShutDown()
        {
            throw new NotImplementedException();
        }
    }
}
