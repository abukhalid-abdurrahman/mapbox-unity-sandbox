using Enums;

namespace Models
{
    public class Response<T>
    {
        public ResponseStatusCode StatusCode { get; set; }
        public T Payload { get; set; }
    }
}