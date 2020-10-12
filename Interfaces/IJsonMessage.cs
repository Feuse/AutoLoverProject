using System.Collections.Generic;

namespace Interfaces
{
    public interface IJsonMessage
    {
        public void SetProperties(string s1, string s2);
        public void SetProperty(List<long> l1);
        public void SetProperties(string s1, List<long> l1);
        public void SetProperty(string s1);
        public void SetProperties(string s1, string s2, string s3);
        public void SetProperties(long s1, long s2, long s3, long[]s4);
    }
}
