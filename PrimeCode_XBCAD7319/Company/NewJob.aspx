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
                <asp:RequiredFieldValidator ID="rfvJobTitle" runat="server" ErrorMessage="Job Title is required" ControlToValidate="txtJobTitle" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="txtNoPost" class="font-semibold">Number Of Positions Available</label>
                <asp:TextBox ID="txtNoPost" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter the Number of Positions" TextMode="Number" required></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoPost" runat="server" ErrorMessage="Number of Positions is required" ControlToValidate="txtNoPost" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvNoPost" runat="server" ErrorMessage="Please enter a valid number of positions (1-100)" ControlToValidate="txtNoPost" MinimumValue="1" MaximumValue="100" Type="Integer" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RangeValidator>
            </div>
            <div class="md:col-span-2">
                <label for="txtDescription" class="font-semibold">Description</label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter Job Description" TextMode="MultiLine" Rows="4" required></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="Description is required" ControlToValidate="txtDescription" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="txtQualification" class="font-semibold">Qualification/Education Required</label>
                <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Ex. Bachelor of Computer Science, etc." required></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQualification" runat="server" ErrorMessage="Qualification is required" ControlToValidate="txtQualification" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="txtExperience" class="font-semibold">Experience Required</label>
                <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Ex. 2 Years, 1.5 Years" required></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvExperience" runat="server" ErrorMessage="Experience is required" ControlToValidate="txtExperience" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="txtSpecialization" class="font-semibold">Specialization Required</label>
                <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter Specialization" required></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSpecialization" runat="server" ErrorMessage="Specialization is required" ControlToValidate="txtSpecialization" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="txtLastDate" class="font-semibold">Last Date To Apply</label>
                <asp:TextBox ID="txtLastDate" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter the last date for application" TextMode="Date" required></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastDate" runat="server" ErrorMessage="Last Date to Apply is required" ControlToValidate="txtLastDate" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvLastDate" runat="server" ErrorMessage="Last Date must be in the future" ControlToValidate="txtLastDate" Operator="GreaterThan" Type="Date" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:CompareValidator>
            </div>
            <div>
                <label for="txtSalary" class="font-semibold">Salary</label>
                <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Ex. 2 500/Month" required></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSalary" runat="server" ErrorMessage="Salary is required" ControlToValidate="txtSalary" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="rfvJobType" runat="server" ErrorMessage="Job Type is required" ForeColor="Red" ControlToValidate="ddlJobType" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="txtCompany" class="font-semibold">Company/Organization Name</label>
                <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter Company/Organization Name" required></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ErrorMessage="Company Name is required" ControlToValidate="txtCompany" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="CompanyLogo" class="font-semibold">Company/Organization Logo</label>
                <asp:FileUpload ID="CompanyLogo" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" ToolTip=".jpg, .jpeg, .png extension only" />
            </div>
            <div>
                <label for="txtWebsite" class="font-semibold">Website</label>
                <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter Website" TextMode="Url"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revWebsite" runat="server" ErrorMessage="Please enter a valid URL" ControlToValidate="txtWebsite" ValidationExpression="^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
            </div>
            <div>
                <label for="txtEmail" class="font-semibold">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter Email" TextMode="Email"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please enter a valid email address" ControlToValidate="txtEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
            </div>
            <div class="md:col-span-2">
                <label for="txtAddress" class="font-semibold">Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control border border-gray-300 rounded p-2 w-full" placeholder="Enter Address" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>

             <div class="flex space-x-4">
                             <div class="w-1/2"">
     <label class="block text-zinc-700 text-lg">Province</label>
     <asp:DropDownList ID="ddlProvinces" runat="server" CssClass="border border-zinc-300 rounded w-full p-3 text-lg">
     </asp:DropDownList>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Province is required"
         ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" 
         ControlToValidate="ddlProvinces" ></asp:RequiredFieldValidator>
 </div>
        </div>
        <div>
              <div class="w-1/2">
    <label class="block text-zinc-700 text-lg">Major City</label>
    <asp:DropDownList ID="ddlMajorCities" runat="server" CssClass="border border-zinc-300 rounded w-full p-3 text-lg">
        <asp:ListItem Value="0">Select Major City</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvMajorCity" runat="server" ErrorMessage="Major City is required"
        ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" 
        ControlToValidate="ddlMajorCities"></asp:RequiredFieldValidator>
</div >
        </div>
             </div>
           
 
    
        <div class="mt-6">

            
            <asp:Button ID="btnAdd" runat="server" Text="Upload" CssClass="bg-[#035772] text-white rounded w-full p-2 text-base hover:bg-[#A5C8D4]" OnClick="btnAdd_Click" />
        </div>
    </div>
</asp:Content>