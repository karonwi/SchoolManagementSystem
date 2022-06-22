using Microsoft.Extensions.Configuration;
using SchoolManagement.Core.DTOs;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Interfaces;
using SchoolManagement.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Services
{
    public class ConfirmationMailService : IConfirmationMailService
    {
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        private readonly IGenericRepo<Staff> _staffRepo;
        private readonly IGenericRepo<Student> _studentRepo;
        private readonly IGenericRepo<User> _userRepo;
        private readonly IGenericRepo<Payment> _paymentRepo;
        private readonly IFindAppUser _findAppUser;
        public ConfirmationMailService(IMailService mailService, 
            IConfiguration configuration, IGenericRepo<Staff> staffRepo,
            IGenericRepo<Student> studentRepo, IGenericRepo<User> userRepo, IGenericRepo<Payment> paymentRepo, IFindAppUser findAppUser)
        {
            _mailService = mailService;
            _configuration = configuration;
            _staffRepo = staffRepo;
            _studentRepo = studentRepo;
            _userRepo = userRepo;
            _paymentRepo = paymentRepo;
            _findAppUser = findAppUser; 
        }
        public async Task SendComfirmEmailToken(string userId)
        {
            var staff = _staffRepo.Table.FirstOrDefault(x => x.UserId == userId);
            var student = _studentRepo.Table.FirstOrDefault(x => x.UserId == userId);
            var user = _userRepo.Table.FirstOrDefault(x => x.Id == userId);
            var payment = _paymentRepo.Table.FirstOrDefault(x=>x.UserId == staff.Id || x.UserId == student.Id);

            var template = _mailService.GetEmailTemplate("EmailTemplate.html");
            TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;
            var userName = textInfo.ToTitleCase(user.FirstName + " " + user.LastName);
            template = template.Replace("{User}", $"{userName}");
            template = template.Replace("{Body}", "Payment was successful, this is your token: " + payment.OTP);
            template = template.Replace("{Details}", "");
            template = template.Replace("{Action}", $"{_configuration["Application:AppDomain"]}");
            var mailRequest = new MailRequestDTO
            {
                ToEmail = user.Email,
                Body = template,
                Subject = "Payment Confirmation Token"
            };

            await _mailService.SendMailAsync(mailRequest);
        }

        public async Task SendConfirmationEmail(UserResponseDTO userResponse)
        {
            string template = _mailService.GetEmailTemplate("EmailTemplate");
            TextInfo textInfo = new CultureInfo("en-GB",false).TextInfo;
            var userName = textInfo.ToTitleCase(userResponse.FullName);

            var encodedToken = TokenConverter.EncodeToken(userResponse.Token);
            var link = $"{_configuration["Application:AppDomain"]}/Authentication/ConfirmEmail?Email={userResponse.Email}/token={encodedToken}";

            template = template.Replace("{User}", $"{userName}");
            template = template.Replace("{Body}", "Welcome to Trojan Gh School, Registration was successful, click the link below");
            template = template.Replace("{Linkl}", link);
            template = template.Replace("{Details}", $"If you have trouble clicking on the link above you can paste this link on your browser");
            template = template.Replace("{Action}", "Confirm Email");
            

            var mailRequest = new MailRequestDTO
            {
                ToEmail = userResponse.Email,
                Body = template,
                Subject = "Confirm Email"
            };
            await _mailService.SendMailAsync(mailRequest);
        }

        public async Task SendConfirmationEmailForResetPassword(UserResponseDTO userResponse)
        {
            var template = _mailService.GetEmailTemplate("EmailTemplate.html");
            TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;
            var userName = textInfo.ToTitleCase(userResponse.FullName);
            var encodedToken = TokenConverter.EncodeToken(userResponse.Token);
            var link = $"{_configuration["Application:AppDomain"]}/Authentication/ResetPassword?=email={userResponse.Email}/token={encodedToken}";

            string message = "Reset Password";

            template = template.Replace("{User}", $"{userName}");
            template = template.Replace("{Body}", "Welcome to Trojan Gh Schools,To reset password, click the link below");
            template = template.Replace("{Link}", link);
            template = template.Replace("{Details}", $"If you have trouble clicking on the link above you can paste this link on your browser");
            template = template.Replace("{Action}", $"{message}");

            var mailRequest = new MailRequestDTO
            {
                ToEmail = userResponse.Email,
                Body = template,
                Subject = "Reset Password"
            };

            await _mailService.SendMailAsync(mailRequest);
        }

        public async Task<Response<string>> SendRemainderEmail(string userId)
        {
            Student student = _studentRepo.Table.FirstOrDefault(x => x.Id == Guid.Parse(userId));
            var template = _mailService.GetEmailTemplate("ReminderEmail.html");
            TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;
            var userName = textInfo.ToTitleCase(student.User.FirstName);
            template = template.Replace("{User}", $"{userName}");
            template = template.Replace("{Body}", "Welcome to Trojan GH School,This is to remind you of your outstanding school fees payment");
            template = template.Replace("{Details}", " This will be gotten from the frontend team");
            var mailRequest = new MailRequestDTO
            {
                ToEmail = student.User.Email,
                Body = template,
                Subject = "Reminder!!!"
            };

            await _mailService.SendMailAsync(mailRequest);
            return new Response<string>()
            {
                Message = $"Your email is successfully sent",
                Success = true
            };
        }
    }
}
