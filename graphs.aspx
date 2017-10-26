<%@ Page Language="C#" AutoEventWireup="true" CodeFile="graphs.aspx.cs" Inherits="graphs" MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID="HomePage" runat="server">
    <asp:Chart runat="server" ID="char1">
        <Series>
            <asp:Series Name="Series1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <br />
    <br />
    <br />
    <asp:DropDownList Width="100px" ID="medchart" runat="server" OnSelectedIndexChanged="medchart_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    <br />
    <br />
    <br />
    <asp:Chart ID="Chart2" runat="server" >
        <Series>
            <asp:Series Name="Series1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

</asp:Content>
