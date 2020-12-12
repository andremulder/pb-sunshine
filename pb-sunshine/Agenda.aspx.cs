using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Agenda : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        // HtmlMeta metafollow = (HtmlMeta)this.Header.FindControl("MetaFollow");
        // metafollow.Content = "noindex, follow";

        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {

        SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();

        string querystringshowAll = Request.QueryString["showAll"];

        if (querystringshowAll != null) {
            if (User.Identity.Name == "brend") {
                RepeaterAgenda.DataSource = db.agendas.Where(item => item.agendatype == 1); ;
            }
            else
            {
                RepeaterAgenda.DataSource = db.agendas;
            }
            
        }

        else
        {
            if (User.Identity.Name == "brend")
            {
                RepeaterAgenda.DataSource = db.agendas.Where(item => item.datum >= DateTime.Now && item.agendatype == 1);
            }
            else
            {
                RepeaterAgenda.DataSource = db.agendas.Where(item => item.datum >= DateTime.Now);
            }
        }        
        
                
        RepeaterAgenda.DataBind();

        int countOptredens;

        if (User.Identity.Name == "brend")
        {
            countOptredens = db.agendas.Where(item => item.datum.Year == DateTime.Now.Year && item.agendatype == 1).Count();
        }
        else
        {
            countOptredens = db.agendas.Where(item => item.datum.Year == DateTime.Now.Year && item.agendatype != 3).Count();
        }

        LabelCountOptredens.Text = countOptredens.ToString();
        
    }    

    public string FormatDate(object datum)
    {
        DateTime datumobj = (DateTime)datum;
        datum = datumobj.ToString("dd-MM-yyyy");
        return datum.ToString();
    }

    public string FormatTime(object datum)
    {
        TimeSpan timeobj = (TimeSpan)datum;
        string tijd = timeobj.ToString("hh\\:mm");
        return tijd;
    }

    public string FormatAgendaType(object agendatype)
    {
        string agendatypestring = "";
        if (agendatype.ToString() == "1") {
            agendatypestring = "Sunshine";
        }
        else if (agendatype.ToString() == "2")
        {
            agendatypestring = "Kleintje";
        }
        else if (agendatype.ToString() == "3")
        {
            agendatypestring = "Vrijhouden";
        }
        return agendatypestring;
    }

    protected void DeleteButton_Command(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt16(e.CommandArgument);
        SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();
        var agendaitem = (from a in db.agendas
                          where a.id == id
                          select a).First();
        if (User.Identity.Name == "brend" && agendaitem.agendatype == 2) {
            agendaitem = null;
        }
                              
        db.agendas.DeleteOnSubmit(agendaitem);
        db.SubmitChanges();

        MailMessage message = new MailMessage();

        // message.To.Add(new MailAddress("andre.mulder@gmail.com"));


        
        if (agendaitem.agendatype == 1) {
            message.To.Add(new MailAddress("andre.mulder@gmail.com"));
            message.To.Add(new MailAddress("deborah_v_d_molen@hotmail.com"));
            message.To.Add(new MailAddress("erwin@pb-sunshine.nl"));
            message.To.Add(new MailAddress("sheen2108@gmail.com"));
        }
        else if (agendaitem.agendatype == 2)
        {
            message.To.Add(new MailAddress("andre.mulder@gmail.com"));
            message.To.Add(new MailAddress("deborah_v_d_molen@hotmail.com"));
            message.To.Add(new MailAddress("erwin@pb-sunshine.nl"));
            
        }
       
        
        

        message.Subject = User.Identity.Name + " heeft een optreden verwijderd.";
        message.Body = "Hint: Klik niet op de tijden hieronder. De Sunshine agenda is al bijgewerkt! <BR /><BR />";

        message.Body += "Datum: " + agendaitem.datum.ToString("dd-MM-yyyy") + "<BR />";
        message.Body += "Adres: " + agendaitem.adres + "<BR />";
        message.Body += "Omschrijving: " + agendaitem.omschrijving + "<BR />";

        if (agendaitem.openbaar == true)
        {
            message.Body += "Openbaar: Ja";
        }
        else
        {
            message.Body += "Openbaar: Nee";
        }

        message.Body += "<br />";

        message.Body += "Van: " + agendaitem.van.Value.ToString(@"hh\:mm") + "<BR />";
        message.Body += "Tot: " + agendaitem.tot.Value.ToString(@"hh\:mm") + "<BR />";
        message.Body += "<BR />";

        message.IsBodyHtml = true;

        GoogleMail gmail = new GoogleMail();

        // SmtpClient smtp = new SmtpClient();

        
        // smtp.Send(message);
        gmail.sendMail(message);
        

        GoogleAgenda googleAgenda = null;

        if (agendaitem.agendatype == 1) {
            googleAgenda = new GoogleAgenda("Sunshine");
        }
        else if (agendaitem.agendatype == 2)
        {
            googleAgenda = new GoogleAgenda("KleintjeSunshine");
        }

        
        googleAgenda.DeleteEvent(agendaitem.googleAgendaSynchId);

        Server.Transfer("Agenda.aspx", false);
    }
}