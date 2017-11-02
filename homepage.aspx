<%@ Page Language="C#" AutoEventWireup="true" CodeFile="homepage.aspx.cs" Inherits="homepage" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="HomePage" runat="server">
    <asp:Panel ID="pnl" runat="server">
        <asp:Label ID="errmsg" runat="server"></asp:Label>
        <h1>Revenue for the day</h1>
        <asp:Label ID="rev" runat="server"></asp:Label>
        <h1>Summary</h1>
        <div class="row">
            <div class="col-md-4">

                <asp:ScriptManager ID="ScriptManager" runat="server" >
                </asp:ScriptManager>

                <asp:UpdatePanel runat="server" ID="req_med">
                    <ContentTemplate>
                        <h3>Medicines Required</h3>
                        <asp:Label ID="ReqStatus" runat="server" CssClass="text-muted"></asp:Label><br /><br />
                        <asp:Button Text="Show/Hide" OnClick="Show_Req" runat="server"/><br /><br />
                        <asp:GridView ID="req_gv" runat="server" AllowSorting="true" Visible="false" AutoGenerateColumns="false" OnRowCommand="req_gv_RowCommand" DataKeyNames="Med_ID">
                            <RowStyle BackColor="#ccffff"/>
                            <HeaderStyle Font-Italic="true" Font-Bold="true"/>
                            <Columns>
                                <asp:BoundField DataField="Med_ID" HeaderText="ID"/>
                                <asp:BoundField DataField="Trade_Name" HeaderText="Name"/>
                                <asp:BoundField DataField="Med_Remaining" HeaderText="Remaining"/>
                                <asp:BoundField DataField="Med_Threshold" HeaderText="Threshold"/>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button Text="More Info"
                                            CommandName="ShowInfo" runat="server" 
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button Text="Place Order"
                                            CommandName="PlaceOrder" runat="server" 
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Panel ID="orderPanel" runat="server" Visible="false">
                            <asp:Label runat="server" ID="batcherr"></asp:Label><br />
    
                            <div class="form-horizontal form-holder">
                                <div class="form-group">
                                    <div class="control-label col-sm-2">
                                        <asp:Label runat="server">Medicine: </asp:Label>
                                    </div>
                                    <div class="col-sm-8">
                                        <asp:DropDownList runat="server" ID="ddl" CssClass="form-control"></asp:DropDownList>
                                    </div>
            
                                </div>
                                <div class="form-group">
                                    <div class="control-label col-sm-2">
                                        <asp:Label runat="server">Expiry Date: </asp:Label>
                                    </div>
                                    <div class="col-sm-8">
                                        <asp:TextBox type="date" runat="server" CssClass="form-control" id="Exp" onfocus="this.type='date'"/>
                                    </div>
            
                                </div>
                                <div class="form-group">
                                    <div class="control-label col-sm-2">
                                        <asp:Label runat="server">Buy Date: </asp:Label>
                                    </div>
                                    <div class="col-sm-8">
                                        <asp:TextBox type="date" runat="server" CssClass="form-control" id="Buy" onfocus="this.type='date'"/>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:CheckBox runat="server" ID="cb" Text="Choose from default values" OnCheckedChanged="Hide_Check" AutoPostBack="true"/>
                                    <asp:RadioButtonList runat="server" ID="rbl" Visible="false">
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                                <div class="form-group">
                                    <div class="control-label col-sm-2">
                                        <asp:Label runat="server" ID="QtyLabel">Quantity: </asp:Label>
                                    </div>
                                    <div class="col-sm-8">
                                        <asp:TextBox type="text" runat="server" CssClass="form-control" id="Qty"/>
                                        <asp:RangeValidator ID="RngValid" runat="server" MinimumValue="0" MaximumValue="200" Type="Integer" ErrorMessage="Value should be between 0 and 200" ControlToValidate="Qty">
                                        </asp:RangeValidator>
                                    </div>
                                </div>

                                <div class="col-sm-offset-2">
                                    <asp:Button Text="Submit" OnClick="Submit_Form" runat="server" CssClass="btn btn-md btn-default"/>
                                    <asp:Button Text="Reset" OnClick="Reset_Form" runat="server" CssClass="btn btn-md btn-warning"/>
                                    <asp:Button Text="Hide" OnClick="Hide_Form" runat="server" CssClass="btn btn-md btn-default" />
                                </div>
        
                            </div>                            
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <br />
                <br />
                
            </div>
            <div class="col-md-4">
                <h3>Expired Medicines</h3>
                <asp:Label ID="ExpStatus" runat="server" CssClass="text-muted"></asp:Label><br /><br />
                <asp:Button Text="Show/Hide" OnClick="Show_Exp" runat="server"/><br /><br />
                <asp:GridView ID="exp_gv" runat="server" AllowSorting="true" Visible="false" AutoGenerateColumns="false" DataKeyNames="Batch_ID">
                    <RowStyle BackColor="#ccffff"/>
                    <HeaderStyle Font-Italic="true" Font-Bold="true"/>
                    <Columns>
                        <asp:BoundField DataField="Batch_ID" HeaderText="Batch No." />
                        <asp:BoundField DataField="Trade_Name" HeaderText="Medicine" />
                        <asp:BoundField DataField="Expiry_Date" HeaderText="Expired" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-4">
                <h3>Vendor-wise Expired Medicines</h3>
                <asp:Button Text="Show/Hide" OnClick="Show_Vend" runat="server"/><br /><br />
                <asp:GridView ID="vend_gv" runat="server" AllowSorting="true" Visible="false" AutoGenerateColumns="false">
                    <RowStyle BackColor="#ccffff"/>
                    <HeaderStyle Font-Italic="true" Font-Bold="true"/>
                    <Columns>
                        <asp:BoundField HeaderText="Item Name" DataField="Key"/>
                        <asp:BoundField HeaderText="Medicine Vendor" DataField="Value" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
