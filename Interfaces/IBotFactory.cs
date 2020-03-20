using System;
using Models;

namespace Interfaces
{
    public interface IBotFactory 
    {
       public IBot GetBot(Service service);
    }
}