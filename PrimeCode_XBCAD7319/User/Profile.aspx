<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="flex flex-col lg:flex-row items-start bg-[#035772] p-6 pb-24 rounded-lg shadow-lg min-h-screen">
        <asp:DataList ID="dlProfile" runat="server" Width="100%" OnItemCommand="dlProfile_ItemCommand">
            <ItemTemplate>
                <div class="relative flex flex-col lg:flex-row bg-[#035772] p-10 min-h-screen">
                    <!-- Left Side: Profile Picture and Information -->
                    <div class="flex flex-col items-center bg-[#035772] p-6 rounded-lg shadow-lg w-full lg:w-1/4">
                        <img class="rounded-full mb-4 border-4 border-white" src='<%# Eval("ProfileImage") != DBNull.Value && !string.IsNullOrEmpty(Eval("ProfileImage").ToString()) ? ResolveUrl(Eval("ProfileImage").ToString()) : ResolveUrl("~/public/images/No_image.jpg") %>' alt="Profile Picture" width="150" height="150" />
                        <h2 class="text-3xl font-bold text-white capitalize"><%# Eval("Name") %></h2>
                        <p class="text-xl text-white mt-2">@<%# Eval("Username") %></p>
                        <p class="text-lg text-white capitalize mt-2"><%# Eval("Province") %></p>
                        <asp:FileUpload ID="fuProfileImage" runat="server" CssClass="mb-4 text-white" />
                        <asp:LinkButton ID="btnUploadImage" runat="server" Text="Upload Image" CssClass="bg-[#A5C8D4] text-[#035772] font-semibold px-4 py-2 rounded-md hover:bg-[#86b1c3]" CommandName="UploadImage" CommandArgument='<%# Eval("UserId") %>'></asp:LinkButton>
                    </div>

                    <!-- Right Side: User Details -->
                    <div class="flex flex-col items-center bg-white rounded-lg p-6 shadow-lg w-full lg:w-1/2 lg:ml-10 mt-10 lg:mt-0">
                        <h3 class="text-xl font-medium text-primary mb-4">User Details</h3>
                        <div class="mb-4 w-full">
                            <h6 class="font-bold mb-2 text-black">Full Name</h6>
                            <asp:TextBox ID="txtName" runat="server" CssClass="w-full p-3 border border-black rounded" Text='<%# Eval("Name") %>' Enabled="false"></asp:TextBox>
                        </div>
                        <div class="mb-4 w-full">
                            <h6 class="font-bold mb-2 text-black">Email</h6>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="w-full p-3 border border-black rounded" Text='<%# Eval("Email") %>' Enabled="false"></asp:TextBox>
                        </div>
                        <div class="mb-4 w-full">
                            <h6 class="font-bold mb-2 text-black">Phone</h6>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="w-full p-3 border border-black rounded" Text='<%# Eval("Mobile") %>' Enabled="false"></asp:TextBox>
                        </div>
                        <div class="mb-4 w-full">
                            <h6 class="font-bold mb-2 text-black">Address</h6>
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="w-full p-3 border border-black rounded" Text='<%# Eval("Address") %>' Enabled="false"></asp:TextBox>
                        </div>
                        <div class="mb-4 w-full">
                            <h6 class="font-bold mb-2 text-black">Cover Letter Uploaded</h6>
                            <asp:TextBox ID="txtResume" runat="server" CssClass="w-full p-3 border border-black rounded" Text='<%# Eval("Resume") == DBNull.Value ? "Not Created" : "Created" %>' Enabled="false"></asp:TextBox>
                        </div>
                        <div class="mb-4 w-full">
                            <h6 class="font-bold mb-2 text-black">ID Document Uploaded</h6>
                            <asp:TextBox ID="txtID" runat="server" CssClass="w-full p-3 border border-black rounded" Text='<%# Eval("ID") == DBNull.Value ? "Not Created" : "Created" %>' Enabled="false"></asp:TextBox>
                        </div>
                        <div class="mb-4 w-full">
                            <h6 class="font-bold mb-2 text-black">Matric Certificate Uploaded</h6>
                            <asp:TextBox ID="txtMC" runat="server" CssClass="w-full p-3 border border-black rounded" Text='<%# Eval("Matric") == DBNull.Value ? "Not Created" : "Created" %>' Enabled="false"></asp:TextBox>
                        </div>
                        <div class="mb-4 w-full">
                            <h6 class="font-bold mb-2 text-black">Academic Transcript Uploaded</h6>
                            <asp:TextBox ID="txtAT" runat="server" CssClass="w-full p-3 border border-black rounded" Text='<%# Eval("Transcript") == DBNull.Value ? "Not Created" : "Created" %>' Enabled="false"></asp:TextBox>
                        </div>
                        <div class="mt-6 flex space-x-4">
                            <asp:LinkButton ID="btnCv" runat="server" Text="Resume" CssClass="bg-[#035772] text-white font-semibold px-8 py-4 rounded-md hover:bg-[#A5C8D4]" CommandName="CreateCv" CommandArgument='<%# Eval("UserId") %>'></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>