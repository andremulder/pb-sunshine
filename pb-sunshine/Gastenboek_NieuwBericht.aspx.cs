using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Gastenboek_NieuwBericht : System.Web.UI.Page
{
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        // HtmlMeta metadescription = (HtmlMeta)this.Header.FindControl("MetaDescription1");
        // HtmlMeta metakeywords = (HtmlMeta)this.Header.FindControl("MetaKeywords1");

        Page.Title = "Gastenboek Partyband Sunshine";
        // metadescription.Content = "Laat een bericht achter in het gastenboek van Party-band Sunshine";
        // metakeywords.Content = "Partyband, Sunshine, gastenboek, nieuw, bericht, recensie, recensies, review, reviews";

        Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "fnOnUpdateValidators();");

        if (Session["Captcha"] == null)
        {
            SetCaptchaText();
        }

    }

       
    
    protected void VerstuurBericht_Click(object sender, EventArgs e)
    {
        string CaptchaSessie = Session["Captcha"].ToString();
        if (CaptchaSessie != txtCaptcha.Text.Trim())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertCaptchaError", "alert('Getal komt niet overeen met het plaatje. Probeer het nog eens.');", true);
            SetCaptchaText();
            return;
        }
        else
        {
            string naam = HttpUtility.HtmlEncode(NaamField.Text);
            string email = HttpUtility.HtmlEncode(EmailField.Text);
            string woonplaats = HttpUtility.HtmlEncode(WoonplaatsField.Text);
            string website = HttpUtility.HtmlEncode(WebsiteField.Text);

            string bericht = HttpUtility.HtmlEncode(BerichtField.Text);

            DateTime datumnu = DateTime.Now;

            string ip = IpAddress.GetVisitorIPAddress(false);

            IPHostEntry IpEntry = Dns.GetHostEntry(IPAddress.Parse(ip));
            string hostname = IpEntry.HostName;

            string browser = HttpContext.Current.Request.ServerVariables["http_user_agent"].ToString();

            if (RequiredFieldValidatorNaam.IsValid == false)
            {
                return;
            }
            if (RequiredFieldValidatorBericht.IsValid == false)
            {
                return;
            }

            SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();
            var gastenboekTable = db.gastenboeks;

            var SpamBerichten = gastenboekTable.Where(item => item.datum == DateTime.Now).ToList();

            int huidiguur = DateTime.Now.Hour;

            int CountSpamBerichten = SpamBerichten.Where(item => item.datum.Value.Hour == huidiguur).Count();

            if (CountSpamBerichten > 3)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertSpamMessage", "alert('Je hebt al 3 berichten gepost in 1 uur tijd. Probeer het later nog eens.');", true);
                SetCaptchaText();
                return;
            }

            
            var newBericht = new gastenboek() {
                naam = naam,
                email = email,
                woonplaats = woonplaats,
                website = website,
                bericht = bericht,
                datum = datumnu,
                ip = ip,
                host = hostname,
                browser = browser
            };

            gastenboekTable.InsertOnSubmit(newBericht);
            db.SubmitChanges();
            
                        
            MailMessage message = new MailMessage();
            // message.To.Add("andre.mulder@gmail.com");
            
            
            foreach (string username in Roles.GetUsersInRole("Bandleden"))
            {
                MembershipUser u = Membership.GetUser(username);
                message.To.Add(new MailAddress(u.Email));
            }
            
                
            
                                  
            message.Subject = "Er is een bericht in het gastenboek van pb-sunshine.nl geplaatst.";
            
            message.Body = "Naam: "+naam+"<BR />";
            message.Body += "Email: "+email+"<BR />";
            message.Body += "Woonplaats: " + woonplaats + "<BR />";
            message.Body += "Website: " + website + "<BR />";
            message.Body += "<BR />";
            message.Body += "Bericht: " + bericht;
            message.Body += "<BR /><BR />";
            message.Body += "Klik <a href=\"http://pb-sunshine.nl/Beheer/Default.aspx?ReturnUrl=%2fGastenboek.aspx\">hier</a> om in te loggen en het gastenboek te openen, indien je het bericht snel wilt verwijderen.";

            message.IsBodyHtml = true;

            // SmtpClient smtp = new SmtpClient();
            // smtp.Send(message);

            GoogleMail gmail = new GoogleMail();
            gmail.sendMail(message);
            
            NaamField.Text = "";
            EmailField.Text = "";
            WoonplaatsField.Text = "";
            WebsiteField.Text = "";
            BerichtField.Text = "";

            SetCaptchaText();

            Server.Transfer("Gastenboek.aspx");            
            
        }
    }

    private void SetCaptchaText()
    {
        Random oRandom = new Random();
        int iNumber = oRandom.Next(100000, 999999);
        Session["Captcha"] = iNumber.ToString();
    }
}