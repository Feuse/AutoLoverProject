using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class GenericUser
    {
        public string username { get; set; }
        public string password { get; set; }
        public int MessageId { get; set; }
        public string UserId { get; set; }
        public int Likes { get; set; }
        public Service Service { get; set; }

        public DateTime Time { get; set; }
        public ApplicationUser User { get; set; }
    }
}
