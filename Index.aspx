<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AainaSalonWebApp.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aaina Salon</title>
</head>
<body>
    <div style="background-color:#f7d5d5; height:800px;">

    <form id="form1" runat="server">
    <div style="background-color:#808080">
    <center><h1>Home Page</h1></center>
    </div>
        <div style="margin-left:500px;">
          Name:  &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtName"></asp:TextBox><br /><br />
          Mobile:  &nbsp;&nbsp;<asp:TextBox runat="server" ID="txtMobile"></asp:TextBox><br /><br />
          Email ID <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox><br /><br />
          City:  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtCity"></asp:TextBox><br /><br />
          Job:  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtJob"></asp:TextBox><br /><br />

            <div style="margin-left:100px;">
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Style="background-color:#00ff21; width:70px; height:20px; color:#000000" />
        </div></div>
        <br />
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <div style="width: 100%; margin-left:400px; height: 500%; overflow: auto">
            <asp:GridView AutoGenerateColumns="false" ID="GridView1" runat="server" AllowPaging="true" AllowSorting="true" PageSize="10" style="text-align:center;">
                 <rowstyle Height="5px" />
        <alternatingrowstyle  Height="5px"/>
                <Columns>  
                    <asp:BoundField HeaderText="Name" DataField="Name" />  
                    <asp:BoundField HeaderText="Mobile" DataField="Mobile" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />  
                    <asp:BoundField HeaderText="City" DataField="City" />  
                    <asp:BoundField HeaderText="Job" DataField="Job" />  
                     
                    
                </Columns> 
                
            </asp:GridView>  
       </div>
    </form>

    </div>
</body>
</html>
