<%@ Page Title="" Language="C#" MasterPageFile="~/Sunshine.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Neem contact op met Partyband Sunshine</title>
    <meta name="Author" content="André Mulder" />
    <meta name="Subject" content="Contactformulier Partyband Sunshine" />
    <meta name="Description" id="MetaDescription1" content="Neem contact op met Party-band Sunshine via het contactformulier" runat="server" />
    <meta name="Keywords" id="MetaKeywords1" content="party, band, partyband, sunshine, contact, formulier, mail, email, gastenboek, groningen, bruiloft, personeelsfeest, orkest sunshine, Orkest, Sunshine, Orkest Sunshine, Leek, Feesttent, Allround, Top 100, Amusements Orkest, Pinksteren, Pinkstermarkt, Bruiloft, Muziek, Feestweek, Personeelsfeest" />
    <meta name="Robots" id="MetaFollow" content="index,follow" runat="server" />   
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>

   
    <script type="text/javascript">

        $(document).ready(function () {

            $('#<%=TextBoxBericht.ClientID%>').keypress(function (e) {
                var MaxLength = 500;
                if ($(this).val().length >= MaxLength) {
                    alert('Maximum aantal tekens: ' + MaxLength);
                    e.preventDefault();
                }
            });
        });

        function fnOnUpdateValidators() {
            for (var i = 0; i < Page_Validators.length; i++) {
                var val = Page_Validators[i];
                var ctrl = document.getElementById(val.controltovalidate);
                if (ctrl != null && ctrl.style != null) {
                    if (!val.isvalid)
                        ctrl.style.background = '#FFAAAA';
                    else
                        ctrl.style.backgroundColor = '';
                }
            }
        }
    </script>
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
        <div class="container-fluid">
            <div class="row">
                <div class="md-12 ContactHeader">
                    <h1>Contact</h1>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-12">
                        <label class="control-label" for="TextBoxNaam">Naam:</label>
                        <asp:TextBox ID="TextBoxNaam" CssClass="form-control Contact_TextBox300"  runat="server"></asp:TextBox> 
                        <asp:RequiredFieldValidator ErrorMessage="Naam is verplicht" Display="Dynamic" ForeColor="Red" ID="RequiredFieldValidatorNaam" runat="server" ControlToValidate="TextBoxNaam" SetFocusOnError="True" ToolTip="Naam verplicht"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <label class="control-label" for="TextBoxEmail">Email:</label>
                        <asp:TextBox ID="TextBoxEmail" CssClass="form-control Contact_TextBox300" runat="server" AutoCompleteType="Email"></asp:TextBox>   
                        <asp:CustomValidator ID="EmailValidator" Display="Dynamic" ErrorMessage="Geen geldig emailadres." ToolTip="Geen geldig emailadres" OnServerValidate="EmailValidator_ServerValidate" ControlToValidate="TextBoxEmail" runat="server" ValidateEmptyText="true" SetFocusOnError="true" ForeColor="Red" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <label class="control-label" for="TextBoxTelefoon">Telefoon:</label>
                        <asp:TextBox ID="TextBoxTelefoon" runat="server" CssClass="form-control Contact_TextBox300"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <label class="control-label" for="TextBoxOnderwerp">Onderwerp:</label>
                        <asp:DropDownList ID="TextBoxOnderwerp" runat="server" CssClass="form-control Contact_TextBox300">
                            <asp:ListItem Value="opmerking">Opmerking</asp:ListItem>
                            <asp:ListItem Value="vraag">Vraag</asp:ListItem>
                            <asp:ListItem Value="kosten">Informatie over kosten</asp:ListItem>
                            <asp:ListItem Value="overig">Overige</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <label class="control-label" for="TextBoxBericht">Bericht:</label>
                        <asp:TextBox ID="TextBoxBericht" TextMode="MultiLine" Height="100" CssClass="form-control Contact_TextBox300" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ForeColor="Red" ErrorMessage="Geen bericht ingevuld." ID="RequiredFieldValidatorBericht" runat="server" ControlToValidate="TextBoxBericht" SetFocusOnError="True" ToolTip="Bericht verplicht"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <div class="g-recaptcha" data-sitekey="6LcpBoMUAAAAAKy7y5ubyJ85M6aLbqvhrA2jGMGP"></div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <asp:Button ID="ButtonVerzend" Width="100" CssClass="btn btn-default" runat="server" Text="Verzend" OnClick="ButtonVerzend_Click" />
                    </div>
                </div>
                <asp:TextBox ID="TextBoxEmail2" CssClass="Contact_TextBoxHidden" runat="server"></asp:TextBox>
            </div>
        </div>           
    </div>
</asp:Content>
