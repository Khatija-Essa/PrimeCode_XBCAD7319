<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Resume.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.Resume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<body>
    <div class="container mx-auto p-6 bg-white rounded-lg shadow-md" style="padding-bottom: 500px;">
        <div class="col-12 p-8">
            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
        </div>
        <h2 class="text-2xl font-bold text-center mb-6">Build Resume</h2>

        <h3 class="text-lg font-semibold">Personal Information</h3>
        <div class="grid grid-cols-2 gap-4 mb-6">
            <div class="mb-4">
                <label class="block text-black mb-1" for="txtFullName">Full Name</label>
                <asp:TextBox ID="txtFullName" runat="server" class="w-full p-2 border rounded" placeholder="Enter your full name"></asp:TextBox>
            </div>
            <div class="mb-4">
                <label class="block text-black mb-1" for="txtUsername">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" class="w-full p-2 border rounded" placeholder="Enter your username"></asp:TextBox>
            </div>
            <div class="mb-4">
                <label class="block text-black mb-1" for="txtAddress">Address</label>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class="w-full p-2 border rounded" placeholder="Enter your address"></asp:TextBox>
            </div>
            <div class="mb-4">
                <label class="block text-black mb-1" for="txtMobile">Mobile Number</label>
                <asp:TextBox ID="txtMobile" runat="server" class="w-full p-2 border rounded" placeholder="Enter your mobile number"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Phone number must have 10 digits" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[0-9]{10}$" ControlToValidate="txtMobile"></asp:RegularExpressionValidator>
            </div>
            <div class="mb-8">
                <label class="block text-zinc-700 text-lg">Province</label>
                <asp:DropDownList ID="ddlProvinces" runat="server" DataSourceID="SqlDataSource1" CssClass="border border-zinc-300 rounded w-full p-3 text-lg"
                    AppendDataBoundItems="True" DataTextField="ProvinceName" DataValueField="ProvinceName">
                    <asp:ListItem Value="0">Select Province</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Province is required"
                    ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" 
                    ControlToValidate="ddlProvinces"></asp:RequiredFieldValidator>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JobConnectorConnectionString2 %>" 
                    ProviderName="<%$ ConnectionStrings:JobConnectorConnectionString2.ProviderName %>" SelectCommand="SELECT [ProvinceName] FROM [Province]"></asp:SqlDataSource>
            </div>
            <div class="mb-4">
                <label class="block text-black mb-1" for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" class="w-full p-2 border rounded" placeholder="Enter your email"></asp:TextBox>
            </div>
        </div>

        <h3 class="text-lg font-semibold">Education Information</h3>
        <div class="grid grid-cols-2 gap-4 mb-6">
            <div class="mb-4">
                <label class="block text-black mb-1" for="txtHs">High School</label>
                <asp:TextBox ID="txtHs" runat="server" TextMode="MultiLine" class="w-full p-2 border rounded" placeholder="Enter your high school"></asp:TextBox>
            </div>
            <div class="mb-4">
                <label class="block text-black mb-1" for="txtUniversity">University</label>
                <asp:TextBox ID="txtUniversity" runat="server" class="w-full p-2 border rounded" placeholder="Enter your university"></asp:TextBox>
            </div>
            <div class="mb-4">
                <label class="block text-black mb-1" for="txtWE">Work Experience</label>
                <asp:TextBox ID="txtWE" runat="server" TextMode="MultiLine" class="w-full p-2 border rounded" placeholder="Enter your work experience"></asp:TextBox>
            </div>
            <div class="mb-4">
                <label class="block text-black mb-1" for="Doc">Upload Cover Letter</label>
                <asp:FileUpload ID="Doc" runat="server" class="w-full p-2 border rounded" ToolTip=".doc, .docx, .pdf"></asp:FileUpload>
            </div> 
            <div class="mb-4">
                <label class="block text-black mb-1" for="Doc1">Upload Matric Certificate</label>
                <asp:FileUpload ID="Doc1" runat="server" class="w-full p-2 border rounded" ToolTip=".doc, .docx, .pdf"></asp:FileUpload>
            </div>
            <div class="mb-4">
                <label class="block text-black mb-1" for="Doc2">Upload ID Document</label>
                <asp:FileUpload ID="Doc2" runat="server" class="w-full p-2 border rounded" ToolTip=".doc, .docx, .pdf"></asp:FileUpload>
            </div>
            <div class="mb-4">
                <label class="block text-black mb-1" for="Doc3">Upload Academic Transcript</label>
                <asp:FileUpload ID="Doc3" runat="server" class="w-full p-2 border rounded" ToolTip=".doc, .docx, .pdf"></asp:FileUpload>
            </div>
        </div>
        <div class="mt-8 text-center">
            <asp:Button ID="btnupload" runat="server" Text="Update" CssClass="bg-[#035772] text-white rounded w-full p-5 text-lg hover:bg-[#A5C8D4]" OnClick="btnUpload_Click" />
        </div>
    </div>
</body>
</asp:Content>
