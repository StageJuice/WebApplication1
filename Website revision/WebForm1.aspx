<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Website_revision.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Style.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <table>
                <tbody>
                    <tr>
                        <td>Home</td>
                        <td><a>Revision</a></td>
                    </tr>   
                </tbody>
            </table>
        </div>
        <div id="body">
            <iframe id="iframe" src="http://tylerlh.github.com/github-latest-commits-widget/?username=StageJuice&repo=WebApplication1&limit=10" allowtrancparency="true"  frameborder="0" scrolling="no" width="502px" height="252px"></iframe>
        </div>
    </form>
</body>
</html>
