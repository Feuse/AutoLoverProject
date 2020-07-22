using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class CookieModel
    {
        [Key]
        public string SessionId { get; set; }
        public DateTimeOffset? Expiry { get; set; }
        public string UserId { get; set; }
        public Service Service { get; set; }

    }
}
