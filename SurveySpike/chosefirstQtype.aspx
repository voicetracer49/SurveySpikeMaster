<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chosefirstQtype.aspx.cs" Inherits="SurveySpike.chosefirstQtype" %>

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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelWriteQuestion" runat="server" Text="Write Question"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxWriteQuestion" runat="server" Height="125px" Width="152px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelCFQT" runat="server" Text="choose first question type !"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="Choose Type" Value="0"></asp:ListItem>
            <asp:ListItem Text="Yes/No questions" Value="1"></asp:ListItem>
            <asp:ListItem Text="Skala" Value="2"></asp:ListItem>
            <asp:ListItem Text="Svar Muligheder" Value="3"></asp:ListItem>
            <asp:ListItem Text="Qualitativ Svar" Value="4"></asp:ListItem>
        </asp:DropDownList>
        <br />
        
        <br /><br />
         Selected Item Text: <asp:Label ID="lblSelectedText" runat="server"></asp:Label>
           <br /><br /> 
         Selected Item Value: <asp:Label ID="lblSelectedValue" runat="server"></asp:Label>

    
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonEnterType" runat="server" Text="Enter" OnClick="ButtonEnterType_Click"  />
    
        
    </div>
    
               
           

    </form>
</body>
</html>
