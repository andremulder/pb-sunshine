using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Gastenboek : System.Web.UI.Page
{

    private void Page_Load(object sender, System.EventArgs e)
		{
			// Call the ItemsGet method to populate control,
			// passing in the sample data.

            cmdPrev.Click += new EventHandler(this.cmdPrev_Click);
            cmdNext.Click += new EventHandler(this.cmdNext_Click);

			loadData();
		}

    private void loadData()
    {
        // Populate the repeater control with the Items DataSet
        PagedDataSource objPds = new PagedDataSource();

        SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();
        var gastenboektable = db.gastenboeks;

        LabelAantalberichten.Text = gastenboektable.Count().ToString();

        objPds.DataSource = gastenboektable.OrderByDescending(gb => gb.datum).ToList();
        objPds.AllowPaging = true;
        objPds.PageSize = 10;

        objPds.CurrentPageIndex = CurrentPage;


        lblCurrentPage.Text = "Page: " + (CurrentPage + 1).ToString() + " of "
            + objPds.PageCount.ToString();

        // Disable Prev or Next buttons if necessary
        cmdPrev.Enabled = !objPds.IsFirstPage;
        cmdNext.Enabled = !objPds.IsLastPage;

        gastenboek_Repeater.DataSource = objPds;
        gastenboek_Repeater.DataBind();

        

    }
    

		private void cmdPrev_Click(object sender, System.EventArgs e)
		{
			// Set viewstate variable to the previous page
			CurrentPage -= 1;

			// Reload control
			loadData();
		}

		private void cmdNext_Click(object sender, System.EventArgs e)
		{
			// Set viewstate variable to the next page
			CurrentPage += 1;

			// Reload control
			loadData();
		}

        public int CurrentPage
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_CurrentPage"];
                if (o == null)
                    return 0;	// default to showing the first page
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_CurrentPage"] = value;
            }
        }

    protected Boolean ShowImageIp(object name) {
        if (name.ToString()=="") {
            return false;
        }
        else {
            return true;
        }
    }

    protected Boolean ShowImageBrowser(object name)
    {
        if (name.ToString() == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected Boolean CheckDeletePermission()
    {
        if (User.IsInRole("Bandleden"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected string GetUrlWebSite(object url)
    {
        
        return "http://"+url.ToString();
    }

    protected Boolean ShowImageWebsite(object name)
    {
        string url = name.ToString();
        if (url != "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected string GetBericht(string message)
    {


        message = message.Replace(@"\r\n", "<BR />");
        message = message.Replace(":autsch:", "<img src='/Images/gbook/smilies/autsch.gif' alt='autsch' />");
        message = message.Replace(":bunny:", "<img src='/Images/gbook/smilies/bunny.gif' alt='bunny' />");
        message = message.Replace(":chair:", "<img src='/Images/gbook/smilies/chair.gif' alt='chair' />");
        message = message.Replace(":cheers:", "<img src='/Images/gbook/smilies/cheers.gif' alt='cheers' />");
        message = message.Replace(":dance:", "<img src='/Images/gbook/smilies/dance.gif' alt='dance' />");
        message = message.Replace(":drunk:", "<img src='/Images/gbook/smilies/drunk.gif' alt='drunk' />");
        message = message.Replace(":friends:", "<img src='/Images/gbook/smilies/friends.gif' alt='friends' />");
        message = message.Replace(":hairpull:", "<img src='/Images/gbook/smilies/hairpull.gif' alt='hairpull' />");
        message = message.Replace(":laughathim:", "<img src='/Images/gbook/smilies/laughathim.gif' alt='laughathim' />");
        message = message.Replace(":shake:", "<img src='/Images/gbook/smilies/shake.gif' alt='shake' />");
        message = message.Replace(":taunt:", "<img src='/Images/gbook/smilies/taunt.gif' alt='taunt' />");
        message = message.Replace(":thanks:", "<img src='/Images/gbook/smilies/thanks.gif' alt='thanks' />");
        message = message.Replace(":whistling:", "<img src='/Images/gbook/smilies/whistling.gif' alt='whistling' />");
        message = message.Replace(":whoops:", "<img src='/Images/gbook/smilies/whoops.gif' alt='whoops' />");

        return message;
    }

    protected void ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteMessage")
        {
            
            int messageid = Convert.ToInt32(e.CommandArgument);
            SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();
            var gastenboektable = db.gastenboeks;

            var deleterecord = gastenboektable.Where(item => item.id == messageid).FirstOrDefault();

            gastenboektable.DeleteOnSubmit(deleterecord);

            db.SubmitChanges();

            MailMessage message = new MailMessage();

            // message.To.Add("andre.mulder@gmail.com");
            
            foreach (string username in Roles.GetUsersInRole("Bandleden"))
            {
                MembershipUser u = Membership.GetUser(username);
                message.To.Add(new MailAddress(u.Email));
            }
            

            message.Subject = "Er is een bericht verwijderd uit het gastenboek.";


            message.Body += "Naam: " + deleterecord.naam + "<BR />";
            message.Body += "Woonplaats: " + deleterecord.woonplaats + "<BR />";
            message.Body += "Datum bericht: " + deleterecord.datum.Value.ToShortDateString() + "<BR />";
            message.Body += "Bericht: " + GetBericht(deleterecord.bericht) + "<BR />";
            
            message.IsBodyHtml = true;

            // SmtpClient smtp = new SmtpClient();
            // smtp.Send(message);

            GoogleMail gmail = new GoogleMail();
            gmail.sendMail(message);

            Response.Redirect("Gastenboek.aspx");
        }
        
    }

   
		
}