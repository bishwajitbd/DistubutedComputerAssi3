<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ClientApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client app</title>
</head>
<body>
    <div style="margin: 0px auto 0px auto; width: 400px">

    <form id="form1" runat="server">
        <h1>Employee information</h1>
        <table style="font-family:Arial; border:1px solid black;">
            <tr>
                <td>
                    <b>ID (Search/save)</b>
                </td>
                <td>
                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Name</b>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Gender</b>
                </td>
                <td>
                    <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Date Of Birth</b>
                </td>
                <td>
                    <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGetPerson" runat="server" Text="Get Person Info" onclick="btnGetPerson_Click" />                                    
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save Person's info" onclick="btnSave_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
        </div>
</body>
</html>
