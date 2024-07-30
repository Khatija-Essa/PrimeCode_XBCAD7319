<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <body>
  <div class="bg-[#035772] min-h-screen flex flex-col items-center justify-center py-10 pb-20"> 
    <div class="text-center mb-4">
      <h2 class="text-4xl font-bold text-white">Sign Up</h2>
      <p class="text-2xl text-white">Create your registration</p>
    </div>
    <div class="bg-white rounded-lg shadow-lg p-8 w-full max-w-xl"> 
      <form class="mt-4">
        <div class="mb-4">
          <label class="block text-zinc-700 text-lg">Username</label> 
          <input type="text" class="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your username" required>
        </div>
        <div class="mb-4">
          <label class="block text-zinc-700 text-lg">Password</label> 
          <input type="password" class="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your password" required> 
          <label class="block text-zinc-700 text-lg">User Type</label> 
          <select class="border border-zinc-300 rounded w-full p-3 text-lg"> 
            <option value="">Select user type</option>
            <option value="user">User</option>
            <option value="admin">Admin</option>
            <option value="partner">Partner</option>
            <option value="company">Company</option>
          </select>
        </div>
        <h3 class="text-lg font-semibold text-zinc-800">Personal Details</h3>
        <div class="mb-4">
          <label class="block text-zinc-700 text-lg">Address</label> 
          <input type="text" class="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your address" required> 
        </div>
        <div class="mb-4">
          <label class="block text-zinc-700 text-lg">Phone Number</label> 
          <input type="tel" class="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your phone number" required> 
        </div>
        <div class="mb-4">
          <label class="block text-zinc-700 text-lg">Email</label> 
          <input type="email" class="border border-zinc-300 rounded w-full p-3 text-lg" placeholder="Enter your email" required> 
        </div>
        <div class="mb-8">
          <label class="block text-zinc-700 text-lg">Country</label> 
          <select class="border border-zinc-300 rounded w-full p-3 text-lg"> 
            <option value="">Category 1</option>
            <option value="">Category 2</option>
            <option value="">Category 3</option>
            <option value="">Category 4</option>
          </select>
        </div>
        <button type="submit" class="bg-[#035772] text-white rounded w-full p-5 text-lg hover:bg-[#005f60]">Sign Up</button> 
      </form>
    </div>
  </div>
</body>

</asp:Content>
