<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="PrimeCode_XBCAD7319.Admin.ContactList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mx-auto p-4 pb-32">
        <div class="col-12 p-2 text-center">
            <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="text-center text-sm font-semibold p-2 rounded-md"></asp:Label>
        </div>
        <h3 class="text-4xl font-bold text-center mb-6" style="color: #035772;">Contact List</h3>
        <div class="row mb-3 pt-sm-3">
            <div class="col-md-12">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered rounded-lg shadow-sm" 
                    EmptyDataText="No Records to display..." AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                    OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="ContactId" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="ContactId" HeaderText="Contact ID" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="26%" ItemStyle-Height="40px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="26%" ItemStyle-Height="40px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                        <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="26%" ItemStyle-Height="40px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                        <asp:BoundField DataField="Message" HeaderText="Message" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="26%" ItemStyle-Height="40px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                        <asp:CommandField CausesValidation="false" HeaderText="Delete" ShowDeleteButton="true"
                            DeleteImageUrl="~/public/images/bin_icon.png" ButtonType="Image">
                            <ItemStyle Width="25px" Height="40px" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
                            <ControlStyle Width="25px" Height="25px" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle CssClass="bg-[#035772] text-white" />
                    <RowStyle CssClass="border-b border-gray-200 hover:bg-gray-200" />
                    <FooterStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
