using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public string UserId { get; set; }
        public int Likes { get; set; }
        public Service Service { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy, hh.mm tt}")]
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }
        public ApplicationUser User { get; set; }


    }
}
