<%@ Page Title="" Language="C#" MasterPageFile="~/Sunshine.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Beheer_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Default.aspx"></asp:Login>
        </div>        
    </div>
</asp:Content>
