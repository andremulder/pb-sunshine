<%@ Page Title="" Language="C#" MasterPageFile="~/Sunshine.master" AutoEventWireup="true" CodeFile="AgendaEdit.aspx.cs" Inherits="AgendaEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="noindex, follow">
    <script src="Scripts/jquery-ui-1.11.4.min.js"></script>
    <script src="Scripts/datepicker-nl.js"></script>
    <script src="Scripts/jquery-ui-timepicker-addon.min.js"></script>
    <script src="Scripts/i18n/jquery-ui-timepicker-nl.js"></script>    
    <link href="Content/themes/base/all.css" rel="stylesheet" />
    <link href="Content/jquery-ui-timepicker-addon.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMiddle" Runat="Server">
    <asp:Panel ID="AgendaResultPanel" runat="server">
        <script>

            $.datepicker.setDefaults($.datepicker.regional['nl']);            

            $(function () {                
                $("#<%=TextBoxDatum.ClientID%>").datepicker({
                    minDate: 0
                });

                $('#<%=TextBoxVan.ClientID%>').timepicker(
                    {
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
                    var latitude = place.geometry.location.A;
                    var longitude = place.geometry.location.F;
                    var mesg = "Address: " + address;
                    // mesg += "\nLatitude: " + latitude;
                    // mesg += "\nLongitude: " + longitude;
                    // alert(mesg);
                });
            });
        </script>

        <div class="col-md-9">
            <div class="row">
                <div class="col-md-12 agenda_header">
                    Bewerk Optreden
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="<%=TextBoxDatum.ClientID %>">Datum</label>
                        <asp:TextBox ID="TextBoxDatum" onkeydown = "return (event.keyCode!=13);" CssClass="form-control Agenda_TextBox400" ReadOnly="false" BackColor="White" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="<%=TextBoxAdres.ClientID %>">Adres</label>
                        <asp:TextBox ID="TextBoxAdres" onkeydown = "return (event.keyCode!=13);" CssClass="form-control Agenda_TextBox400" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="<%=TextBoxOmschrijving.ClientID %>">Omschrijving</label>
                        <asp:TextBox ID="TextBoxOmschrijving" onkeydown = "return (event.keyCode!=13);" CssClass="form-control Agenda_TextBox400" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="<%=CheckBoxOpenbaar.ClientID %>">Openbaar</label>
                        <asp:CheckBox ID="CheckBoxOpenbaar" onkeydown = "return (event.keyCode!=13);" CssClass="form-control Agenda_TextBox400" runat="server"></asp:CheckBox>
                    </div>
                </div>
                 <div class="col-md-12">
                    <div class="form-group">
                        <label for="<%=TextBoxVan.ClientID %>">Van</label>
                        <asp:TextBox ID="TextBoxVan" onkeydown = "return (event.keyCode!=13);" CssClass="form-control Agenda_TextBox400" ReadOnly="false" BackColor="White" runat="server"></asp:TextBox>&nbsp;
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="<%=TextBoxTot.ClientID %>">Tot</label>
                        <asp:TextBox ID="TextBoxTot" onkeydown = "return (event.keyCode!=13);" CssClass="form-control Agenda_TextBox400" ReadOnly="false" BackColor="White" runat="server"></asp:TextBox>&nbsp;
                    </div>
                </div>

                <div class="col-md-12">
                    <asp:Button ID="ButtonOpslaan" OnClick="ButtonOpslaan_Click" CssClass="btn btn-default" runat="server" Text="Opslaan" />
                </div>
                
                <asp:HiddenField ID="HiddenFieldGoogleAgendaID" runat="server"></asp:HiddenField>&nbsp;
                <asp:HiddenField ID="HiddenFieldAgendaType" runat="server"></asp:HiddenField>&nbsp;
                           
                
            </div>
        </div>
        </asp:Panel>
        <asp:Panel ID="AgendaNoResultsPanel" runat="server">
            
        </asp:Panel>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterPlaceHolder" Runat="Server">
</asp:Content>

