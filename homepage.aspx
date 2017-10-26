<%@ Page Language="C#" AutoEventWireup="true" CodeFile="homepage.aspx.cs" Inherits="homepage" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="HomePage" runat="server">
    <h1>Summary</h1>
    <asp:Label ID="errmsg" runat="server"></asp:Label>
    <div class="row">
        <div class="col-md-4">
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
                    
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-4">
            <h3>Expired Medicines</h3>
            <asp:Label ID="ExpStatus" runat="server" CssClass="text-muted"></asp:Label><br /><br />
            <asp:Button Text="Show/Hide" OnClick="Show_Exp" runat="server"/><br /><br />
            <asp:GridView ID="exp_gv" runat="server" AllowSorting="true" Visible="false" AutoGenerateColumns="false">
                <RowStyle BackColor="#ccffff"/>
                <HeaderStyle Font-Italic="true" Font-Bold="true"/>
                <Columns>

                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-4">
            <h3>The other thing</h3>
        </div>
    </div>
</asp:Content>
