<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="JobDetails.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.JobDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <body>
  <div class="flex flex-col md:flex-row p-6 bg-background rounded-lg shadow-lg">
    <div class="flex-1">
      <div class="flex items-center mb-4">
        <img src="../public/images/company2.jpg" alt="Company Logo" class="w-12 h-12 rounded-full mr-4" />
        <h1 class="text-2xl font-bold">Backend Developer</h1>
      </div>
      <h2 class="text-lg font-semibold">Derivco</h2>
      <p class="text-muted-foreground">77 Armstrong Ave, La Lucia</p>
      <p class="text-lg font-bold">1200/month</p>
      <h3 class="mt-6 text-lg font-semibold">Job Description</h3>
      <p>A junior backend developer</p>
      <h3 class="mt-4 text-lg font-semibold">Required Knowledge, Skills and Abilities</h3>
      <p>Must be able to code in C#, Python, JavaScript</p>
      <h3 class="mt-4 text-lg font-semibold">Education + Experience</h3>
      <ul class="list-disc list-inside">
        <li>BSC IT/CS</li>
        <li>3 years work experience</li>
      </ul>
      <div class="relative mt-6">
        <h3 class="text-lg font-semibold">Company Information</h3>
        <p>Derivco (Pty) Ltd</p>
        <p>Address: 77 Armstrong Ave, La Lucia, Durban North, 4051, South Africa</p>
        <p>Name: Derivco (Pty) Ltd</p>
        <p>Website: <a href="https://derivco.co.za/" class="text-primary">derivco.co.za</a></p>
        <p>Email: <a href="mailto:hellodurban@derivco.com" class="text-primary">hellodurban@derivco.com</a></p>
        <div class="absolute bottom-0 right-0 mt-6">
        </div>
      </div>
    </div>
    <div class="mt-6 md:mt-0 md:ml-6 bg-card p-4 rounded-lg shadow-md">
      <h3 class="text-lg font-semibold">Job Overview</h3>
      <p><strong>Posted Date:</strong> 23 May 2024</p>
      <p><strong>Location:</strong> Durban</p>
      <p><strong>Vacancy:</strong> 4</p>
      <p><strong>Job nature:</strong> Full Time</p>
      <p><strong>Salary:</strong> 1200/month</p>
      <p><strong>Application Close date:</strong> 31 July 2024</p>
      <button class="bg-[#035772] text-white hover:bg-[#023e58] mt-4 p-2 rounded">Apply</button>
    </div>
  </div>
</body>
</asp:Content>
