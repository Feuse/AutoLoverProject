using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class EnumParser
    {
        public static Service Parse(string service)
        {
            switch (service)
            {
                case "Badoo": return Service.Badoo;
                case "Grinder": return Service.Grinder;
                case "OkCupid": return Service.OkCupid;
                case "Tinder": return Service.Tinder;
                default:
                    break;
            }
            throw new Exception("Service error");
        }
    }
}
