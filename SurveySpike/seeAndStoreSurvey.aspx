<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seeAndStoreSurvey.aspx.cs" Inherits="SurveySpike.seeAndStoreSurvey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<script src="~/scripts/angular.js"></script>--%> <%-- https://docs.microsoft.com/en-us/aspnet/core/client-side/angular  --%>

    <title></title>
</head>
        <body>
    <form id="form2" runat="server">
    <div style="height: 326px">
        &nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Overskrift" runat="server" Text="Welcome to Pollpolly"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelHvadErDetRigtigeSvar" runat="server" Text="Det rigtige svar på: "></asp:Label>
     <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
        <asp:Label ID="ToSetActualQuestion" runat="server" Text="Her skal Spørgsmålet stå!" ></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
        <asp:Label ID="Label2" runat="server" Text=" Er: " ></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Ja el Nej" ></asp:Label>
        <br />

        <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
        <asp:RadioButton ID="RadioButton1" GroupName="language" runat="server" Text="JA"  />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="RadioButton2" GroupName="language" runat="server" Text="Nej" />--%>
        
        <br /><br />       
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonEnterRightAnswar" runat="server" Text="Enter" onclick="ButtonEnterRightAnswar_Click"/>
    
        <%--<div data-ng-repeat="survey in surveys">
            {{survey}}
        </div>--%>
    

    </div>
    </form>
</body>
</html>
