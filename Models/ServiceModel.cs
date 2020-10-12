using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class ServiceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ServiceId { get; set; }
        public Service Service { get; set; }
        public string UsersCredentialsModelUserId { get; set; }
        public UsersCredentialsModel Model { get; set; }
    }
}
