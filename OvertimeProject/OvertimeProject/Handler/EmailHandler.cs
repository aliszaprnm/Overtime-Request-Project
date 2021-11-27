using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OvertimeProject.Handler
{
    public class EmailHandler
    {
        public void SendNotification(string resetCode, string email)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("smarttechnomcc58@gmail.com", "123456789Ok");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("smarttechnomcc58@gmail.com", "123456789Ok");
            smtp.Credentials = nc;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("smarttechnomcc58@gmail.com", "Overtime Request Reset Password");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Reset Password " + DateTime.Now.ToString("HH:mm:ss");
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Hi " + "\nThis is new password for your account. \n\n" + resetCode + "\n\nThank You";
            smtp.Send(mailMessage);
        }
        public void SendPassword(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");


            MailMessage mm = new MailMessage("smarttechnomcc58@gmail.com", email)
            {
                Subject = "Email Register Confirmation - " + time24 + ",",
                Body = "Hi," + "<br/> Your password is <b>B0o7c@mp</b>" + "<br/> Please login with your password.",

                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            NetworkCredential NetworkCred = new NetworkCredential("smarttechnomcc58@gmail.comm", "123456789Ok");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }

        public void SendNotificationToEmployee(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            MailMessage mm = new MailMessage("smarttechnomcc58@gmail.com", email)
            {
                Subject = "Overtime Request Notification - " + time24 + ",",
                Body = "Hi," + "<br/> Your request has been sent to your manager." + "<br/> Please wait for a further information.",

                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            NetworkCredential NetworkCred = new NetworkCredential("smarttechnomcc58@gmail.com", "123456789Ok");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }

        public void SendApproveNotificationToEmployeebyManager(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");


            MailMessage mm = new MailMessage("smarttechnomcc58@gmail.com", email)
            {
                Subject = "Manager Approval Result for Your Overtime Request - " + time24 + ",",
                Body = "Hi," + "<br/> Your request has been approved by manager. <br/> Please wait for approval from Finance Dept",

                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            NetworkCredential NetworkCred = new NetworkCredential("smarttechnomcc58@gmail.com", "123456789Ok");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }
        public void SendApproveNotificationToEmployeebyFinance(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");


            MailMessage mm = new MailMessage("smarttechnomcc58@gmail.com", email)
            {
                Subject = "Finance Approval Result for Your Overtime Request" + time24 + ",",
                Body = "Hi," + "<br/> Your request has been approved. <br/>",

                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            NetworkCredential NetworkCred = new NetworkCredential("smarttechnomcc58@gmail.com", "123456789Ok");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }

        public void SendRejectNotificationToEmployee(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");


            MailMessage mm = new MailMessage("smarttechnomcc58@gmail.com", email)
            {
                Subject = "Approval Result for Your Overtime Request - " + time24 + ",",
                Body = "Hi," + "<br/> Your request has been rejected.",

                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            NetworkCredential NetworkCred = new NetworkCredential("smarttechnomcc58@gmail.com", "123456789Ok");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }
    }
}
