<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMaster.Master" AutoEventWireup="true" CodeBehind="NewJob.aspx.cs" Inherits="PrimeCode_XBCAD7319.Company.NewJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mx-auto p-4 pb-32">
        <div class="d-flex justify-content-between mb-3">
            <div class="flex-grow-1 d-flex justify-content-center">
                <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="text-center text-sm font-semibold p-2 rounded-md"></asp:Label>
            </div>
            <div class="d-flex justify-content-end">
                <asp:HyperLink ID="linkback" runat="server" NavigateUrl="~/Admin/JobList.aspx" CssClass="btn-gray" Visible="false">
                    Back
                </asp:HyperLink>
            </div>
        </div>
        
        <h3 class="text-4xl font-bold text-center mb-6"><%Response.Write(Session["title"]); %></h3>
        
        <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
            
            <div>
                <label for="txtJobTitle" class="font-semibold">Job Title</label>
                <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="EX. Backend Developer, Web Developer" required></asp:TextBox>
            </div>
            <div>
                <label for="txtNoPost" class="font-semibold">Number Of Positions Available</label>
                <asp:TextBox ID="txtNoPost" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter the Number of Positions" TextMode="Number" required></asp:TextBox>
            </div>
            <div class="md:col-span-2">
                <label for="txtDescription" class="font-semibold">Description</label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter Job Description" TextMode="MultiLine" required></asp:TextBox>
            </div>
            <div>
                <label for="txtQualification" class="font-semibold">Qualification/Education Required</label>
                <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Ex. Bachelor of Computer Science, etc." required></asp:TextBox>
            </div>
            <div>
                <label for="txtExperience" class="font-semibold">Experience Required</label>
                <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Ex. 2 Years, 1.5 Years" required></asp:TextBox>
            </div>
            <div>
                <label for="txtSpecialization" class="font-semibold">Specialization Required</label>
                <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter Specialization" required></asp:TextBox>
            </div>
            <div>
                <label for="txtLastDate" class="font-semibold">Last Date To Apply</label>
                <asp:TextBox ID="txtLastDate" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter the last date for application" TextMode="Date" required></asp:TextBox>
            </div>
            <div>
                <label for="txtSalary" class="font-semibold">Salary</label>
                <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Ex. 2 500/Month" required></asp:TextBox>
            </div>
            <div>
                <label for="ddlJobType" class="font-semibold">Job Type</label>
                <asp:DropDownList ID="ddlJobType" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full">
                    <asp:ListItem Value="0">Select Job Type</asp:ListItem>
                    <asp:ListItem>Full Time</asp:ListItem>
                    <asp:ListItem>Part Time</asp:ListItem>
                    <asp:ListItem>Remote</asp:ListItem>
                    <asp:ListItem>Freelance</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Job Type is required" ForeColor="Red" ControlToValidate="ddlJobType" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="txtCompany" class="font-semibold">Company/Organization Name</label>
                <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter Company/Organization Name" required></asp:TextBox>
            </div>
            <div>
                <label for="CompanyLogo" class="font-semibold">Company/Organization Logo</label>
                <asp:FileUpload ID="CompanyLogo" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" ToolTip=".jpg, .jpeg, .png extension only"></asp:FileUpload>
            </div>
            <div>
                <label for="txtWebsite" class="font-semibold">Website</label>
                <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter Website" TextMode="Url"></asp:TextBox>
            </div>
            <div>
                <label for="txtEmail" class="font-semibold">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter Email" TextMode="Email"></asp:TextBox>
            </div>
            <div class="md:col-span-2">
                <label for="txtAddress" class="font-semibold">Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter Address" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div>
                <label for="ddlProvinces" class="font-semibold">Province</label>
                <asp:DropDownList ID="ddlProvinces" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" DataSourceID="SqlDataSource1" DataTextField="ProvinceName" DataValueField="ProvinceName" AppendDataBoundItems="True">
                    <asp:ListItem Value="0">Select Province</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Province is required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" InitialValue="0" ControlToValidate="ddlProvinces"></asp:RequiredFieldValidator>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JobConnectorConnectionString2 %>" ProviderName="<%$ ConnectionStrings:JobConnectorConnectionString2.ProviderName %>" SelectCommand="SELECT [ProvinceName] FROM [Province]"></asp:SqlDataSource>
            </div>
        </div>
    
        <div class="mt-6">
            <asp:Button ID="btnAdd" runat="server" Text="Upload" CssClass="bg-[#035772] text-white rounded w-full p-2 text-base hover:bg-[#A5C8D4]" OnClick="btnAdd_Click" />
        </div>
       
    </div>
</asp:Content>
