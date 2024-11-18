<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="relative bg-cover bg-center h-96" style="background-image: url('../public/images/img_grou_55.png');">
        <div class="absolute inset-0 bg-black bg-opacity-60 flex flex-col justify-center items-center text-center">
            <h1 class="text-4xl font-bold text-white">Unlock Your Career Potential</h1>
            <p class="text-xl text-white mt-2">Find Your Dream Job Today</p>
        </div>
    </section>
    <section class="bg-white p-8 flex flex-col md:flex-row gap-8">
        <div class="md:w-1/2 flex justify-center">
            <img alt="About Us Image" src="../public/images/img_image_2.png" class="w-full h-auto object-cover" />
        </div>
        <div class="md:w-1/2">
            <h2 class="text-3xl font-bold text-gray-800">About Us</h2>
            <p class="mt-4 text-lg text-gray-700">
                At JobConnector, you can find professional services and job opportunities to help you achieve your career goals. Our system generates CVs and employee profiles for a small cost, along with guidance and support throughout your job search journey.
            </p>
            <h3 class="text-2xl font-semibold mt-6 text-gray-800">Our Mission</h3>
            <p class="mt-4 text-lg text-gray-700">
                We believe that every individual deserves the chance to find fulfilling employment. That's why we've partnered with WeFeedSA, an organization committed to reducing unemployment and supporting communities. Together, we aim to bridge the gap between talent and opportunity, helping you secure the perfect job.
            </p>
        </div>
    </section>
</asp:Content>
