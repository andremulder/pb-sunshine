using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Fotos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        

        if (Request.QueryString["album_id"] != null && Request.QueryString["foto_id"] != null)
        {
            // loadFotoThumbnails();
        }
        
        else if (Request.QueryString["album_id"] != null)
        {
            int albumid;
            try
            {
                albumid = Convert.ToInt32(Request.QueryString["album_id"]);
            }
            catch 
            {
                throw new Exception("Dit album bestaat niet.");
            }
            loadFotoThumbnails(albumid);
        }
        else
        {
            loadFotoAlbums();
        }
    }

    private void loadFotoThumbnails(int albumid)
    {

        SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();

        var fotoresults = (from f in db.fotos
                           join a in db.fotoalbums on f.album_id equals a.album_id
                           where f.album_id == a.album_id && f.album_id == albumid
                           select new { f, a });

        RepeaterFotoThumbnails.DataSource = fotoresults;
        RepeaterFotoThumbnails.DataBind();
        RepeaterFotoThumbnails.Visible = true;

        Label LabelAlbumDisplayNaam = ((Label)RepeaterFotoThumbnails.Controls[0].FindControl("LabelAlbumDisplayNaam"));

        LabelAlbumDisplayNaam.Text = getAlbumDisplayNaam(albumid);
    }

    

    private void loadFotoAlbums()
    {

        SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();
        var fotoabums = db.fotoalbums;
        RepeaterFotoAlbum.DataSource = fotoabums;
        RepeaterFotoAlbum.DataBind();

        RepeaterFotoThumbnails.Visible = false;

    }

    public string getAlbumDisplayNaam(int albumid)
    {
        SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();
        var fotoAlbums = db.fotoalbums;
        var fotoalbum = fotoAlbums.Where(item => item.album_id == albumid).FirstOrDefault();
        string albumdisplaynaam = fotoalbum.naam;
        return albumdisplaynaam;
    }

    public string getAlbumMapNaam(int albumid)
    {

        SunshineDatabaseDataContext db = new SunshineDatabaseDataContext();
        var albumTable = db.fotoalbums;

        var fotoalbum = albumTable.Where(item => item.album_id == albumid).FirstOrDefault();

        string albummapnaam = fotoalbum.fotomap;
        return albummapnaam;
    }




    protected void ThumbnailButton_Click(object sender, ImageClickEventArgs e)
    {
        
    }
}