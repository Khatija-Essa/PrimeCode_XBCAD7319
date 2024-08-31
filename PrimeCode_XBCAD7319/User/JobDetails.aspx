<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="JobDetails.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.JobDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <script src="https://cdn.tailwindcss.com?plugins=forms,typography"></script>
        <style type="text/tailwindcss">
            .custom-image {
                width: 100px;
                height: 100px;
                object-fit: cover;
                border-radius: 9999px;
                border: 3px solid #ddd;
            }
            .overview-section {
                border: 1px solid #ddd;
                padding: 24px;
                border-radius: 12px;
                max-width: 380px; 
            }
            .company-info p {
                margin-bottom: 8px;
            }
            .btn-apply {
                background-color: #035772;
                color: #ffffff;
                padding: 10px 16px;
                border-radius: 8px;
                display: inline-block;
                margin-top: 20px;
                text-align: center;
                cursor: pointer;
                transition: background-color 0.3s ease, color 0.3s ease;
            }
            .btn-apply:hover {
                background-color: #A5C8D4;
                color: #ffffff;
            }
        </style>
    </head>
    <body>
        <div class="container mx-auto p-12">
            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>

            <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">
                <ItemTemplate>
                    <div class="flex flex-col lg:flex-row lg:justify-between gap-12">
                        <!-- Left Section: Main Job Details -->
                        <div class="lg:w-2/3 lg:pr-16">
                            <div class="flex items-center mb-8">
                                <a href="JobDetails.aspx?id=<%# Eval("JobId") %>">
                                    <img src="<%# GetImageUrl(Eval("CompanyImage")) %>" alt="Company Image" class="custom-image mr-8" />
                                </a>
                                <div>
                                    <h1 class="text-4xl font-bold"><%# Eval("Title") %></h1>
                                    <h2 class="text-2xl font-semibold text-gray-600"><%# Eval("CompanyName") %></h2>
                                    <p class="text-lg text-gray-500"><%# Eval("Address") %>, <%# Eval("Province") %></p>
                                </div>
                            </div>
                            <p class="text-2xl font-bold text-gray-800 mb-8"><%# Eval("Salary", "{0}/month") %></p>

                            <h3 class="text-2xl font-semibold text-gray-800 mb-4">Job Description</h3>
                            <p class="text-lg text-gray-600 mb-8"><%# Eval("Description") %></p>

                            <h3 class="text-2xl font-semibold text-gray-800 mb-4">Required Knowledge, Skills, and Abilities</h3>
                            <p class="text-lg text-gray-600 mb-8"><%# Eval("Specialization") %></p>

                            <h3 class="text-2xl font-semibold text-gray-800 mb-4">Education + Experience</h3>
                            <ul class="list-disc pl-8 text-lg text-gray-600">
                                <li><%# Eval("Qualification") %></li>
                                <li><%# Eval("Experience") %> years work experience</li>
                            </ul>
                        </div>
                        <!-- Right Section: Job Overview + Company Info -->
                        <div class="lg:w-1/3 overview-section lg:ml-auto">
                            <h3 class="text-2xl font-semibold text-gray-800 border-b pb-4 mb-6">Job Overview</h3>
                            <p class="text-lg"><strong>Posted Date:</strong> <%# Eval("CreateDate", "{0:dd MMM yyyy}") %></p>
                            <p class="text-lg"><strong>Location:</strong> <%# Eval("Province") %></p>
                            <p class="text-lg"><strong>Vacancy:</strong> <%# Eval("NoOfPost") %></p>
                            <p class="text-lg"><strong>Job Nature:</strong> <%# Eval("JobType") %></p>
                            <p class="text-lg"><strong>Salary:</strong> <%# Eval("Salary", "{0}/month") %></p>
                            <p class="text-lg"><strong>Application Close Date:</strong> <%# Eval("LastDateToApply", "{0:dd MMM yyyy}") %></p>
                            <asp:LinkButton ID="btnApply" runat="server" CssClass="btn-apply" CommandName="ApplyJob" Text="Apply"></asp:LinkButton>

                            <div class="company-info mt-10">
                                <h3 class="text-2xl font-semibold text-gray-800 mb-4">Company Information</h3>
                                <p class="text-lg"><%# Eval("CompanyName") %></p>
                                <p class="text-lg"><%# Eval("Address") %>, <%# Eval("Province") %></p>
                                <p class="text-lg">Website: <a href='<%# Eval("Website") %>' class="text-blue-500 hover:underline"><%# Eval("Website") %></a></p>
                                <p class="text-lg">Email: <a href='mailto:<%# Eval("Email") %>' class="text-blue-500 hover:underline"><%# Eval("Email") %></a></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </body>
</asp:Content>
