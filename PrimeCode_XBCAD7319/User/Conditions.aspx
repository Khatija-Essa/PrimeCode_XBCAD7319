<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Conditions.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.Conditions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="https://cdn.tailwindcss.com?plugins=forms,typography"></script>
    <script type="text/javascript">
        function validateAgreement() {
            var checkBox = document.getElementById('<%= CheckBox1.ClientID %>');
            if (checkBox.checked) {
                return true;
            } else {
                alert("You must accept the terms and conditions before proceeding.");
                return false;
            }
        }
    </script>
</head>
<body>
    <div class="max-w-7xl mx-auto p-6 bg-white text-gray-900 rounded-lg shadow-md pb-40"> 
        <h1 class="text-2xl font-bold mb-4">Terms and Conditions</h1>

        <h2 class="text-lg font-semibold mt-4">Information Sharing:</h2>
        <p class="mb-4">
            By creating an account and submitting your personal information, including your resume, to our platform, you consent to the sharing of this data with third parties, such as potential employers and partners. This may include, but is not limited to, your name, contact details, work experience, education, and any additional information you provide in your profile or CV.
        </p>
        
        <h2 class="text-lg font-semibold mt-4">Data Privacy:</h2>
        <p class="mb-4">
            We prioritize the protection of your personal information and are committed to using your data responsibly. Third parties who access your information through our platform are required to use it solely for the purposes intended, such as recruitment, networking, or other professional engagements. We take measures to ensure that your data is handled with care and in compliance with applicable privacy laws.
        </p>
        
        <h2 class="text-lg font-semibold mt-4">User Responsibilities:</h2>
        <p class="mb-4">
            As a user of our platform, you are responsible for ensuring that the information you provide is accurate, truthful, and current. Any misrepresentation or provision of false information may lead to the suspension or termination of your account. You are encouraged to regularly update your profile to reflect any changes in your professional or personal information.
        </p>
        
        <h2 class="text-lg font-semibold mt-4">Employer and Partner Use:</h2>
        <p class="mb-4">
            Employers and partners who access your information through our platform are also bound by these terms and are required to handle your data with confidentiality and respect. They are authorized to use your information solely for purposes related to recruitment, collaboration, or other professional interactions.
        </p>
        
        <h2 class="text-lg font-semibold mt-4">Consent:</h2>
        <p class="mb-4">
            By registering on our platform and submitting your personal information, you explicitly consent to the collection, processing, and sharing of your data with third parties as described above. You understand and accept that your information may be viewed by employers, recruiters, or other professional contacts who use our platform for legitimate purposes.
        </p>
        
        <h2 class="text-lg font-semibold mt-4">Changes to Terms:</h2>
        <p class="mb-4">
            We reserve the right to update these terms and conditions from time to time. Any changes will be communicated to you via email or through notices on our platform. Your continued use of our services following any updates constitutes your acceptance of the revised terms.
        </p>

        <div class="flex flex-col items-center mb-6">
            <div class="flex items-center">
                <asp:CheckBox ID="CheckBox1" runat="server" class="mr-2" />
                <label for="CheckBox1" class="text-gray-600">I accept the terms & conditions</label>
            </div>
            <asp:LinkButton ID="btnAgree" runat="server"  Text="Agree" CssClass="bg-[#035772] text-white rounded w-full p-5 text-lg mt-4 text-center hover:bg-[#A5C8D4]" OnClientClick="return validateAgreement();" OnClick ="btnAgree_Click"></asp:LinkButton>
        </div>
    </div>
</body>
</html>
</asp:Content>
