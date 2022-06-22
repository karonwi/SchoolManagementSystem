using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using SchoolManagement.Core.DTOs;
using SchoolManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly IMailjetClient _mailClient;
        public MailService(IMailjetClient mailClient)
        {
            _mailClient = mailClient;
        }
        public string GetEmailTemplate(string templateName)
        {
            string baseDirectory = Directory.GetCurrentDirectory();
            string folderName = "/HtmlTemplate";
            var path = Path.Combine(baseDirectory + folderName, templateName);
            return File.ReadAllText(path);
        }

        public async Task SendMailAsync(MailRequestDTO mailRequest)
        {
            try
            {
                string mailRecipient = mailRequest.ToEmail;
                MailjetRequest request = new MailjetRequest { Resource = Send.Resource, }
                .Property(Send.Messages, new JArray
                {
                    new JObject
                    {
                        {"From", new JObject
                            {
                                {"Email","karonwiyin@gmail.com"},
                                {"Name","SchoolManagement"}
                            }
                        },
                        {"To", new JArray
                            {
                                new JObject
                                {
                                    {"Email",mailRecipient },
                                }
                            }

                        },
                        {"Subject",mailRequest.Subject},
                        {"HtmlPart",$@"{mailRequest.Body}"},
                        {"CustomId","AppGettingStartedTest"}
                    }
                });
                MailjetResponse response = await _mailClient.PostAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                    Console.WriteLine(response.GetData());
                }
                else
                {
                    Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
                    Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                    Console.WriteLine(response.GetData());
                    Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
