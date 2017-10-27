<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" MasterPageFile="~/MasterPage.master" %>


<asp:Content ContentPlaceHolderID="HomePage" runat="server">
    <h1>Medicine Search</h1>
    <h3 class="text-muted" style="font-style: italic">Enter Trade Name or Generic Name</h3>
    <div class="form-horizontal form-holder">
        <div class="form-group">
            <div class="control-label col-sm-2">
                <asp:Label ID="genericnamelabel" runat="server" Width="100px">Generic Name: </asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="genericnametextbox" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="control-label col-sm-2">
        <asp:Label ID="tradnamelabel" runat="server" Width="100px">Trade Name:</asp:Label>
            </div>
            <div class="col-sm-5">
        <asp:TextBox ID="tradenametextbox" runat="server"></asp:TextBox>
            </div>
        </div>
        
        <asp:Button ID="submitbut" OnClick="submitbut_Click" Text="Search" runat="server" CssClass="btn btn-md btn-default col-sm-offset-2"/>
        <br />
        <br />
        <asp:Label ID="errorText" runat="server"></asp:Label>
        <br />
        <br />
        <asp:DetailsView ID="findmed" runat="server" AutoGenerateColumns="true" Width="100px" CellSpacing="2" CellPadding="10">
            
        </asp:DetailsView>
    </div>
</asp:Content>
