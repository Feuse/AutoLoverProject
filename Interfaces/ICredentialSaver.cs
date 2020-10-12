using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UtilModels;

namespace Interfaces
{
    public interface ICredentialDb
    {
        public void Save(UsersCredentialsModel model);
        public UsersCredentialsModel GetUsersCredentialsModel(string username, string password,Service service);
        public bool CheckHash(string id);
        public UsersCredentialsModel GetById(string id);
        public void SaveSessionId(CookieModel cookie);
        public CookieModel GetCookie(string userId, Service service);
        public void SaveProjections(ProjectionModel parsedList);
        public ProjectionModel GetUsersModel(string userId);
        public UsersCredentialsModel GetByEmail(string email);
        public List<Service> GetUserServices(string userId);
        public void SaveUserServiceCredentials(string username, string password, Service service,string userId);
        public ServiceCredentialsModel GetServiceCredentialsModel(string username, string password, Service service);
        public void RemoveUsersCredentialsModel(string userId);
        public Task<ServiceCredentialsModel> GetByIdServiceCredentialsModel(string userId);
        public void RemoveServiceFromUser(string userId, Service service);
        public List<PictureUrlModel> GetBadooPictures(string userId, Service service);
        public void SaveBadooPictures(List<PictureUrlModel> model);
        public List<Service> GetUserServicesById(string userId);
        public ServiceCredentialsModel ValidateAndGetServiceCredentials(string username, string password, Service service);
        public Task<ServiceCredentialsModel> GetByIdAndServiceServiceCredentialsModel(string userId, Service service);
        public List<InstagramMediaModel> GetInstagramMedia(string userId);
        public void SaveInstagramMedia(List<InstagramMediaModel> model);

    }
}
