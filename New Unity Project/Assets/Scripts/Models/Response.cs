using Enums;

namespace Models
{
    public class Response<T>
    {
        public ResponseStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Payload { get; set; }

        public Response()
        {
            StatusCode = ResponseStatusCode.Success;
            Message = "OK";
            Payload = default;
        }
    }
}