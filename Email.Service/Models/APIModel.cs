using static Email.Service.SD;

namespace Email.Service.Models;

public class API
{
    public class Request
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; } = string.Empty;
        public object? Data { get; set; }
    }

    public class Response
    {
        public bool Success { get; set; } = false;
        public object? Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> ErrorMessages { get; set; } = new();
    }
}
