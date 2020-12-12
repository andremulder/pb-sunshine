using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Google.Apis.Gmail.v1.Data;
using System.IO;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "fnOnUpdateValidators();");

        
    }
    protected void ButtonVerzend_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            // validate the Captcha to check we're not dealing with a bot
            // bool isHuman = ExampleCaptcha.Validate(CaptchaCodeTextBox.Text);
            bool isHuman = false;
            // CaptchaCodeTextBox.Text = null; // clear previous user input

            var encodedResponse = Request.Form["g-Recaptcha-Response"];
            isHuman = ReCaptcha.Validate(encodedResponse);
            if (!isHuman)
            {
                return;
            }
            else
            {
                string naam = HttpUtility.HtmlEncode(TextBoxNaam.Text);
                string email = HttpUtility.HtmlEncode(TextBoxEmail.Text);
                string telefoon = HttpUtility.HtmlEncode(TextBoxTelefoon.Text);
                string onderwerp = HttpUtility.HtmlEncode(TextBoxOnderwerp.SelectedValue);
                string bericht = HttpUtility.HtmlEncode(TextBoxBericht.Text);
                string ip = IpAddress.GetVisitorIPAddress(false);
                IPHostEntry IpEntry = null;
                string host = "";

                try
                {
                    IpEntry = Dns.GetHostEntry(IPAddress.Parse(ip));
                    host = IpEntry.HostName;
                }
                catch
                {

                }

                if (RequiredFieldValidatorNaam.IsValid == false)
                {
                    return;
                }

                if (RequiredFieldValidatorBericht.IsValid == false)
                {
                    return;
                }

                if (EmailValidator.IsValid == false)
                {
                    return;
                }

                SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();
                var contacts = db.contacts;

                var contact = new contact()
                {
                    naam = naam,
                    email = email,
                    telefoon = telefoon,
                    onderwerp = onderwerp,
                    bericht = bericht,
                    ip = ip,
                    host = host
                };

                contacts.InsertOnSubmit(contact);
                db.SubmitChanges();

                var message = new MailMessage();

                message.To.Add(new MailAddress("andre.mulder@gmail.com"));

                message.Subject = TextBoxOnderwerp.SelectedItem.Text;
                message.IsBodyHtml = true;

                message.Body = "Naam: " + naam + "<BR />";
                message.Body += "Email: " + email + "<BR />";
                message.Body += "Telefoonnummer: " + telefoon + "<BR />";
                message.Body += "Bericht: " + bericht;

                if (TextBoxEmail2.Text != "")
                {
                    message.Body += "TextBoxEmail2 is gevuld, bot!";
                }

                MailAddress from = new MailAddress(email, naam);
                message.From = from;
                message.ReplyToList.Add(from);

                // SmtpClient smtp = new SmtpClient();
                // smtp.Send(message);

                GoogleMail gmail = new GoogleMail();
                gmail.sendMail(message);

                TextBoxNaam.Text = "";
                TextBoxEmail.Text = "";
                TextBoxTelefoon.Text = "";
                TextBoxBericht.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertContactMailSend", "alert('Het bericht is succesvol verstuurd. Er zal spoedig contact met u worden opgenomen.');", true);
                Server.Transfer("Default.aspx");
            }
        }
        


    
    
    }

    protected void EmailValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string naam = HttpUtility.HtmlEncode(TextBoxNaam.Text);
        string email = HttpUtility.HtmlEncode(TextBoxEmail.Text);
        try
        {
            MailAddress from = new MailAddress(email, naam);
            TextBoxEmail.BackColor = System.Drawing.Color.Empty;
            args.IsValid = true;
        }
        catch
        {
            TextBoxEmail.BackColor = System.Drawing.Color.MistyRose;
            args.IsValid = false;
        }
        
    }
    public class ReCaptcha
    {
        public bool Success { get; set; }
        public List<string> ErrorCodes { get; set; }
        public static bool Validate(string encodedResponse)
        {
            if (string.IsNullOrEmpty(encodedResponse)) return false;

            var client = new System.Net.WebClient();
            var secret = "6LcpBoMUAAAAAEArjypxJTyZbYXSlqpbx0IjtfdH";
            var googleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, encodedResponse));
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var reCaptcha = serializer.Deserialize<ReCaptcha>(googleReply);
            return reCaptcha.Success;
        }
    }
}

