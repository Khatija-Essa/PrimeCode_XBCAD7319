<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="PrimeCode_XBCAD7319.User.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Payment</title>
    <script src="https://js.stripe.com/v3/"></script>
    <style>
        body {
            background-color: #035772;
            margin: 0;
            padding: 0;
        }

        .payment-container {
            background-color: #ffffff; /* White background */
            padding: 48px; /* Equivalent to Tailwind's p-12 */
            border-radius: 8px; /* Large border radius */
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); /* Large shadow */
            text-align: center; /* Center text */
            max-width: 1200px; /* Equivalent to Tailwind's max-w-7xl */
            margin: 20px auto; /* Equivalent to Tailwind's mt-20 and mx-auto */
        }

        .payment-header {
            font-size: 28px; /* Increased font size */
            font-weight: bold;
            margin-bottom: 20px;
        }

        .payment-instructions {
            font-size: 16px; /* Increased font size */
            color: #666;
            margin-bottom: 20px;
        }

        .payment-inputs {
            margin-bottom: 15px;
            text-align: center; /* Center-align text */
        }

        .payment-inputs label {
            display: block;
            margin-bottom: 10px; /* Increased margin */
            font-size: 18px; /* Increased font size */
        }

        .payment-inputs input, .payment-inputs select {
            width: 100%;
            padding: 10px; /* Increased padding */
            font-size: 16px; /* Increased font size */
            border-radius: 4px;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        .payment-button {
            margin-top: 20px;
        }

        .payment-button input {
            width: 100%;
            padding: 12px; /* Increased padding */
            font-size: 18px; /* Increased font size */
            background-color: #035772; /* Button background color */
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .payment-button input:hover {
            background-color: #A5C8D4; /* Hover color */
        }

        .error-message {
            margin-top: 20px;
            color: red;
            font-size: 16px; /* Increased font size */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="payment-container">
        <div class="payment-header">Payment Overview</div>
        <div class="payment-instructions">
            Please ensure that you use the same username as your account username when completing your payment. This will help us accurately link your payment to your account and ensure a smooth experience.
        </div>
        <div class="payment-inputs">
            <label for="txtUsername">UserName:</label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>
        <div class="payment-inputs">
            <label for="ddlPlan">Plan:</label>
            <asp:DropDownList ID="ddlPlan" runat="server">
                <asp:ListItem Value="filter_search">Pay for filter search - R55</asp:ListItem>
                <asp:ListItem Value="5_cvs">Pay for 5 CVs - R50</asp:ListItem>
                <asp:ListItem Value="10_cvs">Pay for 10 CVs - R100</asp:ListItem>
                <asp:ListItem Value="additional_cvs">Additional CVs available at R20 each</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="payment-button">
            <asp:Button ID="btnSubmit" runat="server" Text="Charge" OnClick="btnSubmit_Click" />
        </div>
        <div class="error-message">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
