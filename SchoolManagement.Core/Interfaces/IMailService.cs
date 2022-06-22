using SchoolManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Interfaces
{
    public interface IMailService
    {
        Task SendMailAsync(MailRequestDTO mailRequest);
        string GetEmailTemplate(string templateName);
    }
}
