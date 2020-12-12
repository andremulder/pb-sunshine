using MimeKit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AgendaEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string querystringValue = Request.QueryString["id"];
            int agendaid;
            bool agendaIdIsValid = false;
            agendaIdIsValid = int.TryParse(querystringValue, out agendaid);

            SunshineDatabaseDataContext dc = new SunshineDatabaseDataContext();
            var agendaitem = dc.agendas.Where(item => item.id == agendaid).FirstOrDefault();

            if (User.Identity.Name == "brend" && agendaitem.agendatype == 2) {
                agendaitem = null;
            }


            if (agendaitem != null)
            {

                AgendaResultPanel.Visible = true;
                AgendaNoResultsPanel.Visible = false;

                String datumtext = 

                TextBoxDatum.Text = agendaitem.datum.ToString("dd-MM-yyyy");
                TextBoxAdres.Text = agendaitem.adres;
                TextBoxOmschrijving.Text = agendaitem.omschrijving;
                if (agendaitem.openbaar == true)
                {
                    CheckBoxOpenbaar.Checked = true;
                }
                else
                {
                    CheckBoxOpenbaar.Checked = false;
                }
                TextBoxVan.Text = agendaitem.van.Value.ToString("hh\\:mm");
                TextBoxTot.Text = agendaitem.tot.Value.ToString("hh\\:mm");
                HiddenFieldGoogleAgendaID.Value = agendaitem.googleAgendaSynchId;
                HiddenFieldAgendaType.Value = agendaitem.agendatype.ToString();
            }

            else
            {
                AgendaResultPanel.Visible = false;
                AgendaNoResultsPanel.Visible = true;
            }
        
        }    

    }
    protected void ButtonOpslaan_Click(object sender, EventArgs e)
    {

        int agendaID = 0;
        string agendIDQueryString = "";
        string googleAgendaSynchId = "";
        int agendaType = 0;
        string adres = "";
        string omschrijving = "";
        bool openbaar = false;
        bool result;
        TimeSpan van = new TimeSpan(12,0,0);
        TimeSpan tot = new TimeSpan(12,15,0);
        
        agendIDQueryString = Request.QueryString["id"];

        adres = TextBoxAdres.Text;
        omschrijving = TextBoxOmschrijving.Text;

        openbaar = CheckBoxOpenbaar.Checked;

        result = int.TryParse(agendIDQueryString, out agendaID);
        googleAgendaSynchId = HiddenFieldGoogleAgendaID.Value;
        agendaType = Convert.ToInt16(HiddenFieldAgendaType.Value);

        result = TimeSpan.TryParse(TextBoxVan.Text,out van);
        result = TimeSpan.TryParse(TextBoxTot.Text, out tot);

        System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("nl-NL");
        DateTime datum = Convert.ToDateTime(TextBoxDatum.Text, cultureinfo);

        DateTime DateTimeVan = new DateTime(datum.Year, datum.Month, datum.Day, van.Hours, van.Minutes, van.Seconds);
        DateTime DateTimeTot = new DateTime(datum.Year, datum.Month, datum.Day, tot.Hours, tot.Minutes, tot.Seconds);

        if (DateTimeTot < DateTimeVan)
        {
            DateTimeTot = DateTimeTot.AddDays(1);
        }

        SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();
        var agendaTable = db.agendas;
        var agendaitem = agendaTable.Where(a => a.id == agendaID).First();

        var agendaItemOld = new agenda()
        {
            adres = agendaitem.adres,
            datum = agendaitem.datum,
            googleAgendaSynchId = agendaitem.googleAgendaSynchId,
            omschrijving = agendaitem.omschrijving,
            openbaar = agendaitem.openbaar,
            tot = agendaitem.tot,
            van = agendaitem.van,
            agendatype = agendaitem.agendatype
        };

        agendaitem.adres = adres;
        agendaitem.datum = datum;
        agendaitem.googleAgendaSynchId = googleAgendaSynchId;
        agendaitem.id = agendaID;
        agendaitem.omschrijving = omschrijving;
        agendaitem.openbaar = openbaar;
        agendaitem.van = van;
        agendaitem.tot = tot;
        agendaitem.agendatype = agendaType;
        
        db.SubmitChanges();        

        GoogleAgenda googleAgenda = null;
        if (agendaType == 1) {
            googleAgenda = new GoogleAgenda("Sunshine");
        }
        else if(agendaType == 2) {
            googleAgenda = new GoogleAgenda("KleintjeSunshine");
        }
        
        googleAgenda.UpdateEvent(omschrijving, omschrijving, adres, DateTimeVan, DateTimeTot, googleAgendaSynchId);

        MailMessage message = new MailMessage();

        // message.To.Add(new MailAddress("andre.mulder@gmail.com"));

        switch (agendaitem.agendatype)
        {
            case 1:
                message.To.Add(new MailAddress("andre.mulder@gmail.com"));
                message.To.Add(new MailAddress("deborah_v_d_molen@hotmail.com"));
                message.To.Add(new MailAddress("erwin@pb-sunshine.nl"));
                message.To.Add(new MailAddress("sheen2108@gmail.com"));
                message.Subject = "Er is een wijziging aangebracht in de agenda Sunshine door " + User.Identity.Name + ".";
            break;
            
            case 2:
                message.To.Add(new MailAddress("andre.mulder@gmail.com"));
                message.To.Add(new MailAddress("deborah_v_d_molen@hotmail.com"));
                message.To.Add(new MailAddress("erwin@pb-sunshine.nl"));
                message.Subject = "Er is een wijziging aangebracht in de agenda KleintjeSunshine door " + User.Identity.Name + ".";
            break;
            
            case 3:
                message.To.Add(new MailAddress("andre.mulder@gmail.com"));
                message.To.Add(new MailAddress("deborah_v_d_molen@hotmail.com"));
                message.To.Add(new MailAddress("erwin@pb-sunshine.nl"));
                message.Subject = "Er is een wijziging aangebracht in de agenda Vrijhouden door " + User.Identity.Name + ".";
            break;
            
            default:
            break;
        }

                
        

        message.Body = "Hint: Klik niet op de tijden hieronder. De Sunshine agenda is al bijgewerkt! <BR /><BR />";

        message.Body += "Oud:" + "<BR />";
        message.Body += "Datum: " + agendaItemOld.datum.ToString("dd-MM-yyyy") + "<BR />";
        message.Body += "Adres: " + agendaItemOld.adres + "<BR />";
        message.Body += "Omschrijving: " + agendaItemOld.omschrijving + "<BR />";
        message.Body += "Openbaar: " + agendaItemOld.openbaar.ToString() + "<BR />";
        message.Body += "Van: " + agendaItemOld.van.Value.ToString(@"hh\:mm") + "<BR />";
        message.Body += "Tot: " + agendaItemOld.tot.Value.ToString(@"hh\:mm") + "<BR />";
        message.Body += "<BR />";

        message.Body += "Nieuw:" + "<BR />";
        message.Body += "Datum: " + datum.ToString("dd-MM-yyyy") + "<BR />";
        message.Body += "Adres: " + adres + "<BR />";
        message.Body += "Omschrijving: " + omschrijving + "<BR />";
        message.Body += "Openbaar: " + openbaar.ToString() + "<BR />";
        message.Body += "Van: " + van.ToString(@"hh\:mm") + "<BR />";
        message.Body += "Tot: " + tot.ToString(@"hh\:mm") + "<BR />";
        message.Body += "<BR />";

        message.IsBodyHtml = true;

        GoogleMail gmail = new GoogleMail();
        gmail.sendMail(message);

        // SmtpClient smtp = new SmtpClient();
        
        
            // smtp.Send(message

        Server.Transfer("Agenda.aspx", true);       
    }
}