<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addmedicine.aspx.cs" Inherits="addmedicine" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="HomePage" runat="server">
    <h1>New Medicine Record
    </h1>
    <h3 class="text-muted" style="font-style: italic">Enter new medicine information here</h3>

    <div class="form-horizontal form-holder">

        <div class="form-group">
            <div class="control-label col-sm-2">
                <asp:Label runat="server">Trade Name: </asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox runat="server" ID="TName" CssClass="form-control" placeholder="Trade Name"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TName"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div class="control-label col-sm-2">
                <asp:Label runat="server">Generic Name: </asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox runat="server" ID="GName" CssClass="form-control" placeholder="Generic Name"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="GName"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div class="control-label col-sm-2">
                <asp:Label runat="server">Manufacturer: </asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox runat="server" ID="Manufacturer" CssClass="form-control" placeholder="Manufacturer"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Manufacturer"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div class="control-label col-sm-2">
                <asp:Label runat="server">Vendor: </asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:DropDownList runat="server" ID="VendorDdl" CssClass="form-control">
                    <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="control-label col-sm-2">
                <asp:Label runat="server">Cost: </asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox runat="server" ID="Cost" CssClass="form-control" placeholder="Medicine Cost"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Cost"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ValidationExpression="[0-9]+([.][0-9]+)?" ControlToValidate="Cost" runat="server" ErrorMessage="Invalid cost format!"></asp:RegularExpressionValidator>
        </div>
        <asp:Button runat="server" OnClick="Add_Medicine" Text="Add Medicine" CssClass="btn btn-md btn-default col-sm-offset-2" />
        <asp:Button runat="server" OnClick="Reset_Form" Text="Reset Form" CssClass="btn btn-md btn-warning" />
        <asp:Label runat="server" ID="Result"></asp:Label>
    </div>
</asp:Content>
