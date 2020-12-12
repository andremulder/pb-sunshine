<%@ Page Title="" Language="C#" MasterPageFile="~/Sunshine.master" AutoEventWireup="true" CodeFile="Gastenboek.aspx.cs" Inherits="Gastenboek" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Gastenboek van Partyband Sunshine</title>
    <meta name="Author" content="André Mulder" />
    <meta name="Subject" content="Party-Band Sunshine, de bruiloftband, feesttentband, feestweekband van Friesland, Groningen en Drenthe" />
    <meta name="Description" id="MetaDescription1" content="Gastenboek van Partyband Sunshine" runat="server" />
    <meta name="Keywords" id="MetaKeywords1" content="party, band, partyband, sunshine, gastenboek, groningen, bruiloft, personeelsfeest, orkest sunshine, Orkest, Sunshine, Orkest Sunshine, Leek, Feesttent, Allround, Top 100, Amusements Orkest, Pinksteren, Pinkstermarkt, Bruiloft, Muziek, Feestweek, Personeelsfeest" />
    <meta name="Robots" id="MetaFollow" content="index,follow" runat="server" />   
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="Server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="Server">
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-3">&nbsp;</div>
            <div class="col-md-9">
                <div class="row">
                    <div class="col-md-12 gastenboek_header">
                        <h1>Gastenboek van Partyband Sunshine</h1>
                    </div>
                </div>
                <div class="row">
                     <div class="col-md-12">
                         <asp:LinkButton ID="NieuwBerichtButton" CssClass="btn btn-default" ForeColor="Red" PostBackUrl="Gastenboek_NieuwBericht.aspx"  runat="server" Text="Plaats Bericht" Enabled="true" />
                    </div>
                </div>
            </div>
        </div>
        <asp:Repeater runat="server" ID="gastenboek_Repeater" EnableViewState="true" OnItemCommand="ItemCommand">
            <HeaderTemplate>
        <div class="row GastenboekRijHeader">
            <div class="col-md-3 col-sm-3 col-xs-3"><strong>Naam</strong></div>
            <div class="col-md-9 col-sm-9 col-xs-9"><strong>Bericht</strong></div>
        </div>
            </HeaderTemplate>
            <ItemTemplate>
        <div class='row GastenboekRij<%# Container.ItemIndex % 2 == 0 ?  "Even" : "Odd"  %>'> 
            <div class="col-md-3 col-sm-3 col-xs-3">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Image ID="IpImage" runat="server" ImageUrl="~/Images/gbook/browser.gif" Visible='<%# ShowImageIp(Eval("ip"))%>' />
                        <asp:Image ID="BrowserImage" runat="server" ImageUrl="~/Images/gbook/ip_log.gif" Visible='<%# ShowImageBrowser(Eval("browser"))%>' />
                        <asp:HyperLink NavigateUrl='<%#GetUrlWebSite(Eval("website")) %>' ImageUrl="~/Images/gbook/home.gif" Target="_blank" Visible='<%# ShowImageWebsite(Eval("website"))%>' runat="server" />                                          
                        <asp:LinkButton ID="DeleteButton" OnClientClick="return confirm('Weet je zeker dat je dit bericht wilt verwijderen?');" CssClass="ButtonDelete" Enabled="<%# CheckDeletePermission() %>" Visible="<%# CheckDeletePermission() %>" CommandArgument='<%# Eval("id") %>' CommandName="DeleteMessage" ToolTip="Verwijder bericht" runat="server" ForeColor="Red">
                            <asp:Image ID="Image2" ImageUrl="~/Images/DeleteButton.png" Width="20px" Height="20px" runat="server" />
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        Naam: <asp:Label ID="naamLabel" runat="server" Text='<%# Eval("naam") %>' />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        woonplaats: <asp:Label ID="woonplaatsLabel" runat="server" Text='<%# Eval("woonplaats") %>' />
                    </div>
                </div>
            </div>
            <div class="col-md-9 col-sm-9 col-xs-9">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="datumLabel" runat="server" Text='<%# Eval("datum") %>' />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="berichtLabel" runat="server" Text='<%# GetBericht(Eval("bericht").ToString()) %>' />
                    </div>

                </div>
            </div>
        </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="row">
            <div class="col-md-3">
                <div class="row">
                    <div class="col-md-12">
                        Aantal berichten: <asp:Label ID="LabelAantalberichten" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-md-9">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lblCurrentPage" runat="server" Text="Label"></asp:Label>
                        <asp:Button ID="cmdPrev" runat="server" Text=" << "></asp:Button>
                        <asp:Button ID="cmdNext" runat="server" Text=" >> "></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
