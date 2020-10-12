using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class LocalProjectionModel
    {
        public string UserId { get; set; }
        public List<long> Projections { get; set; }
        public List<string> UsersIds { get; set; }
        public string SessionId { get; set; }
        public DateTime time { get; set; }
        public LocalProjectionModel()
        {
            Projections = new List<long>();
            UsersIds = new List<string>();
        }
    }
}
