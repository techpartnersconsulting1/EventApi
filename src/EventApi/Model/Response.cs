namespace School.Api.Event.Model
{
    public class Response<T>
    {
        public string Message { get; set; } = string.Empty;

        public T Dto { get; set; }


        public void SetDto(T dto)
        {
            Dto = dto;
        }
    }
}