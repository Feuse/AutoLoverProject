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
        public UsersCredentialsModel Get(string username, string password)
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
    }

}
