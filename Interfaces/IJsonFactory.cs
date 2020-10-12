using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IJsonFactory
    {
        public IJsonMessage GetJson(JsonTypes types);
    }
}
