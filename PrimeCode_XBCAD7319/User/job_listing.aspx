<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="job_listing.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.job_listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .styled input[type="checkbox"] {
            margin-right: 10px;
        }
        .filter-button {
            display: block;
            text-align: center;
            padding: 12px 0;
            font-size: 1.125rem;
            margin-bottom: 10px;
            font-weight: bold;
        }
        .w-3_4 {
            width: 75%;
        }
        .job-listing-container {
            display: flex;
            justify-content: flex-start;
            flex-grow: 1;
            padding-right: 20px;
        }
        .job-items {
            display: flex;
            align-items: center;
            justify-content: space-between;
            border-bottom: 1px solid #eaeaea;
            padding-bottom: 20px;
            margin-bottom: 20px;
            width: 120%; 
            gap: 20px; 
        }
        .comany-img img {
            width: 120px; 
            height: 120px; 
            object-fit: cover;
            border-radius: 100%;
            margin-right: 25px;
        }
        .job-tittle {
            flex-grow: 2;
            padding-right: 20px; 
        }
        .job-tittle h5 {
            font-size: 1.5rem; 
            margin-bottom: 10px;
            color: #333;
        }
        .job-tittle ul {
            list-style: none;
            padding: 0;
            margin: 0;
            display: flex;
            gap: 20px;
            color: #555;
            flex-wrap: wrap; 
        }
        .job-tittle ul li {
            display: flex;
            align-items: center;
        }
        .job-tittle ul li i {
            margin-right: 5px;
        }
        .items-link {
            text-align: right;
            white-space: nowrap;
            flex-shrink: 0; 
        }
        .items-link a {
            color: #555; 
            font-size: 1rem; 
            text-decoration: none; 
            margin-bottom: 5px; 
        }
        .items-link span {
            color: #666;
            font-size: 1rem; 
        }
        .count-job {
            font-weight: bold;
            font-size: 1.25rem;
            margin-bottom: 20px;
            text-align: left; 
        }
    </style>
    <div class="flex flex-col lg:flex-row">
        <div class="p-6 bg-background text-foreground lg:w-1/4">
            <div class="mb-6">
                <h2 class="text-xl font-semibold">Filter Search</h2>

                <div class="mb-8">
                    <label class="block text-black text-lg font-semibold mb-2" for="ddlProvinces">Province</label>
                    <asp:DropDownList ID="ddlProvinces" runat="server" CssClass="border border-black rounded w-3_4 p-2 text-lg"
                        AppendDataBoundItems="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Province is required"
                        ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"
                        ControlToValidate="ddlProvinces"></asp:RequiredFieldValidator>
                </div>

                <h3 class="text-black text-lg font-semibold mb-2">Job Type</h3>
                <div class="flex flex-col mb-8">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="false"
                        RepeatDirection="Vertical" RepeatLayout="Flow" CssClass="styled space-y-2"
                        TextAlign="Right">
                        <asp:ListItem>Full Time</asp:ListItem>
                        <asp:ListItem>Part Time</asp:ListItem>
                        <asp:ListItem>Remote</asp:ListItem>
                        <asp:ListItem>Freelance</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
                
                <h3 class="text-black text-lg font-semibold mb-2">Posted Within</h3>
                <div class="flex flex-col mb-8">
                    <asp:CheckBoxList ID="CheckBoxList2" runat="server" AutoPostBack="false"
                        RepeatDirection="Vertical" RepeatLayout="Flow" CssClass="styled space-y-2"
                        TextAlign="Right">
                        <asp:ListItem Value="0" Selected="True">Any</asp:ListItem>
                        <asp:ListItem Value="1">Today</asp:ListItem>
                        <asp:ListItem Value="2">Last 2 days</asp:ListItem>
                        <asp:ListItem Value="3">Last 3 days</asp:ListItem>
                        <asp:ListItem Value="4">Last 5 days</asp:ListItem>
                        <asp:ListItem Value="5">Last 10 days</asp:ListItem>
                    </asp:CheckBoxList>
                </div>

                <asp:LinkButton ID="lbFilter" runat="server" CssClass="bg-[#035772] text-white filter-button w-3_4 hover:bg-[#A5C8D4]"
                    OnClick="lbFilter_Click">Filter</asp:LinkButton>

                <asp:LinkButton ID="lbRest" runat="server" CssClass="bg-[#035772] text-white filter-button w-3_4 hover:bg-[#A5C8D4]"
                    OnClick="lbRest_Click">Reset</asp:LinkButton>
            </div>
        </div>
        <div class="job-listing-container lg:w-3/4 p-6">
            <section class="featured-job-area">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="count-job mb-35">
                                <asp:Label ID="lbljobCount" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <asp:DataList ID="DataList1" runat="server">
                        <ItemTemplate>
                            <div class="single-job-items mb-30">
                                <div class="job-items">
                                    <div class="comany-img">
                                        <a href="JobDetails.aspx?id=<%# Eval("JobId") %>">
                                            <img src="<%# GetImageUrl(Eval("CompanyImage")) %>" alt="Company Image" />
                                        </a>
                                    </div>
                                    <div class="job-tittle">
                                        <a href="JobDetails.aspx?id=<%# Eval("JobId") %>">
                                            <h5><%# Eval("Title") %></h5>
                                        </a>
                                        <ul>
                                            <li><%# Eval("CompanyName") %></li>
                                            <li><i class="fas fa-map-marker-alt"></i><%# Eval("Province") %></li>
                                            <li><%# Eval("Salary") %></li>
                                            <li><%# Eval("JobType") %></li>
                                        </ul>
                                    </div>
                                    <div class="items-link">
                                        <span class="text-secondary">
                                            <i class="fas fa-clock pr-1"></i>
                                            <%# RelativeDate(Convert.ToDateTime(Eval("CreateDate"))) %>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </section>
        </div>
    </div>
</asp:Content>