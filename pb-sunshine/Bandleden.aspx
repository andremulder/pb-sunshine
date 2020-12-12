<%@ Page Title="" Language="C#" MasterPageFile="~/Sunshine.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Bandleden.aspx.cs" Inherits="Bandleden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>De bandleden van de band Sunshine</title>
    <meta name="Author" content="André Mulder" />
    <meta name="Subject" content="Biografie van de band" />
    <meta name="Description" content="Partyband Sunshine heeft 4 bandleden: Andre Mulder, Erwin Rosema, Deborah van der molen en Brend de Vries." />
    <meta name="Keywords" id="MetaKeywords1" content="party, band, partyband, sunshine, groningen, bruiloft, personeelsfeest, orkest sunshine, Orkest, Sunshine, Orkest Sunshine, Leek, Feesttent, Allround, Top 100, Amusements Orkest, Pinksteren, Pinkstermarkt, Bruiloft, Muziek, Feestweek, Personeelsfeest" />
    <meta name="Robots" id="MetaFollow" content="index,follow" />   
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
            <div class="col-md-12 bandleden_header">
                <h1>De bandleden van Partyband Sunshine</h1>
            </div>
        </div>
<asp:DataList ID="DataListBandLeden" OnItemDataBound="DataListBandLeden_ItemDataBound" OnEditCommand="DataListBandLeden_EditCommand" OnUpdateCommand="DataListBandLeden_UpdateCommand" OnCancelCommand="DataListBandLeden_CancelCommand" runat="server">
    <ItemTemplate>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="BioGrafieTitle" runat="server" Text='<%#BiografieTitel((int)Eval("id")) %>' Font-Size="16px" ForeColor="#3366CC"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Image ImageUrl='<%#String.Format("~/Images/Bandleden/{0}",Eval("foto").ToString()) %>' runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:LinkButton ID="EditButton" runat="server" CommandName="edit" Enabled="false" Visible="false">
                    <asp:Image ImageUrl="~/Images/EditButton.png" Width="64" Height="64" runat="server" />
                    <br />
                </asp:LinkButton>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12" style="margin-bottom:20px">
                <asp:Label ID="BioGrafieLabel" runat="server" Text='<%#BiografieTekst(Eval("biografie").ToString())%>'></asp:Label>
            </div>
        </div>
                    
                    
    </ItemTemplate>
    <EditItemTemplate>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="BandlidId" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="BandlidImageName" runat="server" Text='<%#Eval("foto") %>' Visible="false"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                 <asp:Label ID="BioGrafieTitle" runat="server" Text='<%#BiografieTitel((int)Eval("id")) %>'></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">

            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Image ID="ImageBandLidOld" ImageUrl='<%#String.Format("~/Images/Bandleden/{0}",Eval("foto").ToString()) %>' runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:FileUpload ID="ImageBandLidNew" Enabled="true" runat="server" />&nbsp;&nbsp;Alleen JPG bestanden zijn toegestaan.
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:TextBox TextMode="MultiLine" ID="BioGrafieTextBox" runat="server" Width="650" Height="550" Text='<%#Eval("biografie").ToString().Replace("\\r\\n",System.Environment.NewLine)%>'></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="update" Text="Opslaan" />
            </div>
        </div>                    
    </EditItemTemplate>
</asp:DataList>
    </div>    
</asp:Content>
