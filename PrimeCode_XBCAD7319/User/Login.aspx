<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <body>
       <div class="bg-[#035772] min-h-screen flex flex-col items-center justify-center py-10 pb-20"> 
               <h2 class="text-4xl font-bold text-white">Login</h2>
<p class="text-2xl text-white">Please enter your details</p>
      <div class="bg-card p-8 rounded-lg shadow-lg w-full max-w-md">
     <form class="mt-4">
      <div class="mb-4">
        <label class="block text-muted-foreground" for="username">Username</label>
        <input class="border border-border rounded-lg w-full p-2" type="text" id="username" placeholder="Enter your username" required />
      </div>
      <div class="mb-4">
        <label class="block text-muted-foreground" for="password">Password</label>
        <input class="border border-border rounded-lg w-full p-2" type="password" id="password" placeholder="Enter your password" required />
      </div>
      <div class="mb-4">
        <label class="block text-muted-foreground" for="user-type">User Type</label>
        <select class="border border-border rounded-lg w-full p-2" id="user-type" required>
          <option value="" disabled selected>Select user type</option>
          <option value="job-seeker">Job Seeker</option>
          <option value="employer">Employer</option>
        </select>
      </div>
      <button class="bg-secondary text-secondary-foreground hover:bg-secondary/80 rounded-lg w-full p-2" type="submit">Login</button>
    </form>
  </div>
</body>
</asp:Content>
