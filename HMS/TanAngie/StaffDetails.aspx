﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StaffDetails.aspx.cs" Inherits="StaffManagement.StaffDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">

       .auto-style1 {
            width: 158px;
        }
        .auto-style2 {
            width: 158px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            width: 158px;
            height: 23px;
        }
        .auto-style5 {
            height: 23px;
        }
        </style>

    <div class="background">
        
        <div>
            <h1 style="color:darkblue">Staff Details</h1>
        </div>
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">Staff ID :</td>
                    <td>
                        <asp:TextBox ID="tbStaffId" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Name :</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="tbName" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">IC Number :</td>
                    <td>
                        <asp:TextBox ID="tbIC" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Gender :</td>
                    <td>
                        <asp:TextBox ID="tbGender" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Home Address :</td>
                    <td>
                        <asp:TextBox ID="tbAddress" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Contact Number :</td>
                    <td>
                        <asp:TextBox ID="tbContactNum" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Email Address :</td>
                    <td>
                        <asp:TextBox ID="tbEmail" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td class="auto-style1">Department and Position</td>
                    <td>&nbsp;</td>
                </tr><tr>
                    <td class="auto-style2">Department :</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="tbDepartment" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr><tr>
                    <td class="auto-style1">Position :</td>
                    <td >
                        <asp:TextBox ID="tbPosition" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Salary :</td>
                    <td>
                        <asp:TextBox ID="tbSalary" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Status :</td>
                    <td>
                        <asp:TextBox ID="tbStatus" runat="server" Enabled="False" BackColor="#99CCFF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td>
                        
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="To update staff's details." OnClick="btnUpdate_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text="Delete/Retired" ToolTip="To change the staff's status" OnClick="btnDelete_Click" />
                        
                        <asp:Button ID="btnChangePassword" runat="server" PostBackUrl="~/TanAngie/LoginChangePassword.aspx" Text="Change Password" Visible="False" />
                        
                    </td>
                </tr>
            </table>
        </div>
    
    </div>
</asp:Content>