<%@ Page Title="" Language="C#" MasterPageFile="~/Sunshine.master" AutoEventWireup="true" CodeFile="AgendaAdd.aspx.cs" Inherits="AgendaAdd" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="noindex, follow">
    <script src="Scripts/jquery-ui-1.11.4.min.js"></script>
    <script src="Scripts/datepicker-nl.js"></script>
    <script src="Scripts/jquery-ui-timepicker-addon.min.js"></script>
    <script src="Scripts/i18n/jquery-ui-timepicker-nl.js"></script>    
    <link href="Content/themes/base/all.css" rel="stylesheet" />
    <link href="Content/jquery-ui-timepicker-addon.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderMiddle" Runat="Server">
    <script type="text/javascript">
        $.datepicker.setDefaults($.datepicker.regional['nl']);
        $(function () {
            $("#<%=TextBoxDatum.ClientID%>").datepicker({
                minDate: 0,
                dateFormat: "dd-mm-yy"
            });

            $('#<%=TextBoxVan.ClientID%>').timepicker({
                hourMin: 8,
                hourMax: 23,
                timeFormat: "HH:mm",

                stepMinute: 15,
            });
            $('#<%=TextBoxTot.ClientID%>').timepicker({
                hourMin: 0,
                hourMax: 23,
                timeFormat: "HH:mm",
                stepMinute: 15,
            });
            
           

        });



    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBvAD2FvyX_t4xXAd4z9MDcnaYsAaDTGoY&&libraries=places" type="text/javascript"></script>
    <script type="text/javascript">
        google.maps.event.addDomListener(window, 'load', function () {
            var places = new google.maps.places.Autocomplete(document.getElementById('<%=TextBoxAdres.ClientID%>'));
            google.maps.event.addListener(places, 'place_changed', function () {
                var place = places.getPlace();
                var address = place.formatted_address;
                // var latitude = place.geometry.location.A;
                // var longitude = place.geometry.location.F;
                // var mesg = "Address: " + address;
                // mesg += "\nLatitude: " + latitude;
                // mesg += "\nLongitude: " + longitude;
                // alert(mesg);
            });
        });
    </script>

    <div class="col-md-9">
        <div class="row">
            <div class="col-md-12 agenda_header">
                Nieuw optreden
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=TextBoxDatum.ClientID %>">Datum</label>
                    <asp:TextBox ID="TextBoxDatum" MaxLength="10" onkeydown="return (event.keyCode!=13);" CssClass="form-control Agenda_TextBox400" ReadOnly="false" BackColor="White" runat="server" TabIndex="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="TextBoxDatumRequiredFieldValidator" Display="Dynamic" ControlToValidate="TextBoxDatum" runat="server"  ErrorMessage="Datum is niet ingevuld."></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="TextBoxDatumCustomValidator" Display="Dynamic" OnServerValidate="TextBoxDatumCustomValidator_ServerValidate"  ControlToValidate="TextBoxDatum"  ForeColor="Red" runat="server"></asp:CustomValidator>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=TextBoxAdres.ClientID %>">Adres</label>
                    <asp:TextBox ID="TextBoxAdres" onkeydown = "return (event.keyCode!=13);" CssClass="form-control Agenda_TextBox400" runat="server" TabIndex="1"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=TextBoxOmschrijving.ClientID %>">Omschrijving</label>
                    <asp:TextBox ID="TextBoxOmschrijving" onkeydown="return (event.keyCode!=13);" CssClass="form-control Agenda_TextBox400" runat="server" TabIndex="2"></asp:TextBox>
                    <asp:requiredfieldvalidator ID="TextBoxOmschrijvingRequiredFieldValidator" ControlToValidate="TextBoxOmschrijving" Display="Dynamic" ErrorMessage="Omschrijving is niet ingevuld." ForeColor="Red" runat="server"></asp:requiredfieldvalidator>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=CheckBoxOpenbaar.ClientID %>">Openbaar</label>
                    <asp:CheckBox ID="CheckBoxOpenbaar" onkeydown="return (event.keyCode!=13);" CssClass="form-control Agenda_TextBox400" runat="server" TabIndex="3"></asp:CheckBox>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=TextBoxVan.ClientID %>">Van</label>
                    <asp:TextBox ID="TextBoxVan" MaxLength="5" CssClass="form-control Agenda_TextBox400" BackColor="White" runat="server" TabIndex="4"></asp:TextBox>
                    <asp:CustomValidator ID="TextBoxVanCustomValidator" ControlToValidate="TextBoxVan" Display="Dynamic" OnServerValidate="TextBoxTimeCustomValidator_ServerValidate" ErrorMessage="Geen geldige tijd ingevuld. Formaat is 00:00." ForeColor="Red" runat="server"></asp:CustomValidator>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=TextBoxTot.ClientID %>">Tot</label>
                    <asp:TextBox ID="TextBoxTot" MaxLength="5" CssClass="form-control Agenda_TextBox400" BackColor="White" runat="server" TabIndex="5"></asp:TextBox>
                    <asp:CustomValidator ID="TextBoxTotCustomValidator" ControlToValidate="TextBoxTot" Display="Dynamic" OnServerValidate="TextBoxTimeCustomValidator_ServerValidate" ErrorMessage="Geen geldige tijd ingevuld. Formaat is 00:00" ForeColor="Red" runat="server"></asp:CustomValidator>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=DropDownAgendatype.ClientID %>">Agenda</label>
                    <asp:DropDownList ID="DropDownAgendatype" MaxLength="5" CssClass="form-control Agenda_Dropdown200" BackColor="White" runat="server" TabIndex="6">
                        <asp:ListItem Value="1" Text="Sunshine" />
                        <asp:ListItem Value="3" Text="Vrijhouden" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-md-12">
                <asp:Button ID="ButtonOpslaan" OnClick="ButtonOpslaan_Click" CssClass="btn btn-default" runat="server" Text="Opslaan" TabIndex="6" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="FooterPlaceHolder" Runat="Server">
</asp:Content>