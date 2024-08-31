<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PartnerList.aspx.cs" Inherits="PrimeCode_XBCAD7319.Admin.PartnerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mx-auto p-4 pb-32">
        <div class="text-center mb-4">
            <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="text-center text-sm font-semibold p-2 rounded-md bg-red-200 text-red-800"></asp:Label>
        </div>
        <h3 class="text-4xl font-bold text-center mb-6" style="color: #035772;">Partner Document List</h3>
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered rounded-lg shadow-sm" 
                  EmptyDataText="No Records to display..." AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting"
                  DataKeyNames="PartnerId">
                    <Columns>
                        <asp:BoundField DataField="Username" HeaderText="Username" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="25%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                        <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="25%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                        <asp:BoundField DataField="Mobile" HeaderText="Phone No." ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="25%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                        <asp:TemplateField HeaderText="Documents">
                            <ItemTemplate>
                                <asp:Literal ID="litDocuments" runat="server" Text='<%# GetDocumentLinks(Eval("Documents").ToString()) %>' />
                            </ItemTemplate>
                            <ItemStyle Width="25%" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
                        </asp:TemplateField>

                        <asp:CommandField CausesValidation="false" HeaderText="Delete" ShowDeleteButton="true"
                                          DeleteImageUrl="~/public/images/bin_icon.png" ButtonType="Image">
                            <ItemStyle Width="20%" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
                            <ControlStyle Width="15px" Height="20px" />
                        </asp:CommandField>
                    </Columns>

                    <HeaderStyle CssClass="bg-[#035772] text-white" />
                    <RowStyle CssClass="border-b border-gray-200 hover:bg-gray-100" />
                    <FooterStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
