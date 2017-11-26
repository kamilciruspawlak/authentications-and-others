using autentykacja_zadanieWebApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;


namespace autentykacja_zadanieWebApi.Service 
{
    public class EmailService 
    {
        private SmtpClient _smtpClient;
        public void SendEmail(EmailForm emailForm)
        {
            
            _smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential("gym550182@gmail.com", "!QAZ2wsx#EDC")
            };

       
        
            var mailMessage = new MailMessage
            {
                Sender = new MailAddress("gym550182@gmail.com"),
                From = new MailAddress("gym550182@gmail.com"),
                To = {emailForm.To },
               
                Body = "Tres maila",
                IsBodyHtml = true
            };
           
       
            _smtpClient.Send(mailMessage);
        }
    }
}