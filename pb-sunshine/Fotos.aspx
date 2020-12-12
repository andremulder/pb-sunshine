<%@ Page Title="" Language="C#" MasterPageFile="~/Sunshine.master" AutoEventWireup="true" CodeFile="Fotos.aspx.cs" Inherits="Fotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Foto's van partyband Sunshine</title>
    <meta name="Author" content="André Mulder" />
    <meta name="Subject" content="Bekijk foto's van Partyband Sunshine" />
    <meta name="Description" id="MetaDescription1" content="Bekijk hier het fotoboek van Party-Band Sunshine" runat="server" />
    <meta name="Keywords" id="MetaKeywords1" content="party, band, partyband, sunshine, foto, fotos, foto's, groningen, bruiloft, personeelsfeest, orkest sunshine, Orkest, Sunshine, Orkest Sunshine, Leek, Feesttent, Allround, Top 100, Amusements Orkest, Pinksteren, Pinkstermarkt, Bruiloft, Muziek, Feestweek, Personeelsfeest" />
    <meta name="Robots" id="MetaFollow" content="index,follow" runat="server" />  
    <link rel="stylesheet" href="Content/prettyPhoto.css" type="text/css" media="screen" charset="utf-8" />    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="server">
    <div class="col-md-3 hidden-xs hidden-sm">
        <div id="fb-root"></div>
            <script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/nl_NL/sdk.js#xfbml=1&version=v2.5";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
            <div class="fb-page" data-href="https://www.facebook.com/partybandsunshineNL/" data-tabs="timeline" data-small-header="true" data-adapt-container-width="true" data-hide-cover="true" data-show-facepile="true"><div class="fb-xfbml-parse-ignore"><blockquote cite="https://www.facebook.com/partybandsunshineNL/"><a href="https://www.facebook.com/partybandsunshineNL/">Partyband Sunshine</a></blockquote></div>

        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">

    

    <div class="col-md-9">
        <div class="row">
            <div class="col-md-12 foto_header">
                <h1>Foto's</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <a href="Images/BandfotoSunshine.png" rel="prettyPhoto[pp_gal]" title="Bandfoto Partyband Sunshine">
                    <img src="Images/BandfotoSunshine_thumb.png" alt="" />
                </a>
                
            </div>
        </div>
    
<asp:Repeater ID="RepeaterFotoAlbum" runat="server">
    <HeaderTemplate>
        <div class="row">
            <div class="col-md-12">
                Album
            </div>
        
        </div>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="row">
            <div class="col-md-12">
                <a href="Fotos.aspx?album_id=<%# Eval("album_id") %>"><%# Eval("naam") %></a>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

<asp:Repeater ID="RepeaterFotoThumbnails" runat="server">
    <HeaderTemplate>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="LabelAlbumDisplayNaam" CssClass="album_header" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </HeaderTemplate>
    <ItemTemplate>
        <%# (Container.ItemIndex + 4) % 4 == 0 ? "<div class=\"row\" style=\"margin-bottom:10px\">" : string.Empty %>
            <div class="col-md-3">
                <a href='<%# String.Format("/fotos/{0}/{1}",Eval("a.fotomap"),Eval("f.bestandsnaam"))%>' rel="prettyPhoto[pp_gal]" title="<%# Eval("a.naam") %>">
                    <img src='<%# String.Format("/fotos/{0}/thumbs/{1}",Eval("a.fotomap"),Eval("f.bestandsnaam"))%>'alt="" />
                </a>
            </div>
        <%# (Container.ItemIndex + 4) % 4 == 3 ? "</div>" : string.Empty %>
    </ItemTemplate>
    <FooterTemplate>
        <div class="row">
            <div class="col-md-12">
                <asp:LinkButton ID="LinkButtonFotoAlbums" PostBackUrl="~/Fotos.aspx" Text="Ga terug naar fotoalbums" runat="server">Ga terug naar fotoalbums</asp:LinkButton>
            </div>
        </div>                    
    </FooterTemplate>
</asp:Repeater>
    </div>
     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterPlaceholder" runat="server">
       <script src="Scripts/jquery.prettyPhoto.js" type="text/javascript" charset="utf-8"></script>
       <script type="text/javascript" charset="utf-8">
           $(document).ready(function () {
               $("a[rel^='prettyPhoto']").prettyPhoto();
           });
    </script>   
</asp:Content>