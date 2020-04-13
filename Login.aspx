<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AainaSalonWebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login form</title>
</head>
<body style="background-color:#f7d5d5">
    <form id="form1" runat="server">
    <div style="margin-left:500px; margin-top:100px;">
    <asp:Table ID="Table1" runat="server" Width="418px" Height="209px" >
        <asp:TableRow>
            <asp:TableCell>
               <b>User Name: </b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <b>Password: </b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" Height="50%" Style="background-color:#4cff00; border-radius:8px;" />
            
            <asp:TableCell></asp:TableCell> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TableCell></asp:TableCell>

                <asp:Button ID="Button2" runat="server" Text="Login" OnClick="Button2_Click" Height="50%" Style="background-color:#4cff00; border-radius:8px;"  />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Style="color:#0026ff"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        
    </asp:Table>
    </div>
    </form>
</body>
</html>
