namespace School.Api.Event.Model
{
    public class ErrorResponse
    {
        public ExceptionDetails ErrorDetails { get; set; } = default(ExceptionDetails);

        public void SetException(ExceptionDetails exDet)
        {
            ErrorDetails = exDet;
        }
    }
}