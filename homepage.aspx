<%@ Page Language="C#" AutoEventWireup="true" CodeFile="homepage.aspx.cs" Inherits="homepage" MasterPageFile="~/MasterPage.master" %>

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
        
        <asp:Button ID="submitbut" OnClick="submitbut_Click" Text="Search" runat="server" CssClass="btn btn-md btn-default col-sm-offset-2"/><br />
        <asp:Button ID="historybutt" OnClick="history" Text="History" runat="server" CssClass="btn btn-md btn-default col-sm-offset-2"/>
        <br />
        <br />
        <asp:Label ID="errorText" runat="server"></asp:Label>
        <br />
        <br />
        <asp:DetailsView ID="findmed" runat="server" AutoGenerateColumns="true" Width="100px" CellSpacing="2" CellPadding="10">
            
        </asp:DetailsView>


        

        <asp:Label runat="server" ID="historyLabel" Text="Purana = "></asp:Label>


    </div>





    <asp:Panel ID="pnl" runat="server">
        <asp:Label ID="errmsg" runat="server"></asp:Label>
    <h1>Revenue for the day</h1>
         <asp:Label ID="rev" runat="server"></asp:Label>
     
    <h1>Summary</h1>
        <div class="row">
            <div class="col-md-4">


                <asp:ScriptManager ID="ScriptManager" runat="server" >
                </asp:ScriptManager>

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
