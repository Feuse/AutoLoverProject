using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class BadooUserModel
    {
        public string UserId { get; set; }
        public List<PictureUrlModel> Images { get; set; }
        public string AboutMe { get; set; }
        public string Location { get; set; }
        public long AgeMinValue { get; set; }
        public long AgeMaxValue { get; set; }
        public long DistanceMaxValue { get; set; }
        public long[] LookingFor { get; set; }
    }
}
