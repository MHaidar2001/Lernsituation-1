<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="Mannschaft.Turnierverwaltung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <h1 >Turnierverwaltung</h1>
    <asp:Label ID="Label1" runat="server" Text="Eine Sportart für das Turnier auswählen bzw. ändern:"></asp:Label>
    <br />

    <asp:DropDownList class = "form-control" ID="DropDownList1" runat="server" ForeColor="Black" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="32px" Width="104px">
        <asp:ListItem>Fußball</asp:ListItem>
        <asp:ListItem>Handball</asp:ListItem>
        <asp:ListItem>Tennis</asp:ListItem>

    </asp:DropDownList>
    <br />


   
    <asp:Table ID="datentbl" runat="server" Width="71px" Height="29px" ForeColor="Black" BackColor="White" >
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label  ID="lab1"  runat="server" Text="Turnier Name:"></asp:Label>
            <asp:TextBox class = "form-control" ID="tx1" runat="server" ForeColor="Black"></asp:TextBox>

            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="Datenladen" BackColor="White" ForeColor="black" BorderColor="White" runat="server"></asp:Table>


    <asp:CheckBoxList ID="DatenladenSQL" runat="server"  BackColor="White" ForeColor="black" BorderColor="White"></asp:CheckBoxList>

   
    <h4>
    <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="vorhandene Mannschaften:"></asp:Label></h4>
    <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Wählen Sie bitte den Mannschaf aus, den Sie aus der Turnier entfernen möchten!"></asp:Label>
    <asp:CheckBoxList ID="aenderung" runat="server"  BackColor="White" ForeColor="black" BorderColor="White"></asp:CheckBoxList>
     

    
     <h4>
    <asp:Label ID="Label4" runat="server" ForeColor="Black" Text="verfügbare Mannschaften:"></asp:Label></h4>
    <asp:Label ID="Label5" runat="server" ForeColor="Green" Text="Wählen Sie bitte eine Mannschaft aus den Sie einfügen möchten!"></asp:Label>
    <asp:CheckBoxList ID="verfuegbarePersonen" runat="server"  BackColor="White" ForeColor="black" BorderColor="White"></asp:CheckBoxList>

    <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Hinzufügen"  BorderColor="Black" BorderStyle="Solid" Width="176px" OnClick="Button1_Click"/>
    <asp:Button class="btn btn-default" ID="Button9" runat="server" Text="Aktulieseren"  Width="176px" BorderColor="Black" BorderStyle="Solid" OnClick="AktulieserenDB"  />

    <br />
    <br />


    <asp:Table ID="Table5"  class="table table-bordered table-hover" runat="server" BorderStyle="Inset" BackColor="White" ForeColor="Black">
        <asp:TableRow>
            <asp:TableCell BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">ID</asp:TableCell>
            <asp:TableCell BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Name</asp:TableCell>
            <asp:TableCell BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Sportart</asp:TableCell> 

            <asp:TableCell BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">mitglieder</asp:TableCell>
            <asp:TableCell BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2"></asp:TableCell>
            <asp:TableCell BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2"></asp:TableCell>

        </asp:TableRow>
    </asp:Table>
 
    

</asp:Content>
