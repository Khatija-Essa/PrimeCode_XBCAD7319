<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
    <div class="bg-[#035772] min-h-screen flex flex-col items-center justify-center py-10 pb-40">
        <div class="text-center mb-4">
            <h2 class="text-5xl font-bold text-white">Sign Up</h2>
            <p class="text-3xl text-white mt-2">Create your registration</p>
            <div class="col-12 p-8">
                <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="bg-white rounded-lg shadow-lg p-8 w-full max-w-4xl"> 
            <asp:Panel runat="server">
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Username</label>
                    <asp:TextBox ID="txtUserName" TextMode="SingleLine" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your username" runat="server" required></asp:TextBox>
                </div>
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Password</label>
                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your password" runat="server" required></asp:TextBox>
                </div>
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Confirm Password</label>
                    <asp:TextBox ID="txtComfirmPassword" TextMode="Password" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Confirm your password" runat="server" required></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password and confirm password should be the same"
                        ControlToCompare="txtPassword" ControlToValidate="txtComfirmPassword" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" 
                        Font-Size="Small"></asp:CompareValidator>
                </div>
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">User Type</label> 
                    <asp:DropDownList ID="ddlUserType" runat="server" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" required>
                        <asp:ListItem Value="">Select user type</asp:ListItem>
                        <asp:ListItem Value="user">User</asp:ListItem>
                        <asp:ListItem Value="partner">Partner</asp:ListItem>
                        <asp:ListItem Value="company">Company</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <h3 class="text-lg font-semibold text-zinc-800">Personal Details</h3>
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Full Name</label>
                    <asp:TextBox ID="txtFullName" TextMode="SingleLine" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your full name" runat="server" required></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name must be in characters" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" 
                        Font-Size="Small" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtFullName"></asp:RegularExpressionValidator>
                </div>
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Address</label> 
                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your address" runat="server" required></asp:TextBox>
                </div>
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Phone Number</label> 
                    <asp:TextBox ID="txtMobile" TextMode="SingleLine" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your Phone Number" runat="server" required></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Phone number must have 10 digits" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" 
                        Font-Size="Small" ValidationExpression="^[0-9]{10}$" ControlToValidate="txtMobile"></asp:RegularExpressionValidator>
                </div>
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Email</label> 
                    <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your Email" runat="server"></asp:TextBox>
                </div>
                <div class="mb-8">
                    <label class="block text-zinc-700 text-lg">Province</label>
                    <asp:DropDownList ID="ddlProvinces" runat="server" DataSourceID="SqlDataSource1" CssClass="border border-zinc-300 rounded w-full p-3 text-lg"
                        AppendDataBoundItems="True" DataTextField="ProvinceName" DataValueField="ProvinceName">
                        <asp:ListItem Value="0">Select Province</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Province is required"
                        ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" 
                        ControlToValidate="ddlProvinces" ></asp:RequiredFieldValidator>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JobConnectorConnectionString2 %>" 
                        ProviderName="<%$ ConnectionStrings:JobConnectorConnectionString2.ProviderName %>" SelectCommand="SELECT [ProvinceName] FROM [Province]"></asp:SqlDataSource>
                </div>
                <asp:Button ID="btnRegister" runat="server" Text="Sign Up" CssClass="bg-[#035772] text-white rounded w-full p-5 text-lg hover:bg-[#A5C8D4]" 
                    Onclick="btnRegister_Click" />
                <div class="text-center mt-4">
                    <span class="clickLink">
                        <a href="../User/Login.aspx" class="text-blue-500 hover:underline">Already Registered? Login</a>
                    </span>
                </div>
            </asp:Panel>
        </div>
    </div>
</body>
</asp:Content>
