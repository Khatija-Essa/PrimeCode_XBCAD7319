<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeDashboard.aspx.cs" Inherits="PrimeCode_XBCAD7319.Employee.EmployeeDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
    <div class="bg-[#035772] min-h-screen flex flex-col items-center justify-center py-10 pb-20"> 
  
  <div class="bg-zinc-200 p-4 rounded-lg mb-6">
   
    <h2 class="text-2xl font-semibold mb-4">Welcome employee to Job Connector</h2>
  <p class="text-muted-foreground mb-6">Your dashboard for managing job posting and applications</p>

  <p class="mb-4">
    Effortlessly post new job openings to attract qualified candidates. On the upload a job page, you can provide detailed job descriptions, list required qualifications, and specify job locations.
    Manage and update your job listings to keep them current and relevant, ensuring you reach the best candidates for your roles.
  </p>

  <button class="bg-secondary text-secondary-foreground hover:bg-secondary/80 p-2 rounded-lg mb-4">Upload Job</button>

  <h3 class="text-2xl font-semibold mb-2">Payment</h3>
  <p class="text-muted-foreground mb-4">We offer tailored CVs to meet your hiring needs:</p>
  <ul class="list-disc list-inside mb-4">
    <li>Up to 5 CVs for R500</li>
    <li>Up to 10 CVs for R100</li>
    <li>Additional CVs available at R20 each</li>
  </ul>
  <p class="mb-4">To proceed, please ensure payment is completed. CVs will be sent to the email address provided during your registration upon confirmation of payment.</p>
  <p class="text-muted-foreground">We appreciate your cooperation.</p>

     <button class="bg-secondary text-secondary-foreground hover:bg-secondary/80 p-2 rounded-lg mb-4">Proceed to payment</button>
       </div>
</div>
    </body>
</asp:Content>
