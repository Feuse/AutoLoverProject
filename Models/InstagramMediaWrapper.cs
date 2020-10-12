using System;
using System.Collections.Generic;
using System.Text;
using UtilModels;

namespace Models
{
    public class InstagramMediaWrapper
    {
        public List<InstagramMediaModel> InstagramList { get; set; }
        public InstagramMediaWrapper()
        {
            InstagramList = new List<InstagramMediaModel>();
        }
    }
}
