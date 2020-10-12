using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilModels
{
    public class InstagramUserDataModel
    {
        [JsonProperty("data")]
        public Data[] Data { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }

        public InstagramUserDataModel()
        {
            Data = new Data[] { new Data() };
            Paging = new Paging();
        }
    }

    public class Data
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Paging
    {
        [JsonProperty("cursors")]
        public Cursors Cursors { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }
        public Paging()
        {
            Cursors = new Cursors();
        }
    }

    public class Cursors
    {
        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }
    }
}
