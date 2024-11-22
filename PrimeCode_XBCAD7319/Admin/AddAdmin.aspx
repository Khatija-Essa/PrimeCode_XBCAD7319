<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddAdmin.aspx.cs" Inherits="PrimeCode_XBCAD7319.Admin.AddAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg-[#035772] min-h-screen flex flex-col items-center pt-20">
        <div class="text-center mb-4">
            <h2 class="text-5xl font-bold text-white">Create Admin</h2>
        </div>
        <div class="bg-white rounded-lg shadow-lg p-8 w-full max-w-2xl"> 
            <asp:Panel runat="server">
                <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Username</label>
                    <asp:TextBox ID="txtUsername" TextMode="SingleLine" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter admin username" runat="server" required></asp:TextBox>
                </div>
                <div class="mb-4">
                    <label class="block text-zinc-700 text-lg">Password</label>
                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter password" runat="server" required></asp:TextBox>
                </div>
                <asp:Button ID="btnCreateAdmin" runat="server" Text="Create Admin" CssClass="bg-[#035772] text-white rounded w-full p-5 text-lg hover:bg-[#A5C8D4]" OnClick="btnCreateAdmin_Click" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>