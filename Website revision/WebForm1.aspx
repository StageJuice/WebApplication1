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
            <div>
                <asp:Label ID="lblUsername" runat="server"></asp:Label>
                <asp:Label ID="lblAmmount" runat="server"></asp:Label>
            </div>
            <hr />
            <div>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>   
                <asp:Button ID="btnSearch" runat="server" Text="Zoeken" OnClick="btnSearch_Click" />
            </div>
        </div>
    </form>
</body>
</html>
