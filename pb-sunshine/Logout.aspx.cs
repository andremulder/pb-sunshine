﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        FormsAuthentication.SignOut();

        Response.Redirect("default.aspx");
    }

    protected void Page_Init(object sender, EventArgs e)
    {

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1)); Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

    }
}