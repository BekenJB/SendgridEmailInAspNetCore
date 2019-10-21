using System.Collections.Generic;
using System.Threading.Tasks;

namespace SendgridEmailInAspNetCore.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(List<string> emails, string subject, string message);
    }
}
