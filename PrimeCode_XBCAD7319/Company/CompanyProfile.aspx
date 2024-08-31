<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMaster.Master" AutoEventWireup="true" CodeBehind="CompanyProfile.aspx.cs" Inherits="PrimeCode_XBCAD7319.Company.CompanyProfile" %>
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
    <div class="flex flex-col lg:flex-row items-start bg-[#035772] p-6 pb-24 rounded-lg shadow-lg min-h-screen">
        <asp:DataList ID="dlProfile" runat="server" Width="100%" OnItemCommand="dlProfile_ItemCommand">
            <ItemTemplate>
<div class="relative flex flex-col lg:flex-row bg-[#035772] p-6 min-h-screen">
    <!-- Left Side: Profile Picture and Information -->
    <div class="flex flex-col items-center bg-[#035772] p-6 rounded-lg shadow-lg w-full lg:w-1/4">
        <img class="rounded-full mb-4 border-4 border-white" src='<%# Eval("ProfileImage") != DBNull.Value && !string.IsNullOrEmpty(Eval("ProfileImage").ToString()) ? ResolveUrl(Eval("ProfileImage").ToString()) : ResolveUrl("~/public/images/No_image.jpg") %>' alt="Profile Picture" width="150" height="150" />
        <h2 class="text-3xl font-bold text-white capitalize"><%# Eval("Name") %></h2>
        <p class="text-xl text-white mt-2">@<%# Eval("Username") %></p>
        <p class="text-lg text-white capitalize mt-2"><%# Eval("Province") %></p>
        <asp:FileUpload ID="fuProfileImage" runat="server" CssClass="mb-4 text-white" />
        <asp:LinkButton ID="btnUploadImage" runat="server" Text="Upload Image" CssClass="bg-[#A5C8D4] text-[#035772] font-semibold px-4 py-2 rounded-md hover:bg-[#86b1c3]" CommandName="UploadImage" CommandArgument='<%# Eval("CompanyId") %>'></asp:LinkButton>
    </div>

    <!-- Right Side: Company Details -->
    <div class="flex flex-col items-center bg-white rounded-lg p-4 shadow-lg w-full lg:w-1/3 lg:ml-8 mt-8 lg:mt-0">
        <h3 class="text-xl font-medium text-primary mb-4">Company Details</h3>
        <div class="mb-4 w-full">
            <h6 class="font-bold mb-2 text-black">Full Name</h6>
            <asp:TextBox ID="txtName" runat="server" CssClass="w-full p-3 border border-black rounded" Text='<%# Eval("Name") %>'></asp:TextBox>
        </div>
        <div class="mb-4 w-full">
            <h6 class="font-bold mb-2 text-black">Email</h6>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="w-full p-3 border border-black rounded" Text='<%# Eval("Email") %>'></asp:TextBox>
        </div>
        <div class="mb-4 w-full">
            <h6 class="font-bold mb-2 text-black">Phone</h6>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="w-full p-3 border border-black rounded" Text='<%# Eval("Mobile") %>'></asp:TextBox>
        </div>
        <div class="mb-4 w-full">
            <h6 class="font-bold mb-2 text-black">Address</h6>
            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="w-full p-3 border border-black rounded" Text='<%# Eval("Address") %>'></asp:TextBox>
        </div>
        <div class="mt-6 flex space-x-4">
            <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" CssClass="bg-[#035772] text-white font-semibold px-8 py-4 rounded-md hover:bg-[#A5C8D4]" CommandArgument='<%# Eval("CompanyId") %>' OnClick="btnSaveChanges_Click" />
        </div>
    </div>
</div>
      </ItemTemplate>
        </asp:DataList>
    </div>
</body>
</html>
</asp:Content>
