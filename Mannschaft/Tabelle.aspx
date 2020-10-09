<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tabelle.aspx.cs" Inherits="Mannschaft.Tabelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <br />
    <br /> <b>
        <asp:Label ID="Label1" runat="server" Text=""  ForeColor="Red"></asp:Label>
    <h1>Turnier - Ergebnisse anzeigen</h1>
    <br />
   
    <h5>Wählen Sie ein Turnier aus:</h5></b>
    <asp:DropDownList class = "form-control"  ID="MsListen" ForeColor="Black" runat="server"></asp:DropDownList>
    <br />
        <asp:Button ID="MSbtn" runat="server" Text="Auswählen" OnClick="MSbtn_Click" />
    <br />
    <br />
     <h2>  <asp:Label ID="tblLabel" runat="server" Text=""></asp:Label></h2>
     <asp:Table ID="Table2" ForeColor="Black" BackColor="White" runat="server" class="table table-bordered table-hover" BorderColor="Black" BorderStyle="Solid">
        <asp:TableHeaderRow runat="server">
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Pos.</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Mannschaft</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">T</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">GT</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Punkte</asp:TableCell>
            

        </asp:TableHeaderRow>
    </asp:Table>

</asp:Content>
