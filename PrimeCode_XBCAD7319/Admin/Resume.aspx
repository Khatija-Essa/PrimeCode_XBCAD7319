<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Resume.aspx.cs" Inherits="PrimeCode_XBCAD7319.Admin.Resume" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mx-auto p-4 pb-32">
        <div class="col-12 p-2 text-center">
            <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="text-center text-sm font-semibold p-2 rounded-md"></asp:Label>
        </div>
        <h3 class="text-4xl font-bold text-center mb-6" style="color: #035772;">Resume List</h3>

        <!-- Adding a scrollable container -->
        <div class="table-responsive">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered rounded-lg shadow-sm" 
                EmptyDataText="No Records to display..." AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="AppliedJobId"
                OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                
                <Columns>
                    <asp:BoundField DataField="Sr.No" HeaderText="Sr No." 
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                    <asp:BoundField DataField="CompanyName" HeaderText="Company Name" 
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                    <asp:BoundField DataField="Title" HeaderText="Job Title" 
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                    <asp:BoundField DataField="Name" HeaderText="User Name" 
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                    <asp:BoundField DataField="Email" HeaderText="User Email" 
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                    <asp:BoundField DataField="Mobile" HeaderText="User Mobile No." 
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="gray" />

                    <asp:TemplateField HeaderText="Cover Letter">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlResume" runat="server" 
                                NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.Resume", "../{0}") %>'>Download</asp:HyperLink>
                            <asp:HiddenField ID="hdnJobId" runat="server" Value='<%# Eval("JobId") %>' Visible="false"/>
                        </ItemTemplate>
                        <ItemStyle Width="8%" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Matric">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlMatric" runat="server" 
                                NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.Matric", "../{0}") %>'>Download</asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle Width="8%" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlID" runat="server" 
                                NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.ID", "../{0}") %>'>Download</asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle Width="8%" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Transcript">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlTranscript" runat="server" 
                                NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.Transcript", "../{0}") %>'>Download</asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle Width="8%" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CV">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlCV" runat="server" 
                                NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.CV", "../{0}") %>'>Download</asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle Width="8%" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
                    </asp:TemplateField>
                </Columns>

                <HeaderStyle CssClass="bg-[#035772] text-white" />
                <RowStyle CssClass="border-b border-gray-200 hover:bg-gray-200" />
                <FooterStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="gray" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
