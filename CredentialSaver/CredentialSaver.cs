using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using ServicesImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilModels;
using Utils;

namespace DbServices
{
    public class CredentialDb : ICredentialDb
    {
        private readonly object balanceLock = new object();
        private readonly AppDbContext _context;
        public CredentialDb(AppDbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public ProjectionModel GetUsersModel(string userId)
        {
            return _context.ProjectionModel.Where(b => b.UserId == userId).FirstOrDefault(); ;
        }
        public void SaveInstagramMedia(List<InstagramMediaModel> model)
        {
            foreach (var item in model)
            {
                _context.InstagramMediaModel.Add(item);
            }
            _context.SaveChanges();
        }

        public List<InstagramMediaModel> GetInstagramMedia(string userId)
        {
            var s = _context.InstagramMediaModel.Where(i => i.UserId == userId).ToList();
            return _context.InstagramMediaModel.Where(i => i.UserId == userId).ToList();
        }

        public List<Service> GetUserServices(string userId)
        {
            List<Service> services = new List<Service>();
            var users = _context.ServiceCredentialsModel.Where(i => i.UserId == userId).ToList();
            var t = users.Select(a => a.Service).ToList();
            return users.Select(a => a.Service).ToList();
        }

        public void Save(UsersCredentialsModel model)
        {
            var salt = PasswordHasher.Create();
            model.Password = PasswordHasher.HashPassword(model.Password, salt);
            model.Hash = salt;

            _context.UsersCredentialsModels.Add(model);
            _context.SaveChanges();
        }
        public void SaveUserServiceCredentials(string username, string password, Service service, string userId)
        {

            var salt = PasswordHasher.Create();
            ServiceCredentialsModel serviceModel = new ServiceCredentialsModel
            {
                Password = PasswordHasher.Encrypt(password, salt),
                Service = service,
                UserId = userId,
                Username = username,
                Hash = salt
            };
            _context.ServiceCredentialsModel.Add(serviceModel);
            _context.SaveChanges();
        }
        public ServiceCredentialsModel GetServiceCredentialsModel(string username, string password, Service service)
        {
            var user = _context.ServiceCredentialsModel.Where(b => b.Username == username).Where(b => b.Service == service).FirstOrDefault();

            if (user != null)
            {
                //var hashedPassword = PasswordHasher.Decrypt(password, user.Hash);
                //if (hashedPassword == user.Password) return user;
                //else return null;
                return user;
            }
            return null;
        }
        public ServiceCredentialsModel ValidateAndGetServiceCredentials(string username, string password, Service service)
        {
            var hash = _context.UsersCredentialsModels.Where(b => b.Username == username).Select(a => a.Password).FirstOrDefault();
            //var hashedPassword = PasswordHasher.Decrypt(password, hash);
            var userId = _context.UsersCredentialsModels.Where(b => b.Username == username && b.Password == hash).Select(a => a.UserId).FirstOrDefault();
            var user = _context.ServiceCredentialsModel.Where(b => b.UserId == userId).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public List<Service> GetUserServicesById(string userId)
        {
            var userServicesList = _context.ServiceCredentialsModel.Where(b => b.UserId == userId).Select(a => a.Service).ToList();

            return userServicesList;

        }
        public async Task<ServiceCredentialsModel> GetByIdAndServiceServiceCredentialsModel(string userId, Service service)
        {
            var user = await _context.ServiceCredentialsModel.Where(b => b.UserId == userId && b.Service == service)
                     .FirstOrDefaultAsync();
            if (user != null)
            {
                var decrypted = PasswordHasher.Decrypt(user.Password, user.Hash);
                user.Password = decrypted;
                return user;
            }
            return null;
        }
        public async Task<ServiceCredentialsModel> GetByIdServiceCredentialsModel(string userId)
        {
            var user = await _context.ServiceCredentialsModel.Where(b => b.UserId == userId)
                     .FirstOrDefaultAsync();
            if (user != null)
            {
                var decrypted = PasswordHasher.Decrypt(user.Password, user.Hash);
                user.Password = decrypted;
                return user;
            }
            return null;
        }
        public UsersCredentialsModel GetUsersCredentialsModel(string username, string password, Service service)
        {
            ServiceModel model = new ServiceModel()
            {
                Service = service
            };

            var user = _context.UsersCredentialsModels.Where(b => b.Username == username).FirstOrDefault();
            //  _context.UsersCredentialsModels.Where(b => b.Services.Contains(model));


            if (user != null)
            {
                var hashedPassword = PasswordHasher.HashPassword(password, user.Hash);
                if (hashedPassword == user.Password) return user;
                else return null;
            }
            return null;
        }
        public bool CheckHash(string id)
        {
            var user = _context.UsersCredentialsModels.Find(id);
            var hashed = PasswordHasher.HashPassword(user.Password, user.Hash);

            if (hashed == user.Password) return true;
            else return false;
        }

        public UsersCredentialsModel GetById(string id)
        {
            return _context.UsersCredentialsModels.Find(id);
            //var hashed = PasswordHasher.HashPassword(user.Password, user.Hash);
            //user.Password = hashed;
            //if (hashed == user.Password)
            //{
            //return user;
            //}


        }
        public UsersCredentialsModel GetByEmail(string email)
        {
            return _context.UsersCredentialsModels.Where(b => b.Username == email).FirstOrDefault();
        }

        public void RemoveUsersCredentialsModel(string userId)
        {
            var model = _context.UsersCredentialsModels.Where(b => b.UserId == userId).FirstOrDefault();
            _context.UsersCredentialsModels.Remove(model);
            _context.SaveChanges();
        }
        public void RemoveServiceFromUser(string userId, Service service)
        {
            var userService = _context.ServiceModel.Where(i => i.UsersCredentialsModelUserId == userId).Where(s => s.Service == service).FirstOrDefault();
            _context.ServiceModel.Remove(userService);
            _context.SaveChanges();
        }
        public void SaveSessionId(CookieModel cookie)
        {
            _context.Add(cookie);
            _context.SaveChanges();
        }

        public CookieModel GetCookie(string userId, Service service)
        {
            var cookie = _context.CookieModel.Where(b => b.UserId == userId).Where(b => b.Service == service).FirstOrDefault();
            if (cookie != null)
            {
                return cookie;
            }
            else return null;
        }

        public void SaveProjections(ProjectionModel projection)
        {
            try
            {
                var model = _context.ProjectionModel.Where(b => b.UserId == projection.UserId).FirstOrDefault();
                if (model != null)
                {
                    model = projection;

                    _context.SaveChanges();


                }
                else
                {
                    _context.ProjectionModel.Add(projection);
                    _context.SaveChanges();
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public void SaveBadooPictures(List<PictureUrlModel> model)
        {
            foreach (var item in model)
            {
                _context.PictureUrlModel.Add(item);
            }
            _context.SaveChanges();
        }
        public List<PictureUrlModel> GetBadooPictures(string userId, Service service)
        {
            return _context.PictureUrlModel.Where(i => i.UserId == userId && i.Service == service).ToList();
        }
    }

}
