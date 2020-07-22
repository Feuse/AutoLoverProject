using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICredentialDb
    {
        public void Save(UsersCredentialsModel model);
        public UsersCredentialsModel GetUsersCredentialsModel(string username, string password);
        public bool CheckHash(string id);
        public UsersCredentialsModel GetById(string id);
        public void SaveSessionId(CookieModel cookie);
        public CookieModel GetCookie(string userId, Service service);
        public void SaveProjections(ProjectionModel parsedList);
        public ProjectionModel GetUsersModel(string userId);
        public UsersCredentialsModel GetByEmail(string email);
        public void TESTSave();
        public List<Service> GetUserServices(string userId);
        public void SaveUserServiceCredentials(string username, string password, Service service,string userId);
        public ServiceCredentialsModel GetServiceCredentialsModel(string username, string password);
        public void RemoveUsersCredentialsModel(string userId);
        public Task<ServiceCredentialsModel> GetByIdServiceCredentialsModel(string userId);
        public void RemoveServiceFromUser(string userId, Service service);
        public List<PictureUrlModel> GetBadooPictures(string userId);
        public void SaveBadooPictures(List<PictureUrlModel> model);
    }
}
