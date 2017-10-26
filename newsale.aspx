<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsale.aspx.cs" Inherits="newsale" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="HomePage" runat="server">

    <asp:Table ID="medsale" runat="server"  Width="500px" CellPadding="3" BorderStyle="Solid" BorderColor="Black">
        <asp:TableRow>
            <asp:TableCell>
                Medicine ID
            </asp:TableCell>
            <asp:TableCell>
                Quantity
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <asp:Button id="addrow" Text ="add New Item" runat="server" OnClick="addrow_Click"/>
</asp:Content>