using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI.HtmlControls;

public partial class AgendaAdd : System.Web.UI.Page
{
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.Name != "brend") {
            ListItem item = new ListItem();
            item.Value = "2";
            item.Text = "KleintjeSunshine";
            DropDownAgendatype.Items.Add(item);
        }
    }

    protected void ButtonOpslaan_Click(object sender, EventArgs e)
    {
        if (Page.IsValid) {
            bool result1;
            bool result2;
            string googleAgendaSynchId;

            TimeSpan van;
            TimeSpan tot;

            string adres = TextBoxAdres.Text;
            string omschrijving = TextBoxOmschrijving.Text;
            bool openbaar = CheckBoxOpenbaar.Checked;

            result1 = TimeSpan.TryParse(TextBoxVan.Text, out van);
            if (!result1)
            {
                van = new TimeSpan(10, 0, 0);
            }
            result2 = TimeSpan.TryParse(TextBoxTot.Text, out tot);
            if (!result2)
            {
                tot = new TimeSpan(11, 0, 0);
            }

            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("nl-NL");
            DateTime datum = Convert.ToDateTime(TextBoxDatum.Text, cultureinfo);

            DateTime DateTimeVan = new DateTime(datum.Year, datum.Month, datum.Day, van.Hours, van.Minutes, van.Seconds);
            DateTime DateTimeTot = new DateTime(datum.Year, datum.Month, datum.Day, tot.Hours, tot.Minutes, tot.Seconds);

            if (DateTimeTot < DateTimeVan)
            {
                DateTimeTot = DateTimeTot.AddDays(1);
            }

            int agendaType = Convert.ToInt16(DropDownAgendatype.SelectedValue);

            GoogleAgenda googleAgenda = null;
            if (agendaType == 1)
            {
                googleAgenda = new GoogleAgenda("Sunshine");
            }
            else if (agendaType == 2) {
                googleAgenda = new GoogleAgenda("KleintjeSunshine");
            }
            else if (agendaType == 3)
            {
                googleAgenda = new GoogleAgenda("Vrijhouden");
            }
            
            googleAgendaSynchId = googleAgenda.CreateEvent(omschrijving, omschrijving, adres, DateTimeVan, DateTimeTot);

            SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();
            var agendaTable = db.agendas;

            var agendaitem = new agenda() {
                adres = adres,
                datum = datum,
                googleAgendaSynchId = googleAgendaSynchId,
                omschrijving = omschrijving,
                openbaar = openbaar,
                tot = tot,
                van = van,
                agendatype = agendaType
            };

            agendaTable.InsertOnSubmit(agendaitem);
            db.SubmitChanges();

            MailMessage message = new MailMessage();

            // message.To.Add(new MailAddress("andre.mulder@gmail.com"));

            switch (agendaitem.agendatype)
            {
                case 1:
                    message.To.Add(new MailAddress("andre.mulder@gmail.com"));
                    message.To.Add(new MailAddress("deborah_v_d_molen@hotmail.com"));
                    message.To.Add(new MailAddress("erwin@pb-sunshine.nl"));
                    message.To.Add(new MailAddress("sheen2108@gmail.com"));

                    message.Subject = User.Identity.Name + " heeft een nieuw optreden toegevoegd";
                    
                    message.Body = "Hint: Klik niet op de tijden hieronder. De agenda is al bijgewerkt! <BR /><BR />";
                    message.Body += "Datum: " + datum.ToString("dd-MM-yyyy") + "<BR />";
                    message.Body += "Adres: " + adres + "<BR />";
                    message.Body += "Omschrijving: " + omschrijving + "<BR />";
                    if (openbaar) { message.Body += "Openbaar: Ja"; } else { message.Body += "Openbaar: Nee"; }
                    message.Body += "<br />";
                    message.Body += "Van: " + van.ToString(@"hh\:mm") + "<BR />";
                    message.Body += "Tot: " + tot.ToString(@"hh\:mm") + "<BR />";
                    message.Body += "Agenda: Sunshine <BR />";
                    message.Body += "<BR />";

                break;

                case 2:
                    message.To.Add(new MailAddress("andre.mulder@gmail.com"));
                    message.To.Add(new MailAddress("deborah_v_d_molen@hotmail.com"));
                    message.To.Add(new MailAddress("erwin@pb-sunshine.nl"));

                    message.Subject = User.Identity.Name + " heeft een nieuw optreden toegevoegd";
                    message.Body = "Hint: Klik niet op de tijden hieronder. De agenda is al bijgewerkt! <BR /><BR />";
                    message.Body += "Datum: " + datum.ToString("dd-MM-yyyy") + "<BR />";
                    message.Body += "Adres: " + adres + "<BR />";
                    message.Body += "Omschrijving: " + omschrijving + "<BR />";
                    if (openbaar) { message.Body += "Openbaar: Ja"; } else { message.Body += "Openbaar: Nee"; }
                    message.Body += "<br />";
                    message.Body += "Van: " + van.ToString(@"hh\:mm") + "<BR />";
                    message.Body += "Tot: " + tot.ToString(@"hh\:mm") + "<BR />";
                    message.Body += "Agenda: KleintjeSunshine <BR />";
                    message.Body += "<BR />";
                break;

                case 3:
                    message.To.Add(new MailAddress("andre.mulder@gmail.com"));
                    message.To.Add(new MailAddress("deborah_v_d_molen@hotmail.com"));
                    message.To.Add(new MailAddress("erwin@pb-sunshine.nl"));
                    message.To.Add(new MailAddress("sheen2108@gmail.com"));

                    message.Subject = User.Identity.Name + " wil graag een datum vrijhouden.";
                    message.Body = "Hint: Klik niet op de tijden hieronder. De agenda is al bijgewerkt! <BR /><BR />";
                    message.Body += "Datum: " + datum.ToString("dd-MM-yyyy") + "<BR />";
                    message.Body += "Adres: " + adres + "<BR />";
                    message.Body += "Omschrijving: " + omschrijving + "<BR />";
                    // if (openbaar) { message.Body += "Openbaar: Ja"; } else { message.Body += "Openbaar: Nee"; }
                    message.Body += "<br />";
                    message.Body += "Van: " + van.ToString(@"hh\:mm") + "<BR />";
                    message.Body += "Tot: " + tot.ToString(@"hh\:mm") + "<BR />";
                    message.Body += "Agenda: Vrijhouden <BR />";
                    message.Body += "<BR />";
                break;
                default:
                break;
            }                 

            message.IsBodyHtml = true;

            GoogleMail gmail = new GoogleMail();
            gmail.sendMail(message);

            // SmtpClient smtp = new SmtpClient();

            
                // smtp.Send(message);
            
            
            Server.Transfer("Agenda.aspx", true);
        }        
    }
    protected void TextBoxDatumCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("nl-NL");
            DateTime datum = Convert.ToDateTime(args.Value, cultureinfo);

            if (datum.Date < DateTime.Now.Date) {
                TextBoxDatumCustomValidator.ErrorMessage = "Ingevulde datum ligt in het verleden. WAT BIST DOE DOM JONG!";
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }           
        }
        catch
        {
            TextBoxDatumCustomValidator.ErrorMessage = "Geen geldige datum. Formaat is: DD-MM-YYYY"; 
            args.IsValid = false;
        }
    }
    protected void TextBoxTimeCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {            
            bool result;
            TimeSpan tijd = new TimeSpan(12, 0, 0);
            result = TimeSpan.TryParse(args.Value, out tijd);
            args.IsValid = true;            
        }
        catch
        {
            args.IsValid = false;
        }
    }   
}