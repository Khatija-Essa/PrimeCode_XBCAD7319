<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="job_listing.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.job_listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <body>
  <div class="flex flex-col lg:flex-row">
    <div class="p-6 bg-background text-foreground lg:w-1/4">
      <div class="mb-6">
        <h2 class="text-xl font-semibold">Filter Search</h2>
         <h3 class="mt-4 font-semibold">Job Location</h3>
         <select class="border border-border rounded p-2 w-full">
         <option value="" disabled selected>Select job location</option>
         <option value="">Anywhere</option>
         <option value="">Category 1</option>
         <option value="">Category 2</option>
         <option value="">Category 3</option>
         <option value="">Category 4</option>

        </select>

        <h3 class="mt-4 font-semibold">Job Type</h3>
        <div class="flex flex-col">
          <label class="flex items-center">
            <input type="checkbox" class="mr-2" /> Full Time
          </label>
          <label class="flex items-center">
            <input type="checkbox" class="mr-2" /> Part Time
          </label>
          <label class="flex items-center">
            <input type="checkbox" class="mr-2" /> Remote
          </label>
          <label class="flex items-center">
            <input type="checkbox" class="mr-2" /> Freelance
          </label>
        </div>
        <h3 class="mt-4 font-semibold">Posted Within</h3>
        <div class="flex flex-col">
          <label class="flex items-center">
            <input type="checkbox" class="mr-2" /> Today
          </label>
          <label class="flex items-center">
            <input type="checkbox" class="mr-2" /> Last 2 days
          </label>
          <label class="flex items-center">
            <input type="checkbox" class="mr-2" /> Last 5 days
          </label>
          <label class="flex items-center">
            <input type="checkbox" class="mr-2" /> Last 10 days
          </label>
        </div>
        <button class="mt-4 bg-[#035772] text-white p-4 rounded min-w-[150px]">Filter</button>
      </div>
    </div>

    <div class="p-6 bg-background text-foreground lg:w-3/4">
      <h2 class="text-xl font-semibold">Total 3 jobs found</h2>
      <div class="mt-4 border border-border rounded p-4 mb-4">
        <div class="flex items-center">
          <img src="../public/images/comapny1.jpg" alt="Web Developer" class="w-16 h-16 mr-4 rounded-full" />
          <div>
            <h3 class="font-bold">Web Developer</h3>
            <p>1500/month - Freelance</p>
            <p><span class="font-semibold">Location:</span> 12 Frosterley Cres, La Lucia Ridge</p>
            <p><span class="font-semibold">Posted:</span> 7 days ago</p>
          </div>
        </div>
      </div>
      <div class="mt-4 border border-border rounded p-4 mb-4">
        <div class="flex items-center">
          <img src="../public/images/company2.jpg" alt="Backend Developer" class="w-16 h-16 mr-4 rounded-full" />
          <div>
            <h3 class="font-bold">Backend Developer</h3>
            <p>1200/month - Full Time</p>
            <p><span class="font-semibold">Location:</span> 77 Armstrong Ave, La Lucia</p>
            <p><span class="font-semibold">Posted:</span> 4 days ago</p>
          </div>
        </div>
      </div>
      <div class="mt-4 border border-border rounded p-4 mb-4">
        <div class="flex items-center">
          <img src="../public/images/comapny3.jpg" alt="Talksure" class="w-16 h-16 mr-4 rounded-full" />
          <div>
            <h3 class="font-bold">Backend Developer</h3>
            <p>2200/month - Full Time</p>
            <p><span class="font-semibold">Location:</span> 62 Umhlanga Ridge Blvd</p>
            <p><span class="font-semibold">Posted:</span> 10 days ago</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</body>
</asp:Content>
