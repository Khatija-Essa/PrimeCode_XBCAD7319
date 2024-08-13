<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PrimeCode_XBCAD7319.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2 class="text-3xl font-semibold mb-4">DASHBOARD</h2>
  <p class="text-muted-foreground mb-8">Welcome to Job Connector Admin Dashboard</p>

  <div class="grid grid-cols-2 gap-4 mb-8">
    <div class="bg-card p-4 rounded-lg shadow-md">
      <h3 class="text-lg font-semibold">Total Active Users</h3>
    </div>
    <div class="bg-card p-4 rounded-lg shadow-md">
      <h3 class="text-lg font-semibold">Total Job</h3>
    </div>
    <div class="bg-card p-4 rounded-lg shadow-md">
      <h3 class="text-lg font-semibold">Generated CV</h3>
    </div>
    <div class="bg-card p-4 rounded-lg shadow-md">
      <h3 class="text-lg font-semibold">Contacted User</h3>
    </div>
    <div class="bg-card p-4 rounded-lg shadow-md">
      <h3 class="text-lg font-semibold">Partner CV's</h3>
    </div>
  </div>
</asp:Content>
