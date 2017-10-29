<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addvendor.aspx.cs" Inherits="addvendor" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="HomePage" runat="server">
    <h1>Vendors
    </h1>
    <h3 class="text-muted" style="font-style: italic">Manage your vendors here</h3>
    <div class="form-holder">


        <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#modal">
            Add Vendor
       
        </button>


        <div class="modal fade" id="modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Add Vendor</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="control-label col-sm-2">
                                    <asp:Label runat="server">Name: </asp:Label>
                                </div>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" ID="Name" CssClass="form-control" placeholder="Name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ControlToValidate="Name" runat="server"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="control-label col-sm-2">
                                    <asp:Label runat="server">Address: </asp:Label>
                                </div>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" ID="Address" CssClass="form-control" placeholder="Address" Rows="3"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ControlToValidate="Address" runat="server"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <asp:Label runat="server" ID="message"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" CssClass="btn btn-default" OnClick="Add_Vendor" Text="Add"></asp:Button>
                    </div>
                </div>
            </div>
        </div>


        <div class="form-holder">
            <asp:SqlDataSource runat="server"
                ConnectionString="<%$ConnectionStrings:medDb%>"
                SelectCommand="SELECT * FROM Vendor"
                InsertCommand=""
                ID="vds"></asp:SqlDataSource>

            <asp:GridView runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true" AutoGenerateEditButton="true" DataSourceID="vds">
                <Columns>
                    <asp:BoundField DataField="Vendor_ID" HeaderText="ID" ReadOnly="true">
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Vendor_Name" HeaderText="Name" ItemStyle-Width="250px" SortExpression="Vendor_Name" />
                    <asp:BoundField DataField="Vendor_Address" HeaderText="Address" ItemStyle-Width="600px" />
                </Columns>
            </asp:GridView>
        </div>

    </div>


</asp:Content>
