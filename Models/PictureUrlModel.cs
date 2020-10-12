using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    [Newtonsoft.Json.JsonObject(Title = "Url")]
    public class PictureUrlModel
    {
        public string UserId { get; set; }
        public string PreviewUrl { get; set; }
        [Key]
        public string PhotoId { get; set; }
        public Service Service { get; set; }
    }
}
