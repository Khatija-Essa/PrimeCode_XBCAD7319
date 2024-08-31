﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PrimeCode_XBCAD7319.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <script src="https://cdn.tailwindcss.com?plugins=forms,typography"></script>
  <script src="https://unpkg.com/unlazy@0.11.3/dist/unlazy.with-hashing.iife.js" defer init></script>
  <script type="text/javascript">
      window.tailwind.config = {
          darkMode: ['class'],
          theme: {
              extend: {
                  colors: {
                      border: 'hsl(var(--border))',
                      input: 'hsl(var(--input))',
                      ring: 'hsl(var(--ring))',
                      background: 'hsl(var(--background))',
                      foreground: 'hsl(var(--foreground))',
                      primary: {
                          DEFAULT: 'hsl(var(--primary))',
                          foreground: 'hsl(var(--primary-foreground))'
                      },
                      secondary: {
                          DEFAULT: 'hsl(var(--secondary))',
                          foreground: 'hsl(var(--secondary-foreground))'
                      },
                      destructive: {
                          DEFAULT: 'hsl(var(--destructive))',
                          foreground: 'hsl(var(--destructive-foreground))'
                      },
                      muted: {
                          DEFAULT: 'hsl(var(--muted))',
                          foreground: 'hsl(var(--muted-foreground))'
                      },
                      accent: {
                          DEFAULT: 'hsl(var(--accent))',
                          foreground: 'hsl(var(--accent-foreground))'
                      },
                      popover: {
                          DEFAULT: 'hsl(var(--popover))',
                          foreground: 'hsl(var(--popover-foreground))'
                      },
                      card: {
                          DEFAULT: 'hsl(var(--card))',
                          foreground: 'hsl(var(--card-foreground))'
                      },
                  },
              }
          }
      }
  </script>
  <style type="text/tailwindcss">
    @layer base {
      :root {
        --background: 0 0% 100%;
        --foreground: 240 10% 3.9%;
        --card: 0 0% 100%;
        --card-foreground: 240 10% 3.9%;
        --popover: 0 0% 100%;
        --popover-foreground: 240 10% 3.9%;
        --primary: 240 5.9% 10%;
        --primary-foreground: 0 0% 98%;
        --secondary: 240 4.8% 95.9%;
        --secondary-foreground: 240 5.9% 10%;
        --muted: 240 4.8% 95.9%;
        --muted-foreground: 240 3.8% 46.1%;
        --accent: 240 4.8% 95.9%;
        --accent-foreground: 240 5.9% 10%;
        --destructive: 0 84.2% 60.2%;
        --destructive-foreground: 0 0% 98%;
        --border: 240 5.9% 90%;
        --input: 240 5.9% 90%;
        --ring: 240 5.9% 10%;
        --radius: 0.5rem;
      }
      .dark {
        --background: 240 10% 3.9%;
        --foreground: 0 0% 98%;
        --card: 240 10% 3.9%;
        --card-foreground: 0 0% 98%;
        --popover: 240 10% 3.9%;
        --popover-foreground: 0 0% 98%;
        --primary: 0 0% 98%;
        --primary-foreground: 240 5.9% 10%;
        --secondary: 240 3.7% 15.9%;
        --secondary-foreground: 0 0% 98%;
        --muted: 240 3.7% 15.9%;
        --muted-foreground: 240 5% 64.9%;
        --accent: 240 3.7% 15.9%;
        --accent-foreground: 0 0% 98%;
        --destructive: 0 62.8% 30.6%;
        --destructive-foreground: 0 0% 98%;
        --border: 240 3.7% 15.9%;
        --input: 240 3.7% 15.9%;
        --ring: 240 4.9% 83.9%;
      }
    }
  </style>
</head>
<body>
  <div class="container mx-auto p-4">
    <h1 class="text-5xl font-bold text-center mb-4">DASHBOARD</h1>
    <p class="text-xl text-center mb-6">Welcome to Job Connector Admin Dashboard</p>
    <div class="flex flex-wrap justify-center gap-4">
      <div class="flex flex-col items-center justify-center h-40 w-56 bg-[#035772] text-white rounded-lg hover:bg-[#A5C8D4]">
        <span>Total Users</span>
        <div class="row-align-items-center mb-2 d-flex">
            <div class="col-8">
                <h2 class="d-flex row-align-items-center mb-0">
                    <%Response.Write(Session["Users"]);%>
                </h2>
            </div>
        </div>
      </div>
      
      <div class="flex flex-col items-center justify-center h-40 w-56 bg-[#035772] text-white rounded-lg hover:bg-[#A5C8D4]">
        <span>Total Jobs</span>
        <div class="row-align-items-center mb-2 d-flex">
            <div class="col-8">
                <h2 class="d-flex row-align-items-center mb-0">
                    <%Response.Write(Session["Jobs"]);%>
                </h2>
            </div>
        </div>
      </div>
      
      <div class="flex flex-col items-center justify-center h-40 w-56 bg-[#035772] text-white rounded-lg hover:bg-[#A5C8D4]">
        <span>Applied Jobs</span>
        <div class="row-align-items-center mb-2 d-flex">
            <div class="col-8">
                <h2 class="d-flex row-align-items-center mb-0">
                    <%Response.Write(Session["AppliedJobs"]);%>
                </h2>
            </div>
        </div>
      </div>
      
      <div class="flex flex-col items-center justify-center h-40 w-56 bg-[#035772] text-white rounded-lg hover:bg-[#A5C8D4]">
        <span>Contacted Users</span>
        <div class="row-align-items-center mb-2 d-flex">
            <div class="col-8">
                <h2 class="d-flex row-align-items-center mb-0">
                    <%Response.Write(Session["Contact"]);%>
                </h2>
            </div>
        </div>
      </div>
      
      <div class="flex flex-col items-center justify-center h-40 w-56 bg-[#035772] text-white rounded-lg hover:bg-[#A5C8D4]">
        <span>Partners</span>
        <div class="row-align-items-center mb-2 d-flex">
            <div class="col-8">
                <h2 class="d-flex row-align-items-center mb-0">
                    <%Response.Write(Session["Partner"]);%>
                </h2>
            </div>
        </div>
      </div>
    </div>
  </div>
</body>

</asp:Content>