<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreQuestion.aspx.cs" Inherits="SurveySpike.StoreQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 326px">
        &nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Overskrift" runat="server" Text="Welcome to Pollpolly"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Label ID="StoreTheQuestion" runat="server" Text="Vil du gemme eller lave flere?"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonGemOgSe" runat="server" Text="Gemme og se Survey" Width="142px" />
&nbsp;&nbsp;
        <asp:Button ID="ButtonOpretNytSpoergsM" runat="server" Text="Opret Nyt Spørgsmål" Width="124px" />
    
    </div>
    </form>
</body>
</html>
