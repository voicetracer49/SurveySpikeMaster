﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yesNoQuistions.aspx.cs" Inherits="SurveySpike.yesNoQuistions" %>

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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelHvadErDetRigtigeSvar" runat="server" Text="Hvad er det rigtige svar på: "></asp:Label>
     <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
        <asp:Label ID="ToSetActualQuestion" runat="server" Text="Her skal Spørgsmålet stå!" ></asp:Label>
        <br />
       <%-- <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
        <asp:CheckBox ID="CheckBoxJa" runat="server" Text="JA" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckBoxNej" runat="server" Text="Nej" />--%>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
        <asp:RadioButton ID="RadioButton1" GroupName="language" runat="server" Text="JA"  />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="RadioButton2" GroupName="language" runat="server" Text="Nej" />
        
        <br /><br />       
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonEnterRightAnswar" runat="server" Text="Enter" onclick="ButtonEnterRightAnswar_Click"/>
    
        
    </div>
    </form>
</body>
</html>
