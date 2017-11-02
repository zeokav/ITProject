<%@ Page Language="C#" AutoEventWireup="true" CodeFile="graphs.aspx.cs" Inherits="graphs" MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID="HomePage" runat="server">
    Choose which graph: <asp:DropDownList Width="250px" ID="medchart" runat="server" OnSelectedIndexChanged="medchart_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
    <br />
    <br />
    <br />
    <div class="form-holder" style="width:100%; text-align: center;">
        <asp:Label ID="msg" runat="server" CssClass="text-muted"></asp:Label>
        <asp:Chart ID="Chart2" runat="server" Width="700px" Height="700px">
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <br />
        <br />
        <asp:Label ID="er" runat="server"></asp:Label>
    </div>
    
</asp:Content>
