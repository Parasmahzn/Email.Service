using Email.Service.Models;

namespace Email.Service.Services.EmailConfig;

public interface IEmailConfiguration
{
    Task<List<EmailModel>> GetEmailContentAsync(EmailSetup email, string dataSource = "");
}
