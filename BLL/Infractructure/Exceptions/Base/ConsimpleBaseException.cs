namespace BLL.Infractructure.Exceptions.Base
{
    public class ConsimpleBaseException : Exception
    {
        public string ErrorId { get; }

        public ConsimpleBaseException(string errorId, string message)
            : this(errorId, message, null)
        {
        }

        public ConsimpleBaseException(string errorId, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorId = errorId;
        }
    }
}
