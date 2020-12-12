<%@ Page Title="" Language="C#" MasterPageFile="~/Sunshine.master" AutoEventWireup="true" CodeFile="Links.aspx.cs" Inherits="Links" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Linkpagina Partyband Sunshine</title>
    <meta name="Author" content="André Mulder" />
    <meta name="Subject" content="Party-Band Sunshine, de bruiloftband, feesttentband, feestweekband van Friesland, Groningen en Drenthe" />
    <meta name="Description" content="Dit is de linkpagina van partyband Sunshine" />
    <meta name="Keywords" content="party, band, partyband, sunshine, groningen, bruiloft, personeelsfeest, orkest sunshine, Orkest, Sunshine, Orkest Sunshine, Leek, Feesttent, Allround, Top 100, Amusements Orkest, Pinksteren, Pinkstermarkt, Bruiloft, Muziek, Feestweek, Personeelsfeest" />
    <meta name="Robots" content="index,follow" />   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="server">
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
            <div class="col-md-12 links_header">
                <h1>Linkpagina Partyband Sunshine</h1>
            </div>
        </div>
        <div class="row linkcategorie">
            <div class="col-md-12">
                CollegaBands
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:HyperLink ID="HyperLink1" Target="_blank" NavigateUrl="http://www.acapulco.in/" runat="server">Duo Acapulco</asp:HyperLink><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:HyperLink ID="HyperLink2" Target="_blank" NavigateUrl="http://www.smildegerroet.nl/" runat="server">SmildegerRoet</asp:HyperLink><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:HyperLink ID="HyperLink3" Target="_blank" NavigateUrl="http://www.jukeboxband.nl/" runat="server">Partyband Jukebox</asp:HyperLink><br />
            </div>
        </div>
        <div class="row linkcategorie">
            <div class="col-md-12">
                Kroegen / Zalen
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:HyperLink ID="HyperLink4" Target="_blank" NavigateUrl="http://www.feestinleek.nl/" runat="server">Cafe Restaurant Max Otter</asp:HyperLink><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:HyperLink ID="HyperLink5" Target="_blank" NavigateUrl="http://www.postwagen.nl/" runat="server">Zalencentrum De Postwagen</asp:HyperLink><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:HyperLink ID="HyperLink6" Target="_blank" NavigateUrl="http://www.kruiswegmarum.nl/" runat="server">Horecacentrum Kruisweg Marum</asp:HyperLink><br />
            </div>
        </div>
        <div class="row linkcategorie">
            <div class="col-md-12">
                Boekingbureaus
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:HyperLink ID="HyperLink7" Target="_blank" NavigateUrl="http://www.bemo-entertainment.nl/" runat="server">BEMO entertainment</asp:HyperLink><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:HyperLink ID="HyperLink8" Target="_blank" NavigateUrl="http://www.jongbookings.nl/" runat="server">Jongbookings</asp:HyperLink><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:HyperLink ID="HyperLink10" Target="_blank" NavigateUrl="http://www.allesentertainment.nl/" runat="server">Alles Entertainment</asp:HyperLink><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:HyperLink ID="HyperLink11" Target="_blank" NavigateUrl="http://www.defeestdokter.nl/" runat="server">De FeestDokter</asp:HyperLink><br />
            </div>
        </div>
         <div class="row">
            <div class="col-md-12">
                 &nbsp;
            </div>
        </div>       
        <div class="row">
            <div class="col-md-12">
                 Staat jouw link er niet bij? Neem dan <asp:HyperLink ID="HyperLink9" Target="_blank" NavigateUrl="~/Contact.aspx" CssClass="HyperLinkContact" runat="server">contact</asp:HyperLink> met ons op.
            </div>
        </div>  
        <div class="row linkcategorie">
            <div class="col-md-12">
                Overige websites
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:HyperLink ID="HyperLink13" Target="_blank" NavigateUrl="http://bruiloftbands.startkabel.nl/" runat="server">Bruilofts-band startkabel</asp:HyperLink><br />
            </div>
        </div>     
    </div>    
</asp:Content>

