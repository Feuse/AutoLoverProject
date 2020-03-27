using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class JsonCusomeSerializer
    {
        public static LocationQueryModel SerializeToLocationQueryModel(string json)
        {
            return JsonConvert.DeserializeObject<LocationQueryModel>(json);
        }
        public static SaveLocationModel SerializeToSaveLocationModel(string json)
        {
            return JsonConvert.DeserializeObject<SaveLocationModel>(json);
        }

        public static AlbumRequestModel SerializeToAlbumRequestModel(string json)
        {
            var a = JsonConvert.DeserializeObject<AlbumRequestModel>(json);
            return JsonConvert.DeserializeObject<AlbumRequestModel>(json);
        }
    }
}
