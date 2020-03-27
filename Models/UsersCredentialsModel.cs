using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class UsersCredentialsModel
    {
        [Key]
        public string Id { get; set; }
        public string ServiceId { get; set; }
        public Service Service { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Hash { get; set; }
    }
}
