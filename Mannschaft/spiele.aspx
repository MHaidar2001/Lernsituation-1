<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="spiele.aspx.cs" Inherits="Mannschaft.spiele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <br />
    <br /> <b>
    <h1>Turnier durchführen</h1>
    <br />
   
    <h5>Wählen Sie ein Turnier aus:</h5></b>
    <asp:DropDownList class = "form-control"  ID="MsListen" ForeColor="Black" runat="server"></asp:DropDownList>
        <br />

    <asp:Button ID="MSbtn" runat="server" Text="Auswählen" OnClick="MSbtn_Click" />

    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

    <asp:Table ID="Table1" runat="server" BackColor="White" ForeColor="Black">
        <asp:TableRow>
            <asp:TableCell>
                <asp:DropDownList class = "form-control"  ID="M1List" runat="server"></asp:DropDownList>

            </asp:TableCell>
            <asp:TableCell>
                <h3>  VS   </h3>
            </asp:TableCell>

            <asp:TableCell>
                <asp:DropDownList class = "form-control"  ID="M2List" runat="server"></asp:DropDownList>
            </asp:TableCell>


        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="Table3" runat="server" BackColor="White" ForeColor="Black" >
        <asp:TableRow>
            <asp:TableCell Width="100">&nbsp;&nbsp;&nbsp;&nbsp;
                <h4>
                <asp:Label ID="M1lb" runat="server" Text=""></asp:Label></h4>
            </asp:TableCell>
            <asp:TableCell>&nbsp;&nbsp;&nbsp;
                <h3>VS</h3>
            </asp:TableCell>
            
            <asp:TableCell>
                <h4>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="M2lb" runat="server" Text="" ></asp:Label></h4>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ForeColor="Black" ID="M1box" runat="server" TextMode="Number"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                -
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ForeColor="Black" ID="M2box" runat="server" TextMode="Number"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>

   

    <br />
    <asp:Button ID="speichernbt" runat="server" Text="Ein neues Spiel anlegen" OnClick="speichernbt_Click" />
    <asp:Button ID="aenderung" runat="server" Text="Änderung speichern" OnClick="aenderung_Click" />
    <h2>
        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text=""></asp:Label>
    </h2>

    <h2>
        <asp:Label ID="tblLabel" runat="server" Text=""></asp:Label></h2>
     <asp:Table ID="Table2" ForeColor="Black" BackColor="White" runat="server" class="table table-bordered table-hover" BorderColor="Black" BorderStyle="Solid">
        <asp:TableHeaderRow runat="server">
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">ID</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Mannschaft1</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Mannschaft2</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Ergebnis1</asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2">Ergebnis2</asp:TableCell>
            
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2"></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BackColor="#CCCC00" BorderWidth="2"></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
