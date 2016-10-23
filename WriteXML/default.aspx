<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WriteXML._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Style.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header"></div>
        <div id="sidebar"></div>
        <div id="content">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="up1" runat="server">
                        <ProgressTemplate>Loading...</ProgressTemplate>
                    </asp:UpdateProgress>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblID" runat="server" Text="Enter author ID: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblLname" runat="server" Text="Enter Last name: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblFname" runat="server" Text="Enter Full name: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                
            </asp:Table>
            <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click"  /><br>
            <asp:Label ID="lblMessage" Visible="false" runat="server" Text=""></asp:Label>
            <asp:GridView ID="GridView1" runat="server" ></asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
         </div>
    </form>
</body>
</html>
