<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistrationForm.aspx.cs"
    Inherits="RegistrationForm.UserRegistrationForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        .table td
        {
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblId" Visible="false" runat="server" Text=""></asp:Label>
        <table class="table">
            <tr>
                <td colspan="2">
                    <b>Registration Form</b>
                </td>
            </tr>
            <tr>
                <td align="right">
                    User Name
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="valGroup" ID="RequiredFieldValidator1"
                        ForeColor="Red" ControlToValidate="txtUserName" runat="server" ErrorMessage="*">UserName is required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Password
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="valGroup" ID="RequiredFieldValidator2"
                        ForeColor="Red" ControlToValidate="txtPassword" runat="server" ErrorMessage="*">Password is required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Confirm Password
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:CompareValidator ValidationGroup="valGroup" ID="CompareValidator1" ControlToValidate="txtPassword"
                        ControlToCompare="txtConfirmPassword" ForeColor="Red" runat="server" ErrorMessage="CompareValidator">Password do not match</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    First Name
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="valGroup" ID="RequiredFieldValidator3"
                        ForeColor="Red" ControlToValidate="txtFirstName" runat="server" ErrorMessage="*">First name is required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Last Name
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="valGroup" ID="RequiredFieldValidator4"
                        ForeColor="Red" ControlToValidate="txtLastName" runat="server" ErrorMessage="*">Last name is required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Email
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="valGroup" ID="RequiredFieldValidator5"
                        ForeColor="Red" ControlToValidate="txtEmail" runat="server" ErrorMessage="*">Email is required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Phone No.
                </td>
                <td>
                    <asp:TextBox ID="txtPhoneNo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="valGroup" ID="RequiredFieldValidator6"
                        ForeColor="Red" ControlToValidate="txtPhoneNo" runat="server" ErrorMessage="*">Phone No. is required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Location
                </td>
                <td>
                    <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="valGroup" ID="RequiredFieldValidator7"
                        ForeColor="Red" ControlToValidate="txtLocation" runat="server" ErrorMessage="*">Location is required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSave" ValidationGroup="valGroup" runat="server" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnUpdate" Visible="false" ValidationGroup="valGroup" runat="server"
                        Text="Update" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblMessage" ForeColor="Green" Visible="false" runat="server" Text=""></asp:Label>
        <table width="80%">
            <tr>
                <td>
                    <asp:GridView HeaderStyle-BackColor="Blue" Width="100%" HeaderStyle-ForeColor="White"
                        CssClass="table" ID="GridViewStudent" runat="server" DataKeyNames="Id" OnSelectedIndexChanged="GridViewStudent_SelectedIndexChanged"
                        OnRowDeleting="GridViewStudent_RowDeleting">
                        <Columns>
                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True" />
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
