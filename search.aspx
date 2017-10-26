<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" MasterPageFile="~/MasterPage.master"%>


<asp:Content ContentPlaceHolderID="HomePage" runat="server">
    <div class="search">
            <asp:Label ID="genericnamelabel" runat="server" Width="100px">Generic Name: </asp:Label>
            <asp:TextBox ID="genericnametextbox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="tradnamelabel" runat="server" Width="100px">Trade Name:</asp:Label>
            <asp:TextBox ID="tradenametextbox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="submitbut" OnClick="submitbut_Click" Text="Search" runat="server" />
            <br />
            <br />
            <asp:Label ID="errorText"  runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="findmed" runat="server" AutoGenerateColumns="true"></asp:GridView>
    </div>
</asp:Content>
