using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace SponsorBulmaSitesi.Clases
{

    public class mail
    {
        public void talepMail(string sendMailAdress, string subject, string body,string detay,string sayfalink)
        {
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress("cekilisevimbilgi@gmail.com");
            MailAddress to = new MailAddress("cekilisevimbilgi@gmail.com");//bizim mail adresi
            MailMessage msg = new MailMessage(from, to);
            msg.IsBodyHtml = true;
            msg.Subject = subject;
            msg.Body += sendMailAdress +" | <h2> " + body + " </h2>"+ "<h4>"+detay+"</h4>" + "<b> Web sitesi " + sayfalink + "</b>"; //burada başında gönderen kişinin mail adresi geliyor
            msg.CC.Add(sendMailAdress);//herkes görür
            NetworkCredential info = new NetworkCredential("cekilisevimbilgi@gmail.com", "kelebek1.");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = info;
            client.Send(msg);
        }
        public void IslemOnaylandiMail(string sendMailAdress, string subject, string body, string detay, string sayfalink)
        {
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress("cekilisevimbilgi@gmail.com");
            MailAddress to = new MailAddress("cekilisevimbilgi@gmail.com");//bizim mail adresi
            MailMessage msg = new MailMessage(from, to);
            msg.IsBodyHtml = true;
            msg.Subject = subject;
            msg.Body += sendMailAdress + " | <h2> " + body + " </h2>" + "<h4>" + detay + "</h4>" + "<b> İşlem Takip: " + sayfalink + "</b>"; //burada başında gönderen kişinin mail adresi geliyor
            msg.CC.Add(sendMailAdress);//herkes görür
            NetworkCredential info = new NetworkCredential("cekilisevimbilgi@gmail.com", "kelebek1.");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = info;
            client.Send(msg);
        }
        public void IslemOnaylanmadiMail(string sendMailAdress, string subject, string body, string detay, string sayfalink)
        {
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress("cekilisevimbilgi@gmail.com");
            MailAddress to = new MailAddress("cekilisevimbilgi@gmail.com");//bizim mail adresi
            MailMessage msg = new MailMessage(from, to);
            msg.IsBodyHtml = true;
            msg.Subject = subject;
            msg.Body += sendMailAdress + " | <h2> " + body + " </h2>" + "<h4>" + detay + "</h4>" + "<b> İşlem Takip: " + sayfalink + "</b>"; //burada başında gönderen kişinin mail adresi geliyor
            msg.CC.Add(sendMailAdress);//herkes görür
            NetworkCredential info = new NetworkCredential("cekilisevimbilgi@gmail.com", "kelebek1.");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = info;
            client.Send(msg);
        }
        public void dekontBilgiMail(string sendMailAdress, string subject, string body, string detay)
        {
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress("cekilisevimbilgi@gmail.com");
            MailAddress to = new MailAddress("cekilisevimbilgi@gmail.com");//bizim mail adresi
            MailMessage msg = new MailMessage(from, to);
            msg.IsBodyHtml = true;
            msg.Subject = subject;
            msg.Body += sendMailAdress + " | <h2> " + body + " </h2>" + "<h4>" + detay + "</h4>"; //burada başında gönderen kişinin mail adresi geliyor
            msg.CC.Add(sendMailAdress);//herkes görür
            NetworkCredential info = new NetworkCredential("cekilisevimbilgi@gmail.com", "kelebek1.");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = info;
            client.Send(msg);
        }
        public void talepBilgiMail(string sendMailAdress, string subject, string body, string detay)
        {
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress("cekilisevimbilgi@gmail.com");
            MailAddress to = new MailAddress("cekilisevimbilgi@gmail.com");//bizim mail adresi
            MailMessage msg = new MailMessage(from, to);
            msg.IsBodyHtml = true;
            msg.Subject = subject;
            msg.Body += sendMailAdress + " | <h2> " + body + " </h2>" + "<h4>" + detay + "</h4>"; //burada başında gönderen kişinin mail adresi geliyor
            msg.CC.Add(sendMailAdress);//herkes görür
            NetworkCredential info = new NetworkCredential("cekilisevimbilgi@gmail.com", "kelebek1.");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = info;
            client.Send(msg);
        }
    }
}