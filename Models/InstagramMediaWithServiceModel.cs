using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class InstagramMediaWithServiceModel
    {
        public Service Service { get; set; }
        public List<InstagramPartialModel> Images { get; set; }

    }
    public class InstagramPartialModel
    { 
        public string PhotoId { get; set; }
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
    }

}
