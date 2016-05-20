<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SurveySpike.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 355px;
            width: 810px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 326px">
        &nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Overskrift" runat="server" Text="Welcome to Pollpolly"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;<asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
        &nbsp;
        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;<asp:Label ID="LabelPass" runat="server" Text="Pass"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBoxPass" runat="server" ></asp:TextBox>
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonEnter" runat="server" OnClick="ButtonEnter_Click" Text="Enter" />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
