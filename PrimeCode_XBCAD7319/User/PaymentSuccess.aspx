<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="PaymentSuccess.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.PaymentSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
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
    <div class="bg-[#035772] p-6 rounded-lg flex justify-center items-start min-h-screen">
      <div class="bg-white text-black p-8 rounded-lg shadow-md text-center max-w-7xl mx-auto">
        <h2 class="text-3xl font-bold mb-6">Thank you</h2>
        <p class="text-xl mb-6">We are pleased to inform you that your payment has been successfully processed. Thank you for choosing our service!</p>
        <h3 class="text-2xl font-semibold mb-4">For Filter Search Users:</h3>
        <p class="text-xl mb-6">You can now log in to your account and continue using the filter search feature without any limitations. We appreciate your trust in us and are here to help you find the perfect job match.</p>
        <h3 class="text-2xl font-semibold mb-4">For CV Option Users:</h3>
        <p class="text-xl mb-6">We are currently processing your request. You will receive an email with the CVs shortly. Please keep an eye on your inbox for further updates.</p>
        <p class="text-xl">If you have any questions or need assistance, feel free to reach out to our support team at <a href="mailto:jobconnector@gmail.com" class="text-blue-600">jobconnector@gmail.com</a> / +27 56 654 6784.</p>
        <p class="text-xl">Thank you for your continued support.</p>
      </div>
    </div>
  </body>
</html>

</asp:Content>
