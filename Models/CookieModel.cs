using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class CookieModel
    {
        [Key]
        public string UserId { get; set; }
        public string SessionId { get; set; }
        public DateTime? Expiry { get; set; }
        public Service Service { get; set; }
    }
}
