<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-[#035772] min-h-screen flex flex-col items-center justify-start pt-6 pb-20">
        <div class="text-center mb-4">
            <h2 class="text-5xl font-bold text-white">Change Password</h2> 
            <p class="text-3xl text-white mt-2">Enter your details to change your password</p>
            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
        </div>
        
        <div class="bg-white rounded-lg shadow-lg p-8 w-full max-w-xl">
            <form class="mt-4">
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">User Type</label>
                    <asp:DropDownList ID="ddlUserType" runat="server" CssClass="border border-zinc-300 rounded w-full p-3 text-lg">
                        <asp:ListItem Value="0">Select User Type</asp:ListItem>
                        <asp:ListItem>User</asp:ListItem>
                        <asp:ListItem>Company</asp:ListItem>
                        <asp:ListItem>Partner</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User Type is required"
                        ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" 
                        ControlToValidate="ddlUserType">
                    </asp:RequiredFieldValidator>
                </div>

                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Username</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" 
                        placeholder="Enter your username" required></asp:TextBox>
                </div>

                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Current Password</label>
                    <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" 
                        CssClass="border border-zinc-300 rounded w-full p-3 text-lg" 
                        placeholder="Enter your current password" required></asp:TextBox>
                </div>

                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">New Password</label>
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" 
                        CssClass="border border-zinc-300 rounded w-full p-3 text-lg" 
                        placeholder="Enter your new password" required></asp:TextBox>
                </div>

                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Confirm New Password</label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" 
                        CssClass="border border-zinc-300 rounded w-full p-3 text-lg" 
                        placeholder="Confirm your new password" required></asp:TextBox>
                </div>

                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" 
                    CssClass="bg-[#035772] text-white rounded w-full p-5 text-lg hover:bg-[#A5C8D4]" 
                    OnClick="btnChangePassword_Click" />

                <div class="text-center mt-4">
                    <span class="clickLink">
                        <a href="../User/Login.aspx" class="text-blue-500 hover:underline">Back to Login</a>
                    </span>
                </div>
            </form>
        </div>
    </div>
</asp:Content>