using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class InstagramAuthorizeUserRequest
    {
        public string ClientId { get; set; }
        public string RedirectURL { get; set; }
        public string Scope { get; set; }
        public string ResponseType { get; set; }
    }
}
