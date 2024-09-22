using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Stripe;
using Stripe.Checkout;

namespace PrimeCode_XBCAD7319.User
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var plan = ddlPlan.SelectedValue;

            // Create the checkout session
            var sessionUrl = CreateCheckoutSession(username, plan);

            if (!string.IsNullOrEmpty(sessionUrl))
            {
                // Update payment status to 'yes' before redirecting to Stripe checkout page
                UpdatePaymentStatusForImmediatePayment(username, plan);

                // Redirect the user to the Stripe Checkout page
                Response.Redirect(sessionUrl);
            }
            else
            {
                lblMessage.Text = "Error creating checkout session.";
            }
        }

        private string CreateCheckoutSession(string username, string plan)
        {
            StripeConfiguration.ApiKey = "sk_test_26PHem9AhJZvU623DfE1x4sd"; // Your Stripe API key

            var amount = CalculateAmount(plan);

            if (amount == 0)
            {
                return null; // Invalid plan
            }

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = amount,
                            Currency = "zar",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = $"Payment for {plan}",
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = "http://localhost:50630/User/PaymentSuccess.aspx?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "http://localhost:50630/User/PaymentCancel.aspx",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            // Save session details to the database
            SavePaymentSession(username, plan, session.Id, "no");

            return session.Url;
        }

        private long CalculateAmount(string paymentPlan)
        {
            switch (paymentPlan)
            {
                case "filter_search": return 5500;  // R55.00
                case "5_cvs": return 5000;          // R50.00
                case "10_cvs": return 10000;        // R100.00
                case "additional_cvs": return 2000; // R20.00 per additional CV
                default: return 0;                  // Invalid plan
            }
        }

        // Saves the payment session with default PaymentMade status as "no"
        private void SavePaymentSession(string username, string plan, string sessionId, string paymentMade)
        {
            string connectionString = "Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=JobConnector;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO PaymentSessions (Username, [Plan], SessionId, CreatedAt, PaymentMade) 
                                 VALUES (@Username, @Plan, @SessionId, @CreatedAt, @PaymentMade)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Plan", plan);
                    cmd.Parameters.AddWithValue("@SessionId", sessionId);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@PaymentMade", paymentMade);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Immediately updates PaymentMade status to 'yes' upon button submit
        private void UpdatePaymentStatusForImmediatePayment(string username, string plan)
        {
            string connectionString = "Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=JobConnector;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE PaymentSessions 
                                 SET PaymentMade = 'yes' 
                                 WHERE Username = @Username AND [Plan] = @Plan";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Plan", plan);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


/*Code Attribute for Payment
 * Source: https://docs.stripe.com/payments/accept-a-payment?platform=web&ui=embedded-form
 * Creater : stripe Docs
 */