using BLL.Infractructure.Exceptions.Base;

namespace BLL.Infractructure.Exceptions
{
    public class RecordNotFoundException : ConsimpleBaseException
    {
        public RecordNotFoundException(string errorId, string message)
            : base(errorId, message)
        {
        }
    }
}
