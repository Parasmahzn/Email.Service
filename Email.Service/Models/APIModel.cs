using Newtonsoft.Json;
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
        [JsonProperty(Order = 1)]
        public bool Success { get; set; } = false;

        [JsonProperty(Order = 2)]
        public string Message { get; set; } = string.Empty;

        [JsonProperty(Order = 3)]
        public object? Result { get; set; }

        [JsonProperty(Order = 4)]
        public List<string> ErrorMessages { get; set; } = new();
    }
}
