<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Website_revision.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Style.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>   
            <asp:Button ID="btnSearch" runat="server" Text="Zoeken" OnClick="btnSearch_Click" />
            <asp:Label ID="lblRepo" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="container">
            <div class="repo"><div class="gh-repositories" data-username="StageJuice"></div></div>
        </div>
    </form>
</body>
</html>
