<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMaster.Master" AutoEventWireup="true" CodeBehind="CompanyHome.aspx.cs" Inherits="PrimeCode_XBCAD7319.Company.CompanyHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
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
                                customBackground: '#035772',
                                customButton: '#035772',
                                customHover: '#A5C8D4',
                                foreground: 'hsl(var(--foreground))',
                                white: '#ffffff',
                            },
                            spacing: {
                                '18': '4.5rem',
                            },
                        },
                    },
                }
            </script>
        </head>
        <body class="bg-customBackground">
            <div class="bg-white p-12 rounded-lg shadow-lg text-center max-w-7xl mx-auto mt-20">
                <h1 class="text-3xl font-bold text-foreground">Welcome employee to Job Connector</h1>
                <p class="text-lg text-muted-foreground mt-3">Your dashboard for managing job posting and applications</p>
                <p class="mt-6 text-lg text-muted-foreground mb-8">
                    Effortlessly post new job openings to attract qualified candidates. On the upload a job page, you can provide detailed job descriptions, list required qualifications, and specify job locations. Manage and update your job listings to keep them current and relevant, ensuring you reach the best candidates for your roles.
                </p>

                <asp:LinkButton ID="LinkButton2" runat="server" class="bg-customButton text-white hover:bg-[#A5C8D4] mt-10 px-6 py-3 rounded-lg" OnClick="LinkButton2_Click">Upload Job</asp:LinkButton>

                <h2 class="text-xl font-semibold mt-8">We offer tailored CVs to meet your hiring needs:</h2>
                <ul class="list-disc list-inside text-lg text-muted-foreground mt-3">
                    <li>Up to 5 CVs for R50</li>
                    <li>Up to 10 CVs for R100</li>
                    <li>Additional CVs available at R20 each</li>
                </ul>

                <p class="mt-6 text-lg text-muted-foreground mb-8">
                    To proceed, please ensure payment is completed. CVs will be sent to the email address provided during your registration upon confirmation of payment.
                </p>
                <asp:LinkButton ID="LinkButton1" runat="server" class="bg-customButton text-white hover:bg-[#A5C8D4] mt-10 px-6 py-3 rounded-lg" OnClick="LinkButton1_Click">Payment</asp:LinkButton>
            </div>
        </body>
    </html>
</asp:Content>
