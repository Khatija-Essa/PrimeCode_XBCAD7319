<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="bg-[#035772] min-h-screen flex flex-col items-center justify-start pt-6 pb-20">
        <div class="text-center mb-4">
            <h2 class="text-5xl font-bold text-white">Login</h2> 
            <p class="text-3xl text-white mt-2">Please enter your details</p>
            <asp:Label ID="lblMsg" runat="server" CssClass="text-red-500 mt-2 block" Visible="false"></asp:Label>
        </div>
        <div class="bg-white rounded-lg shadow-lg p-8 w-full max-w-xl">
            <form class="mt-4">
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Username</label>
                    <asp:TextBox ID="txtUserName" TextMode="SingleLine" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your username" runat="server" required></asp:TextBox>
                </div>
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Password</label>
                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your password" runat="server" required></asp:TextBox>
                </div>
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">User Type</label>
                    <asp:DropDownList ID="ddlUserType" runat="server" CssClass="border border-zinc-300 rounded w-full p-3 text-lg">
                        <asp:ListItem Value="0">Select User Type</asp:ListItem>
                        <asp:ListItem>User</asp:ListItem>
                        <asp:ListItem>Admin</asp:ListItem>
                        <asp:ListItem>Partner</asp:ListItem>
                        <asp:ListItem>Company</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User Type is required"
                        ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" 
                        ControlToValidate="ddlUserType">
                    </asp:RequiredFieldValidator>
                </div>

                 
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="bg-[#035772] text-white rounded w-full p-5 text-lg hover:bg-[#A5C8D4]"
                    OnClick="btnLogin_Click" />
                <div class="text-center mt-4">
                    <span class="clickLink">
                        <a href="ChangePassword.aspx" class="text-blue-500 hover:underline">Want to change your password?</a>
                    </span>
                </div>
                
                <div class="text-center mt-4">
                    <span class="clickLink">
                        <a href="../User/register.aspx" class="text-blue-500 hover:underline">New Here? Register</a>
                    </span>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
