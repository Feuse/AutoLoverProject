using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class ProjectionModel
    {
        [Key]
        public string UserId { get; set; }
        public string Projections { get; set; }
        public string UsersIds { get; set; }
        public string SessionId { get; set; }
        public DateTime time { get; set; }
    }
}
