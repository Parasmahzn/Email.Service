namespace Email.Service.Models;

public class WorkerConfig
{
    public string APIURL { get; set; } = string.Empty;
    public string APIURLMethod { get; set; } = string.Empty;
    public int APIURLDelayInterval { get; set; } = 60000;
}


