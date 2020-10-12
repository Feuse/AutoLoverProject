using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class UserSearchSettingsModel
    {
        public string StartAge { get; set; }
        public string EndAge { get; set; }
        public string Distance { get; set; }
        public long[] Gender { get; set; }
        public string Service { get; set; }
    }
}
