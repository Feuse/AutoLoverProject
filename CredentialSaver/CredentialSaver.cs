using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using ServicesImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace DbServices
{
    public class CredentialDb : ICredentialDb
    {
        private readonly AppDbContext _context;
        public CredentialDb(AppDbContext context)
        {
            _context = context;
        }
        public ProjectionModel GetUsersModel(string userId)
        {


            return _context.ProjectionModel.Where(b => b.UserId == userId).FirstOrDefault(); ;
        }

        public void TESTSave()
        {
            var us = _context.UsersCredentialsModels.Where(i => i.UserId == "3d48b12d-09fb-4b43-ade0-fc5577ae9b2a").First();
            ServiceModel sm = new ServiceModel();
            sm.Service = Service.Grinder;

            List<ServiceModel> list = new List<ServiceModel>();
            list.Add(sm);


            us.Services = list;
            _context.Update(us);
            _context.SaveChanges();
        }

        public List<Service> GetUserServices(string userId)
        {
            List<Service> services = new List<Service>();
            var user = _context.UsersCredentialsModels.Where(i => i.UserId == userId).First();
            return _context.ServiceModel.Where(i => i.UsersCredentialsModelUserId == userId).Select(i => i.Service).ToList();
        }

        public void Save(UsersCredentialsModel model)
        {
            var salt = PasswordHasher.Create();
            model.Password = PasswordHasher.HashPassword(model.Password, salt);
            model.Hash = salt;
            
            _context.UsersCredentialsModels.Add(model);
            _context.SaveChanges();
        }
        public void SaveUserServiceCredentials(string username, string password, Service service)
        {
            var userId = Get(username, password, service).UserId;
            var salt = PasswordHasher.Create();
            ServiceCredentialsModel serviceModel = new ServiceCredentialsModel
            {
                Password = PasswordHasher.HashPassword(password, salt),
                Service = service,
                UserId = userId,
                Username = username,
                Hash = salt
            };
            _context.ServiceCredentialsModel.Add(serviceModel);
            _context.SaveChanges();
        }
        public ServiceCredentialsModel GetServiceCredentialsModel(string username, string password)
        {
            var user = _context.ServiceCredentialsModel.Where(b => b.Username == username)
                     .FirstOrDefault();
            if (user != null)
            {
                var hashedPassword = PasswordHasher.HashPassword(password, user.Hash);
                if (hashedPassword == user.Password) return user;
                else return null;
            }
            return null;
        }
        public ServiceCredentialsModel GetByIdServiceCredentialsModel(string userId)
        {
            var user = _context.ServiceCredentialsModel.Where(b => b.UserId == userId)
                     .FirstOrDefault();
            if (user != null)
            {
                var decrypted = PasswordHasher.PasswordDecrypt(user.Password, user.Hash);
                user.Password = decrypted;
                return user;
            }
            return null;
        }
        public UsersCredentialsModel Get(string username, string password, Service service)
        {
            var user = _context.UsersCredentialsModels.Where(b => b.Username == username)
                    .FirstOrDefault();
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
            var user = _context.UsersCredentialsModels.Find(id);
            var res = PasswordHasher.PasswordDecrypt(user.Password, user.Hash);
            user.Password = res;
            return user;
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
                    _context.Remove(projection);
                    _context.SaveChanges();
                    _context.Add(projection);
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
        public List<PictureUrlModel> GetBadooPictures(string userId)
        {
            return _context.PictureUrlModel.Where(i => i.UserId == userId).ToList();
        }
    }

}
