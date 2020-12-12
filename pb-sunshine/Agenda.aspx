<%@ Page Title="" Language="C#" MasterPageFile="~/Sunshine.master" AutoEventWireup="true" CodeFile="Agenda.aspx.cs" Inherits="Agenda" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="noindex, follow">
    <script src="Scripts/DataTables/jquery.dataTables.js" ></script>
    <link rel="stylesheet" type="text/css" href="Content/DataTables/css/jquery.dataTables.css">
    <script>
        $(document).ready(function () {

            $('#agendaTable').DataTable( {
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Dutch.json"
                },
                "order": [[ 2, "asc" ]],
                "aoColumnDefs": [
                    { 'bSortable': false, 'aTargets': [0, 1, 3, 4, 7] }
                ],
                "pageLength": 50,
            });

            // Set active link in navbar
            var url = window.location;
            $('.agendanav .navbar-nav').find('.active').removeClass('active');
            $('.agendanav .navbar-nav li a').each(function () {
                if (this.href == url.href) {
                    $(this).parent().addClass('active');
                }
            });
        });
    </script>   
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
    <div class="col-md-12">
        <div class="row">
            <nav class="agendanav nav navbar-default">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                            <span class="sr-only">Menu agendan</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <!-- <a class="navbar-brand" href="#">Brand</a> -->
                    </div>
                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <ul class="nav navbar-nav">
                            <li class="active">
                                <a href="<%= Page.ResolveUrl("~/Agenda.aspx") %>">
                                    Toekomstige optredens 
                                    <span class="sr-only">(current)</span>
                                </a>
                            </li>
                            <li>
                                <a href="<%= Page.ResolveUrl("~/Agenda.aspx?showAll=true") %>">Alle optredens</a>
                            </li>
                            <li>
                                <a href="<%= Page.ResolveUrl("~/AgendaAdd.aspx") %>">Voeg nieuw optreden toe</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>



            
        </div>
        <div class="row">
            <div class="col-md-12">
                <table id="agendaTable">
                <asp:Repeater ID="RepeaterAgenda" runat="server">
                    <HeaderTemplate>
                    <thead>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th>Datum</th>
                        <th class="hidden-xs">Van</th>
                        <th class="hidden-xs">Tot</th>
                        <th class="hidden-xs">Adres</th>
                        <th>Omschrijving</th>
                        <th class="hidden-xs">Openbaar</th>   
                        <th class="hidden-xs">Agenda</th>                     
                    </thead>
                    <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="HiddenFieldAgendaId" runat="server" Value='<%# Eval("id")%>' />
                            <asp:HiddenField ID="HiddenFieldgoogleAgendaSynchId" runat="server" Value='<%# Eval("googleAgendaSynchId")  %>' />                            
                            <td>                             
                                <a href="AgendaEdit.aspx?id=<%# Eval("id")%>">
                                    <img class="AgendaEditButton" src="Images/EditButton.png" alt="Bewerk" title="Bewerk optreden" />    
                                </a>
                            </td>
                            <td>
                                <asp:LinkButton ID="DeleteButton" OnCommand="DeleteButton_Command" OnClientClick="return confirm('Weet je zeker dat je dit optreden wilt verwijderen?');" CommandArgument='<%# Eval("id")%>' runat="server">
                                    <img class="AgendaDeleteButton" src="Images/DeleteButton.png" alt="Verwijder" title="Verwijder optreden" />
                                </asp:LinkButton>
                            </td>
                            <td>
                                <span style="display:none"><%#Eval("datum", "{0:yyyy/MM/dd}") %></span>
                                <asp:Label ID="LabelDatum" runat="server" Text='<%# FormatDate(Eval("datum")) %>'></asp:Label>
                                <asp:TextBox ID="TextBoxDatum" runat="server" Text='<%# Eval("datum") %>' Visible="false"></asp:TextBox>
                            </td>
                            <td class="hidden-xs">
                                <asp:Label ID="LabelVan" runat="server" Text='<%# FormatTime(Eval("van")) %>'></asp:Label>
                                <asp:TextBox ID="TextBoxVan" runat="server" Text='<%# FormatTime(Eval("van")) %>' Visible="false"></asp:TextBox>
                            </td>
                            <td class="hidden-xs">
                                <asp:Label ID="LabelTot" runat="server" Text='<%# FormatTime(Eval("tot")) %>'></asp:Label>
                                <asp:TextBox ID="TextBoxTot" runat="server" Text='<%# FormatTime(Eval("tot")) %>' Visible="false"></asp:TextBox>
                            </td>
                            <td class="hidden-xs">
                                <asp:Label ID="LabelAdres" runat="server" Text='<%# Eval("adres") %>'></asp:Label>
                                <asp:TextBox ID="TextBoxAdres" runat="server" Text='<%# Eval("adres") %>' Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelOmschrijving" runat="server" Text='<%# Eval("omschrijving") %>'></asp:Label>
                                <asp:TextBox ID="TextBoxOmschrijving" runat="server" Text='<%# Eval("omschrijving") %>' Visible="false"></asp:TextBox>
                            </td>
                            <td class="hidden-xs">
                                <asp:Label ID="LabelOpenbaar" runat="server" Text='<%# (Boolean.Parse(Eval("openbaar").ToString())) ? "Ja" : "Nee" %>'></asp:Label>
                            </td>
                            <td class="hidden-xs">
                                <asp:Label ID="LabelAgendaType" runat="server" Text='<%# FormatAgendaType(Eval("agendatype")) %>'></asp:Label>
                                
                            </td>
                            
                        </tr>                        
                    </ItemTemplate>
                    <FooterTemplate>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="hidden-xs">&nbsp;</td>
                        </tr>
                    </tfoot>
                    </FooterTemplate>
                </asp:Repeater>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                Aantal optredens in <%=DateTime.Now.Year.ToString() %>: <strong><asp:Label ID="LabelCountOptredens" runat="server" Text="0"></asp:Label></strong>
            </div>
        </div>
    </div>            
            
</asp:Content>
