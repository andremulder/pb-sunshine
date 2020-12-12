using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Bandleden : System.Web.UI.Page
{

    

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            
            BindData();
        }
    }


    public string BiografieTekst(string tekst)
    {
        tekst = tekst.Replace(System.Environment.NewLine,"<br />");
        return tekst;
    }

    public string BiografieTitel(int id)
    {
        
        if (id == 1)
        {
            return "Toetsenist en zanger: Andre Mulder";
        }
        else if (id == 2) {
            return "Drummer en zanger: Erwin Rosema";
        }
        else if (id == 3)
        {
            return "Zangeres: Deborah van der Molen";
        }
        else if (id == 4)
        {
            return "Gitarist: Brend De Vries";
        }
        else
        {
            return "";
        }
    }




    void BindData()
    {
        SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();
        var bandleden = db.bandledens;

        DataListBandLeden.DataSource = bandleden;
        DataListBandLeden.DataBind();
    }
    

    protected void DataListBandLeden_EditCommand(Object sender, DataListCommandEventArgs e)
    {        
        DataListBandLeden.EditItemIndex = e.Item.ItemIndex;
        BindData();
               

    }

    protected void DataListBandLeden_CancelCommand(Object sender, DataListCommandEventArgs e)
    {

        // Set the EditItemIndex property to -1 to exit editing mode. Be sure
        // to rebind the DataList to the data source to refresh the control.
        // ItemsList.EditItemIndex = -1;
        // BindList();

    }

    protected void DataListBandLeden_UpdateCommand(Object sender, DataListCommandEventArgs e)
    {
        if (User.IsInRole("Bandleden")) {
        
            TextBox biografietekst = ((TextBox)e.Item.FindControl("BioGrafieTextBox"));
            string bandlididstring = ((Label)e.Item.FindControl("BandlidId")).Text;
            FileUpload ImageBandLidNew = ((FileUpload)e.Item.FindControl("ImageBandLidNew"));
            string BandlidImageName = ((Label)e.Item.FindControl("BandlidImageName")).Text;
            Image ImageBandLidOld = ((Image)e.Item.FindControl("ImageBandLidOld"));
            
            int bandlidid = 0;
            int.TryParse(bandlididstring, out bandlidid);
        
            if (ImageBandLidNew.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(ImageBandLidNew.FileName);
                    if (ImageBandLidNew.PostedFile.ContentType == "image/jpeg")
                    {
                        string savePath = System.Web.HttpContext.Current.Server.MapPath("~") + "Images\\Bandleden\\"+BandlidImageName;
                        ImageBandLidNew.SaveAs(savePath);
                        ImageBandLidOld.ImageUrl = ImageBandLidOld.ImageUrl + "?" + DateTime.Now;
                    
                    }
                
                
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();
            var bandlid = db.bandledens.Where(item => item.id == bandlidid).FirstOrDefault();

            bandlid.biografie = biografietekst.Text;
            bandlid.foto = BandlidImageName;

            db.SubmitChanges();

            DataListBandLeden.EditItemIndex = -1;

            BindData();
        }

    }

    
    protected void DataListBandLeden_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.EditItem)
        {
            TextBox txt = (TextBox)e.Item.FindControl("BioGrafieTextBox");
            txt.Focus();
        }
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (User.IsInRole("Bandleden"))
            {
                bool showEditButton = false;
                if (e.Item.ItemIndex == 0 && User.Identity.Name == "andre")
                {
                    showEditButton = true;
                }
                if (e.Item.ItemIndex == 1 && User.Identity.Name == "erwin")
                {
                    showEditButton = true;
                }
                if (e.Item.ItemIndex == 2 && User.Identity.Name == "deborah")
                {
                    showEditButton = true;
                }
                if (e.Item.ItemIndex == 3 && User.Identity.Name == "brend")
                {
                    showEditButton = true;
                }

                if (showEditButton == true)
                {
                    LinkButton EditButton = ((LinkButton)e.Item.FindControl("EditButton"));
                    EditButton.Enabled = true;
                    EditButton.Visible = true;
                }                
            }
            if (User.IsInRole("Administrators"))
            {
                LinkButton EditButton = ((LinkButton)e.Item.FindControl("EditButton"));
                EditButton.Enabled = true;
                EditButton.Visible = true;
            }
            
        }
    }
}