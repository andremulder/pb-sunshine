using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for GoogleMail
/// </summary>
public class GoogleMail
{

    static string smtpAddress = "smtp.gmail.com";
    static int portNumber = 587;
    static bool enableSSL = true;
    static string emailFromAddress = "andre.mulder@gmail.com"; //Sender Email Address  
    // static string password = "ygbqaquudqdpdhav"; //Sender Password  
    static string password = "tihcixsmochjzmzn";
    static string emailToAddress = "andre.mulder@outlook.com"; //Receiver Email Address  
    static string subject = "Hello";
    static string body = "Hello, This is Email sending test using gmail.";

    public GoogleMail()
    {
        
    }

    public void sendMail(MailMessage mailMessage)
    {
        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
        {
            smtp.Credentials = new NetworkCredential(emailFromAddress, password);
            smtp.EnableSsl = enableSSL;
            smtp.Send(mailMessage);
        }
    }

}