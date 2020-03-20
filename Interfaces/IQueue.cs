using Models;

namespace Interfaces
{
    public interface IQueue
    {
        public void Queue(MessageWithoutUser message);
    }
}
