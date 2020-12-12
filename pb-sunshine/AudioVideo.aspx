<%@ Page Title="" Language="C#" MasterPageFile="~/Sunshine.master" AutoEventWireup="true" CodeFile="AudioVideo.aspx.cs" Inherits="AudioVideo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Audio / Video</title>
    <meta name="Author" content="André Mulder" />
    <meta name="Subject" content="Audio en videofragmenten" />
    <meta name="Description" content="Bekijk hier audio en video fragmenten van Party-band Sunshine" />
    <meta name="Keywords" content="Partyband, Sunshine, audio, video, youtube, groningen, friesland, drenthe" />
    <meta name="Robots" id="MetaFollow" content="index,follow" runat="server" />    
        
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
            <div class="col-md-12 audiovideo_header"><h1>Audio/Video</h1></div>
        </div>
        <div class="row">
            <div class="col-md-12">
                Wilt u een keer komen kijken / luisteren tijdens 1 van onze optredens of in onze oefenruimte?<br />
                <br />
                <asp:HyperLink ID="HyperLinkContact" runat="server" NavigateUrl="~/Contact.aspx" CssClass="HyperLinkContact">Informeer</asp:HyperLink>&nbsp;naar de mogelijkheden<br />
                <br />
                Een gooi uit het repertoire van Sunshine:<br />
                <br />
                - Bryan Adams: Summer of &#39;69<br />
                - Grease: You&#39;re the one that I want<br />
                - Blues Brothers: Everybody needs somebody to love<br />
                - Anouk: Girl<br />
                - Status Quo: Rocking all over the world<br />
                - Tina Turner: Proud Mary <br />
                - Nick en Simon: Rosanne
                <br /><br />
                En nog vele anderen,
                <br /><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="embed-responsive embed-responsive-16by9">
                    <iframe src="https://www.youtube.com/embed/T_aE3O98Qck" allowfullscreen="allowfullscreen" mozallowfullscreen="mozallowfullscreen" msallowfullscreen="msallowfullscreen" oallowfullscreen="oallowfullscreen" webkitallowfullscreen="webkitallowfullscreen"></iframe>
                </div>
            </div>
            <div class="col-md-6">
                 <div class="embed-responsive embed-responsive-16by9">
                    <iframe src="https://www.youtube.com/embed/LXaGyFNJpnA" allowfullscreen="allowfullscreen" mozallowfullscreen="mozallowfullscreen" msallowfullscreen="msallowfullscreen" oallowfullscreen="oallowfullscreen" webkitallowfullscreen="webkitallowfullscreen"></iframe>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">&nbsp;</div>
        </div>
        <div class="row">
            <div class="col-md-12">
                Het repetoire van Sunshine bevat meer dan 200 nummers!<br />
                Voor meer video's, kijk op <asp:HyperLink ID="HyperLinkContact2" runat="server" NavigateUrl="https://www.facebook.com/search/videos/?q=partyband%20Sunshine" CssClass="HyperLinkContact" Target="_blank">Facebook</asp:HyperLink>
            </div>
        </div>
    </div>
    
</asp:Content>
