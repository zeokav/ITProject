<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsale.aspx.cs" Inherits="newsale" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="HomePage" runat="server">
    <div class="form-horizontal form-holder">
        <asp:Table ID="medsale" runat="server" Width="500px" CellPadding="3" BorderStyle="Solid" BorderColor="Black">
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
    </div>
    <asp:Button ID="addrow" Text="add New Item" runat="server" OnClick="addrow_Click" CssClass="btn btn-md btn-warning" />

    <asp:Button ID="sub" Text="Submit Order" runat="server" OnClick="sub_Click" CssClass="btn btn-md btn-default" />
    <br />
    <br />
    <asp:Label ID="errorTex" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="pricelab" runat="server" CssClass="alert-info" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
</asp:Content>
