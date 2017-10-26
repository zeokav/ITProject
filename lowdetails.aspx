<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="lowdetails.aspx.cs" Inherits="_Default" %>

<asp:Content ID="LowDetails" ContentPlaceHolderID="HomePage" Runat="Server">
    <h2>Details</h2>
    <asp:Label CssClass="text-muted" Text="Details of medicine low on stock" runat="server"></asp:Label>
    <br /><br />
    <asp:SqlDataSource ConnectionString="<%$ConnectionStrings:medDb%>" runat="server" ID="medven"
        SelectCommand="Select * from MedicineMaster INNER JOIN Vendor ON MedicineMaster.Vendor_ID=Vendor.Vendor_ID WHERE MedicineMaster.Med_ID=@med">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="med" Name="med" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:DetailsView runat="server" DataSourceID="medven" ID="dv"></asp:DetailsView>

    <br />
    <asp:Label ID="rdr" runat="server"></asp:Label>

    <asp:Button Text="Reorder" CssClass="btn btn-md btn-primary" runat="server" OnClick="Order_Med"/>
    <div class="col-sm-12" style="text-align:center">
        <asp:Label runat="server" Font-Size="18" ID="lbl"></asp:Label>
    </div>
    
</asp:Content>

