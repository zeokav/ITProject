<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="batch.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BatchContent" ContentPlaceHolderID="HomePage" Runat="Server">
    <h1>Register Batch</h1>
    <asp:Label runat="server" ID="errmsg"></asp:Label>
    <asp:Label runat="server" CssClass="text-muted" Text="Add info about medicine batches"></asp:Label><br /><br />
    
    <div class="form-horizontal form-holder">
        <div class="form-group">
            <div class="control-label col-sm-2">
                <asp:Label runat="server">Medicine: </asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:DropDownList runat="server" ID="ddl" CssClass="form-control"></asp:DropDownList>
            </div>
            
        </div>
        <div class="form-group">
            <div class="control-label col-sm-2">
                <asp:Label runat="server">Expiry Date: </asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox type="date" runat="server" CssClass="form-control" id="Exp" onfocus="this.type='date'"/>
            </div>
            
        </div>
        <div class="form-group">
            <div class="control-label col-sm-2">
                <asp:Label runat="server">Buy Date: </asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox type="date" runat="server" CssClass="form-control" id="Buy" onfocus="this.type='date'"/>
            </div>
            
        </div>

        <div class="col-sm-offset-2">
            <asp:Button Text="Submit" OnClick="Submit_Form" runat="server" CssClass="btn btn-md btn-default"/>
            <asp:Button Text="Reset" OnClick="Reset_Form" runat="server" CssClass="btn btn-md btn-warning"/>
        </div>
        
    </div>      
</asp:Content>

