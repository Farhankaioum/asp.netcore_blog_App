using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ksp.blog.membership
{
    public interface IMailService : IDisposable
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
