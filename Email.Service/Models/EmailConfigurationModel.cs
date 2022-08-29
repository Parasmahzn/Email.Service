namespace Email.Service.Models;

public class EmailSetup
{
    public bool FromDb { get; set; }
    public bool FromFile { get; set; }
    public string FilePath { get; set; } = string.Empty;
}

public class EmailModel
{
    public string To { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}
