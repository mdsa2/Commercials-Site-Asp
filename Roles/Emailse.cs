using Microsoft.AspNetCore.Identity.UI.Services;

namespace CM.Roles
{
    public class Emailse : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
          return Task.CompletedTask;
        }
    }
}
