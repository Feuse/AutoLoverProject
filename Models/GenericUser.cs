using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class GenericUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int MessageId { get; set; }
        public string UserId { get; set; }
        public int Likes { get; set; }
        public Service Service { get; set; }
        public DateTime Time { get; set; }
        public ApplicationUser User { get; set; }

        public string Proffesion { get; set; }
        public string CompanyName { get; set; }
        public string School { get; set; }

        public LocationModel Location { get; set; }
        public string input { get; set; }
    }
}
