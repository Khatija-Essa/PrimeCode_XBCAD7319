<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="PrimeCode_XBCAD7319.Admin.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid mx-auto p-4 pb-32">
       <div class="d-flex justify-content-between mb-3">
    <div class="flex-grow-1 d-flex justify-content-center">
        <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="text-center text-sm font-semibold p-2 rounded-md"></asp:Label>
    </div> 
</div>
        
        <h3 class="text-4xl font-bold text-center mb-6" style="color: #035772;">Payment List</h3>
        <div class="row mb-3 pt-sm-3">
            <div class="col-md-12">
               <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered rounded-lg shadow-sm" 
    EmptyDataText="No Records to display..." AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
    OnPageIndexChanging="GridView1_PageIndexChanging">
    <Columns>
        <asp:BoundField DataField="Payment Id" HeaderText="Payment Id" ItemStyle-HorizontalAlign="Center" 
            ItemStyle-Width="10%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
        <asp:BoundField DataField="Username" HeaderText="Username" ItemStyle-HorizontalAlign="Center" 
            ItemStyle-Width="25%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
        <asp:BoundField DataField="Plan" HeaderText="Plan" ItemStyle-HorizontalAlign="Center" 
            ItemStyle-Width="25%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
        <asp:BoundField DataField="User Type" HeaderText="User Type" ItemStyle-HorizontalAlign="Center" 
            ItemStyle-Width="15%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
        <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-HorizontalAlign="Center" 
            ItemStyle-Width="25%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
        <asp:BoundField DataField="Payment Date" HeaderText="Payment Date" DataFormatString="{0:dd/MM/yyyy}" 
            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
    </Columns>
    <HeaderStyle CssClass="bg-[#035772] text-white" />
    <RowStyle CssClass="border-b border-gray-200 hover:bg-gray-200" />
    <FooterStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
</asp:GridView>


            </div>
        </div>
    </div>
</asp:Content>
