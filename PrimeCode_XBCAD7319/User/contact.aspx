<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <main class="bg-[#035772] min-h-screen flex flex-col items-center justify-center py-10 pb-40">
      <section class="bg-[#035772] p-5">
         <div class="bg-white p-8 shadow-lg rounded-lg max-w-8xl mx-auto"> 
            <h2 class="text-4xl font-bold mb-4">Contact</h2>
            <p class="mb-8 text-3xl">
               We are dedicated to connecting job seekers with their dream careers and helping companies find the perfect candidates. Our platform offers a seamless experience, allowing users to easily apply for jobs, filter searches to match their specific preferences, and stay updated on the latest opportunities. Employers can upload their job vacancies and reach a vast pool of potential employees by subscribing to our premium services. For any inquiries or assistance, please don’t hesitate to contact us. We’re here to support you every step of the way in your employment journey.
            </p>
            <div class="col-12 p-10">
               <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
            </div>
            <h3 class="text-2xl font-semibold mb-4">Let’s Chat</h3>
            <div class="mb-4 flex space-x-3">
               <p class="flex-1"><span class="font-bold">Phone:</span> +27 56 654 6784</p>
               <p class="flex-1"><span class="font-bold">Email:</span> jobconnector@gmail.com</p>
            </div>
            <form class="space-y-6">
               <div class="flex space-x-4 mb-4">
                  <input type="text" placeholder="Full Name" runat="server" id="txtName" class="w-1/2 p-3 border border-zinc-300 rounded" required />
                  <input type="email" placeholder="Email" runat="server" id="txtEmail" class="w-1/2 p-3 border border-zinc-300 rounded" required  />
               </div>
               <textarea placeholder="Message" runat="server" id="txtMessage" class="w-full p-3 border border-zinc-300 rounded h-32 mb-4" required ></textarea>
               <asp:Button ID="BtSend" runat="server" Text="Send" CssClass="bg-[#035772] text-white px-4 py-2 rounded hover:bg-[#A5C8D4]" OnClick="BtSend_Click" />
            </form>
         </div>
      </section>
   </main>
</asp:Content>
