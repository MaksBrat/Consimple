namespace BLL.Infractructure.Exceptions.Base
{
    public class CustomizedResponseException : ConsimpleBaseException
    {
        public int HttpStatusCode { get; }

        public CustomizedResponseException(int httpStatusCode, string errorId, string message)
            : this(httpStatusCode, errorId, message, null)
        {
        }

        public CustomizedResponseException(int httpStatusCode, string errorId, string message, Exception innerException)
            : base(errorId, message, innerException)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
