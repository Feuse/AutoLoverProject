using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    [Newtonsoft.Json.JsonObject(Title = "Url")]
    public class PictureUrlModel
    {
        public string PreviewUrl { get; set; }
    }
}
