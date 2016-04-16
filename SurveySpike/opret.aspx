<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="opret.aspx.cs" Inherits="SurveySpike.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 389px;
            width: 810px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 368px">
        &nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Overskrift" runat="server" Text="Welcome to Pollpolly - Make an acount!"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;<asp:Label ID="LabelNavn" runat="server" Text="Navn"></asp:Label>
        &nbsp;
        <asp:TextBox ID="TextBoxNavn" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;<asp:Label ID="LabelPass" runat="server" Text="Pass"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBoxPass" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;<asp:Label ID="LabelAdress" runat="server" Text="Adress"></asp:Label>
        &nbsp;
        <asp:TextBox ID="TextBoxAdress" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;<asp:Label ID="LabelFirma" runat="server" Text="Firma"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBoxFirma" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;<asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
        &nbsp;
        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;<asp:Label ID="LabelTlf" runat="server" Text="Tlf"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBoxTlf" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ButtonOretEnter" runat="server" Text="Enter" />
        <br />
    </div>
    </form>
</body>
</html>
