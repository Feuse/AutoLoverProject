using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class UserBadooPictureModel
    {
        public string UserId { get; set; }
        public string PreviewUrl { get; set; }
        [Key]
        public string PhotoId { get; set; }
    }
}
