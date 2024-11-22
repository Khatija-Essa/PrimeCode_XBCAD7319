<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMaster.Master" AutoEventWireup="true" CodeBehind="CompanyJoblist.aspx.cs" Inherits="PrimeCode_XBCAD7319.Company.CompanyJoblist" %>
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

        <h3 class="text-4xl font-bold text-center mb-6" style="color: #035772;">Job List</h3>

        <div class="row mb-3 pt-sm-3">
            <div class="col-md-12">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered rounded-lg shadow-sm"
                    EmptyDataText="No Records to display..." AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                    OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="JobId" OnRowDeleting="GridView1_RowDeleting"
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="Sr.No" HeaderText="Job Id" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="8%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                        <asp:BoundField DataField="Title" HeaderText="Job Title" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="18%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                        <asp:BoundField DataField="NoOfPost" HeaderText="No. Of Post" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="8%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                        <asp:BoundField DataField="Qualification" HeaderText="Qualification" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="12%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                        <asp:BoundField DataField="Experience" HeaderText="Experience" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="10%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                        <asp:BoundField DataField="LastDateToApply" HeaderText="Last Date To Apply" DataFormatString="{0:dd/MM/yyyy}" 
                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="10%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                        <asp:BoundField DataField="CreateDate" HeaderText="Posted Date" DataFormatString="{0:dd/MM/yyyy}" 
                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />
                       <asp:CommandField CausesValidation="false" HeaderText="Delete" ShowDeleteButton="true"
    DeleteImageUrl="~/public/images/bin_icon.png" ButtonType="Image">
    <ItemStyle Width="10px" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
    <ControlStyle Width="20px" Height="20px" />
</asp:CommandField>
                        
                                                <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="EditJob" CommandArgument='<%# Eval("JobId") %>'>
                                    <asp:Image ID="Img" runat="server" ImageUrl="~/public/images/edit_icon.jpeg" Height="20px" Width="20px" />
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="10px" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
                        </asp:TemplateField>
                    </Columns>

                      <HeaderStyle CssClass="bg-[#035772] text-white" />
  <RowStyle CssClass="border-b border-gray-200 hover:bg-gray-200" />
  <FooterStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
