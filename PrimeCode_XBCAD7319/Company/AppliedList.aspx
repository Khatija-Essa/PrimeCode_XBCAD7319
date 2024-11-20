<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMaster.Master" AutoEventWireup="true" CodeBehind="AppliedList.aspx.cs" Inherits="PrimeCode_XBCAD7319.Company.AppliedList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .custom-width {
            width: 100%;
            max-width: 600px;
        }
        .btn-custom {
            background-color: #035772;
            color: white;
            font-weight: 600;
            padding: 10px 20px;
            border-radius: 8px;
        }
        .btn-custom:hover {
            background-color: #A5C8D4;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mx-auto p-4 pb-32">
  
        <div class="col-12 p-2 text-center">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control custom-width" placeholder="Search by job title, company name, user name, or work experience..." />
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-custom" OnClick="btnSearch_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn-custom ml-2" OnClick="btnClear_Click" />
        </div>
        <div class="col-12 p-2 text-center">
            <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="text-center text-sm font-semibold p-2 rounded-md"></asp:Label>
        </div>
        <h3 class="text-4xl font-bold text-center mb-6" style="color: #035772;">Applications List</h3>
        <div class="table-responsive">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered rounded-lg shadow-sm" 
                EmptyDataText="No applications to display..." AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="AppliedJobId">
                <Columns>
                    <asp:BoundField DataField="Sr.No" HeaderText="Sr No." 
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                    <asp:BoundField DataField="CompanyName" HeaderText="Company Name" 
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="28%" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                    <asp:BoundField DataField="Title" HeaderText="Job Title" 
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="28%" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                    <asp:BoundField DataField="Name" HeaderText="Applicant Name" 
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                    <asp:BoundField DataField="WorkExperience" HeaderText="Work Experience" 
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="32%" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                </Columns>
                <HeaderStyle CssClass="bg-[#035772] text-white" />
                <RowStyle CssClass="border-b border-gray-200 hover:bg-gray-100" />
                <FooterStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>