<%@ Page Title="g" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personenverwaltung.aspx.cs" Inherits="Mannschaft.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    

    <h2>Personenverwaltung</h2>

    <br />
   
    <br />
    <asp:RadioButtonList ForeColor="Black" BackColor="White" BorderColor="Black" ID="RadioButtonList1" runat="server"  Width="184px" BorderStyle="Solid">
        <asp:ListItem>Physiotherapeut</asp:ListItem>
        <asp:ListItem>Trainer</asp:ListItem>
        <asp:ListItem>TennisSpieler</asp:ListItem>
        <asp:ListItem>HandballSpieler</asp:ListItem>
        <asp:ListItem>Fussballspieler</asp:ListItem>
    </asp:RadioButtonList>
    
    <br />
    <asp:Button class="btn btn-default" ID="Button1" runat="server" OnClick="Button1_Click" Text="Auswälen" Width="183px" href = "~/MannschaftVerwaltung" BorderColor="Black" BorderStyle="Solid"/>


    <br />
    <br  />
    <a id="name" runat="server">Name:</a> &nbsp;&nbsp;
    
    <asp:TextBox ID="TextBox3"  ForeColor="Black" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp; 
    <a id="alter" runat="server">Alter:</a>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" TextMode="Number"></asp:TextBox>
    <br />
    <br />
    

    <asp:Table ID="Table2" runat="server" ForeColor="Black" BackColor="White"></asp:Table>


    <br />
    <asp:Button class="btn btn-default" ID="Button2" runat="server" Text="Hinzufügen" OnClick="Button2_Click" Width="176px" BorderColor="Black" BorderStyle="Solid" />
    <asp:Button class="btn btn-default" ID="Button9" runat="server" Text="Aktulieseren"  Width="176px" BorderColor="Black" BorderStyle="Solid" OnClick="Button9_Click" />
    <br />

    <br />
    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />
    
    
   







    <asp:Table ID="Table1" ForeColor="Black" BackColor="White" runat="server" class="table table-bordered table-hover" BorderColor="Black" BorderStyle="Solid">
        
        <asp:TableHeaderRow runat="server">
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">ID</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Name</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Alter</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Herkunft</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Einsatzbereich</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Anzahl Spiele</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Position</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Rückennummer</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Gesundheitzustand</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Gehalt</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Sportart</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2"></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2"></asp:TableCell>




        </asp:TableHeaderRow>
        

        

       
    </asp:Table>
    <table>
        <thead>
          
        </thead>

        <tbody>


        </tbody>
    </table>
       <br />
    <br />
   
    <br />
    <br />
    


</asp:Content>


