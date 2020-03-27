using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using ServicesImpl;
using System;
using System.Linq;
using Utils;

namespace DbServices
{
    public class CredentialSaver : ICredentialSaver
    {
        private readonly AppDbContext _context;
        public CredentialSaver(AppDbContext context)
        {
            _context = context;
        }
        public void Save(UsersCredentialsModel model)
        {
            var salt = PasswordHasher.Create();
            model.Password = PasswordHasher.HashPassword(model.Password, salt);
            model.Hash = salt;
            _context.Add(model);
            _context.SaveChangesAsync();
        }
        public UsersCredentialsModel Get(string username, string password,Service service)
        {
            var user = _context.UsersCredentialsModels.Where(b => b.Username == username).Where(b=>b.Service == service)
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

        public void SaveSessionId(CookieModel cookie)
        {
            _context.Add(cookie);
            _context.SaveChanges();
        }

        public CookieModel GetCookie(string userId, Service service)
        {
            var cookie = _context.CookieModel.Where(b => b.UserId == userId).Where(b => b.Service == service).FirstOrDefault(); ;
            if (cookie != null)
            {
                return cookie;
            }
            else return null;       
        }
    }

}
