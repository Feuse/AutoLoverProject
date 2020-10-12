﻿using Interfaces;
using Microsoft.AspNetCore.Http;
using Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotsImpl
{
    public class GrinderBot : IBot
    {
        public Task ChangeAboutMe(string sessionId, string input)
        {
            throw new NotImplementedException();
        }

        public Task ChangeDescription(string sessionId, string proffesion, string companyName, string school)
        {
            throw new NotImplementedException();
        }

        public Task ChangeDescription(string proffesion, string companyName, string school, string sessionId, int sessionCount)
        {
            throw new NotImplementedException();
        }

        public Task ChangeDescriptions(string description, Service services)
        {
            throw new NotImplementedException();
        }

        public Task ChangeAboutMeOnAllServices(string description, Service services, string sessionId)
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

        public Task<int> ExecuteLikes(int likes, IModel channel, EventingBasicConsumer consumer)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteLikes(MessageWithoutUser likes, int counter)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteLikes(MessageWithoutUser likes)
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

        public Task<string> GetLast(string projList, string sessionId)
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




        Task IBot.InitializeBot(ServiceCredentialsModel user, MessageWithoutUser message)
        {
            throw new NotImplementedException();
        }


        Task<LocalProjectionModel> IBot.LoginWithApi(string username, string password, string sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponseModel> GetUser(string sessionId)
        {
            throw new NotImplementedException();
        }

        public Task UploadImage(string sessionId, IFormFile photo)
        {
            throw new NotImplementedException();
        }

        public Task RemoveImage(string sessionId, string imgId)
        {
            throw new NotImplementedException();
        }

        public Task<GetSearchSettingResponseModel> GetUserSettings(string sessionId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserSearchSettings(long ageStart, long ageEnd, long distance, long[] genders, string sessionId)
        {
            throw new NotImplementedException();
        }

        public Task UploadImage(string sessionId, List<string> images)
        {
            throw new NotImplementedException();
        }

        public Task UploadImage(string sessionId, List<InstagramPartialModel> images)
        {
            throw new NotImplementedException();
        }


        public Task AuthenticateBadooInstagram(string sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<AppStartupModelResponseModel> StartupBot(string sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UploadImage(string sessionId, List<InstagramPartialModel> images, string url)
        {
            throw new NotImplementedException();
        }

        Task<string> IBot.UploadImage(string sessionId, List<InstagramPartialModel> images, string url)
        {
            throw new NotImplementedException();
        }
    }
}