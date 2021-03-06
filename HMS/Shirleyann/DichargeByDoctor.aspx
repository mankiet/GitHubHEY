﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DichargeByDoctor.aspx.cs" Inherits="HMS.DichargeByDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <title></title>

<body>

    <div style="margin-left:350px">
    <div style="font-size:2em"><strong>List of Patients to be Discharged Today</strong></div>
        <asp:Label ID="lblDisplay" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="View" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" CellPadding="4" GridLines="None" ForeColor="#333333" OnItemDeleting="DetailsView1_ItemDeleting" OnModeChanging="DetailsView1_ModeChanging">
            <AlternatingRowStyle BackColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <EditRowStyle BackColor="#2461BF" />
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <Fields>
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" NewText="Approve" ShowDeleteButton="True" DeleteText="Reject"/>
            </Fields>
            <FooterStyle BackColor="#507CD1" ForeColor="#507CD1" Font-Bold="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <HeaderTemplate>Patient's Information</HeaderTemplate>
            <FooterTemplate>Patient's Information</FooterTemplate>
        </asp:DetailsView>
    
        <strong><asp:Label ID="lblExtraDays" runat="server" Text="Extra days:" Visible="False"></asp:Label>&nbsp;<asp:TextBox ID="txtExtraDays" runat="server" Visible="False"></asp:TextBox>
&nbsp;
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Visible="False" />
        </strong>
    
    </div>
    <br />
</body>
</html>
</asp:Content>