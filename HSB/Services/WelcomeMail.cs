using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSB.Services
{
    public class WelcomeMail
    {
        private readonly IEmailSender _emailSender;

        public WelcomeMail(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task SendWelcomeEmail(string email, string name)
        {
           await _emailSender.SendEmailAsync(email, "Tak for din tilmeldning", $"Hej {name}! " +
                                                             $"\n Læs mere om os på www.autoside.dk." +
                                                             $"\n Med venlig hilsen" +
                                                             $"\n Hjælp syge børn");
        }
    }
}
