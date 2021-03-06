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
        public void SendNotification(string resetCode, string email, string name)
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
            mailMessage.Body = "Dear, " + name + ".\n\n" + "We have received your request to reset the password for the account with the following information: \n\n" + "Name: " + name + "\nEmail: " + email + "\n\nThis is new password for your account. \n\n" + resetCode + "\n\nThank You.";
            smtp.Send(mailMessage);
        }
        public void SendPassword(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");


            MailMessage mm = new MailMessage("smarttechnomcc58@gmail.com", email)
            {
                Subject = "Email Register Confirmation - " + time24 + ",",
                Body = "Dear " + "<br/> Your password is <b>B0o7c@mp</b>" + "<br/> Please login with your password.",

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
                Body = "Dear, " + "<br/> Your request has been sent to your manager." + "<br/> Please wait for a further information.",

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

        public void SendApproveNotificationToEmployeebyManager(string email, string firstName, string lastName, DateTime requestDate, int requestId, string overtimeName, DateTime startTime, DateTime endTime, string task)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");



            MailMessage mm = new MailMessage("smarttechnomcc58@gmail.com", email)
            {
                Subject = "Manager Approval Result for Your Overtime Request - " + time24 + ",",
                Body = "Dear, " + firstName + " " + lastName + ".<br/>" + "<br/></br>Your overtime request with the following information: <br/><br/><b>Request ID &ensp;&ensp;&nbsp;&nbsp;: </b>" + requestId + "<br/><b>Request Title&ensp;&nbsp;: </b>" + overtimeName + "<br/><b>Request Date &nbsp;: </b>" + requestDate.ToString("MMMM dd, yyyy") + "<br/><b>Time&emsp;&emsp;&emsp;&emsp;&ensp;: </b>" + startTime.ToString("HH:mm") + " - " + endTime.ToString("HH:mm") + "<br/><b>Task&emsp;&emsp;&emsp;&emsp;&ensp;: </b>" + task + "<br/><br/>Has been approved and forwarded to the Finance Department.<br/> Please wait for further information. <br/>" + "<br/>Thank You.<br/><br/><br/>" + "<br/>Best Regards, <br/>Manager",

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
        public void SendApproveNotificationToEmployeebyFinance(string email, string fullName, int commission, DateTime requestDate, int requestId, string overtimeName, DateTime startTime, DateTime endTime, string task)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");


            MailMessage mm = new MailMessage("smarttechnomcc58@gmail.com", email)
            {
                Subject = "Finance Approval Result for Your Overtime Request" + time24 + ",",
                Body = "Dear, " + fullName + ".<br/>" + "<br/>Your overtime request with the following information: <br/><br/><b>Request ID &ensp;&ensp;&nbsp;&nbsp;: </b>" + requestId + "<br/><b>Request Title&ensp;&nbsp;: </b>" + overtimeName + "<br/><b>Request Date &nbsp;: </b>" + requestDate.ToString("MMMM dd, yyyy") + "<br/><b>Time&emsp;&emsp;&emsp;&emsp;&ensp;: </b>" + startTime.ToString("HH:mm") + " - " + endTime.ToString("HH:mm") + "<br/><b>Task&emsp;&emsp;&emsp;&emsp;&ensp;: </b>" + task + "<br/><br/>Has been fully approved and you get an overtime commission of Rp" + commission + "<br/>Thank You.<br/><br/>" + "<br/><br/>Best Regards, <br/>Finance Controller",

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

        public void SendRejectNotificationToEmployee(string email, string fullName, DateTime requestDate, int requestId, string overtimeName, DateTime startTime, DateTime endTime, string task)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");


            MailMessage mm = new MailMessage("smarttechnomcc58@gmail.com", email)
            {
                Subject = "Approval Result for Your Overtime Request - " + time24 + ",",
                Body = "Dear, " + fullName + ".<br/>" + "<br/>Sorry, your overtime request with the following information: <br/><br/><b>Request ID &ensp;&ensp;&nbsp;&nbsp;: </b>" + requestId + "<br/><b>Request Title&ensp;&nbsp;: </b>" + overtimeName + "<br/><b>Request Date &nbsp;: </b>" + requestDate.ToString("MMMM dd, yyyy") + "<br/><b>Time&emsp;&emsp;&emsp;&emsp;&ensp;: </b>" + startTime.ToString("HH:mm") + " - " + endTime.ToString("HH:mm") + "<br/><b>Task&emsp;&emsp;&emsp;&emsp;&ensp;: </b>" + task + "<br/><br/>Was rejected because it is not in accordance with company policy." + "<br/>Thank You.",

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
