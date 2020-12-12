<%@ Page Title="" Language="C#" MasterPageFile="~/Sunshine.master" AutoEventWireup="true" CodeFile="Gastenboek_NieuwBericht.aspx.cs" Inherits="Gastenboek_NieuwBericht" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Plaats een bericht in het gastenboek van Sunshine</title>
    
    </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="Server">
    <div class="col-md-9">
        <div class="row">
            <div class="col-md-12 gastenboek_nieuwbericht_header">
                <h1>Laat een bericht achter in het gastenboek van Partyband Sunshine</h1>
            </div>
        </div>
        
        <div class="row">
            <div class="form-group">
                <div class="col-md-3">       
                    <label class="control-label" for="NaamField">Naam:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="NaamField"  MaxLength="100" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNaam" runat="server" ControlToValidate="NaamField" SetFocusOnError="True" ToolTip="Naam verplicht"></asp:RequiredFieldValidator>
                </div>          
            </div>
        </div>

        <div class="row">
            <div class="form-group">
                <div class="col-md-3">
                    <label class="control-label" for="EmailField">Email:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="EmailField" MaxLength="100" CssClass="form-control" runat="server" />
                </div>
            </div>            
        </div>

        <div class="row">
            <div class="form-group">
                <div class="col-md-3">
                    <label class="control-label" for="WebsiteField">Website:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="WebsiteField" MaxLength="100" CssClass="form-control" runat="server" />
                </div>            
            </div>
        </div>

        <div class="row">
            <div class="form-group">
                <div class="col-md-3">
                     <label class="control-label" for="WoonplaatsField">Woonplaats:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="WoonplaatsField" MaxLength="100" CssClass="form-control" runat="server" />
                </div>
            </div>            
        </div>

        <div class="row">
            <div class="col-md-3">
                &nbsp;
            </div>
            <div class="col-md-9">
                <div class="form-group">
                    <img src="Images/gbook/smilies/autsch.gif" ID="autsch" alt="autsch" title="autsch" onclick="javascript:AddSmile('autsch')" />&nbsp;
                    <img src="Images/gbook/smilies/bunny.gif" ID="bunny" alt="bunny" title="bunny" onclick="javascript:AddSmile('bunny')" />&nbsp;
                    <img src="Images/gbook/smilies/chair.gif" ID="chair" alt="chair" title="chair" onclick="javascript:AddSmile('chair')" />&nbsp;
                    <img src="Images/gbook/smilies/cheers.gif" ID="cheers" alt="cheers" title="cheers" onclick="javascript:AddSmile('cheers')" />&nbsp;
                    <img src="Images/gbook/smilies/dance.gif" ID="dance" alt="dance" title="dance" onclick="javascript:AddSmile('dance')" />&nbsp;
                    <img src="Images/gbook/smilies/drunk.gif" ID="drunk" alt="drunk" title="drunk" onclick="javascript:AddSmile('drunk')" />&nbsp;
                    <img src="Images/gbook/smilies/whistling.gif" ID="whistling" alt="whistling" title="whistling" onclick="javascript:AddSmile('whistling')" />&nbsp;
                    <img src="Images/gbook/smilies/friends.gif" ID="friends" alt="friends" title="friends" onclick="javascript:AddSmile('friends')" />&nbsp;
                    <img src="Images/gbook/smilies/hairpull.gif" ID="hairpull" alt="hairpull" title="hairpull" onclick="javascript:AddSmile('hairpull')" />&nbsp;
                    <img src="Images/gbook/smilies/laughathim.gif" ID="laughathim" alt="laughathim" title="laughathim" onclick="javascript:AddSmile('laughathim')" />&nbsp;
                    <img src="Images/gbook/smilies/shake.gif" ID="shake" alt="shake" title="shake" onclick="javascript:AddSmile('shake')" />&nbsp;
                    <img src="Images/gbook/smilies/taunt.gif" ID="taunt" alt="taunt" title="taunt" onclick="javascript:AddSmile('taunt')" />&nbsp;
                    <img src="Images/gbook/smilies/thanks.gif" ID="thanks" alt="thanks" title="thanks" onclick="javascript:AddSmile('thanks')" />&nbsp;   
                </div>
            </div>
        </div>

        <div class="row">
            <div class="md-12">
                &nbsp;
            </div>
        </div>

        <div class="row">
            <div class="form-group">
                <div class="col-md-3">
                    <label class="control-label" for="BerichtField">Bericht:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="BerichtField" TextMode="MultiLine" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorBericht"  runat="server" ErrorMessage="" ControlToValidate="BerichtField" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                &nbsp;
            </div>
        </div>

        <div class="row">
            <div class="form-group">
                <div class="col-md-3">
                    <asp:Image ID="imgCaptcha" ImageUrl="Captcha.ashx" runat="server" />
                </div>
                <div class="col-md-9">
                    <div class="row">
                        <div class="col-md-12">
                            Neem de symbolen over van het plaatje
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:TextBox ID="txtCaptcha" CssClass="form-control" MaxLength="10" runat="server" />
                        </div>

                    </div>
                    
                </div>
            </div>
        </div>  
        
        <div class="row">
            <div class="col-md-12">
                &nbsp;
            </div>
        </div>     

        <div class="row">
            <div class="form-group">
                <div class="col-md-3">
                    &nbsp;
                </div>
                <div class="col-md-9">
                    <asp:Button ID="VerstuurBericht" Width="100" CssClass="form-control" Text="Verstuur" OnClick="VerstuurBericht_Click" runat="server" Enabled="true" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">&nbsp;</div>
        </div>
    </div>
    
</asp:Content>

<asp:Content ContentPlaceHolderID="FooterPlaceHolder" runat="server">

<script type="text/javascript">

    $(document).ready(function () {

        $('#<%=BerichtField.ClientID%>').keypress(function (e) {
                var MaxLength = 250;
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

        function AddSmile(text) {
            var berichtFieldId = "ContentPlaceHolderMiddle_BerichtField";
            var TheTextBox = document.getElementById(berichtFieldId);
            TheTextBox.value = TheTextBox.value + ':' + text + ':';
        }
    </script>
                
    </asp:Content>