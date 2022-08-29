using Email.Service.Helpers;
using Email.Service.Models;

namespace Email.Service.Services.EmailConfig;

public class EmailConfiguration : IEmailConfiguration
{
    public async Task<List<EmailModel>> GetEmailContentAsync(EmailSetup email, string dataSource = "")
    {
        var emailContentResp = await Utilities.GetEmailContent(email.FromFile, email.FromDb, dataSource);
        return emailContentResp;
    }
}
