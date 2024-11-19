# Job Connector Website

## Project Overview

The Job Connector platform is an innovative service designed to bridge the gap between job seekers and employers, providing a seamless experience for both. Users can register, log in, build professional profiles, search for jobs, and apply to them. Meanwhile, companies and partners can manage their profiles, post job openings, and access applicant CVs. This platform, developed with ASP.NET Web Forms (no MVC), integrates an Azure SQL Database for efficient data management.

---

## Key Features

### Home Page
- Provides details about the company's location, mission, vision, and founders.
- Includes navigation links to key pages like **"Find a Job"**, **"About"**, **"Login"**, **"Register"**, and **"Contact"**.
- Acts as the first touchpoint for users to understand the platform's purpose.
  ![image](https://github.com/user-attachments/assets/da0d0949-8d43-40c6-9b83-f2b514f4e67c)


---


### About Page
- Shares the company's story, mission, and values.
- Builds trust by showcasing the journey, growth, and purpose of the organization.
- Allows users to align with the company’s goals and vision.
  ![image](https://github.com/user-attachments/assets/ad8beec1-f70a-48c4-898e-505f67172cf3)


---

### Contact Page
- Users can submit inquiries using a form requiring their **name**, **email**, and **message**.
- Messages are sent to admins, who can respond via email.
- Helps resolve user issues and build strong communication.
  ![image](https://github.com/user-attachments/assets/4fdc894c-d7cf-42b5-9bae-30ec62244dd5)


---

### Register Page
- Enables registration for users, companies, and partners.
- Users must provide:
  - **Username, password, full name, email, phone number, address, province, and user type (User, Company, or Partner).**
- Terms and conditions must be accepted before registration.
![image](https://github.com/user-attachments/assets/8b1c8dd2-531c-4535-94f6-c56a9a8cf43d)

---

### Login Page
- Allows users, admins, companies, and partners to log in with their username and password.
- A "forgot password" option is available to reset credentials.
![image](https://github.com/user-attachments/assets/af1cea0e-5b1d-4242-aa4d-8306f1431a20)

---

### Terms and Conditions
- Users must accept terms during registration.
- Provides consent for sharing user details with employers.
- Complies with privacy laws like the POPI Act.
![image](https://github.com/user-attachments/assets/5418e68f-d093-49b7-8a35-14220a00b679)
---

### Change Password
- Logged-in users can update their passwords by providing:
  - **Current password, new password, and confirmation of the new password.**
- Ensures user data security.
![image](https://github.com/user-attachments/assets/7af06b43-0790-41a4-8d52-68b054a7d3e1)

---

### User Profile
- Users can view and update their personal information, such as:
  - **Avatar, personal details, and uploaded documents.**
- Features tools to build a professional resume directly on the platform.

---

### Build Resume
- Users can create a resume by entering:
  - **Personal details, education, work experience, and additional documents.**
- Resumes are saved for use in job applications.

---
### Find a Job Page
- Displays job listings with key details such as:
  - **Logo, job title, company, location, salary, job type, and posting date.**
- Users can filter job results by province, city, job type, and posting date.
- Advanced filters (available for purchase) provide more precise results.
- Logged-in users can click a job to view its full details and apply directly.
  

---

### User Filter Purchase
- Users can purchase advanced filters for job searches.
- Payment is processed via Stripe, redirecting users to success or failure pages based on transaction outcomes.

---

### Job Details
- Provides comprehensive job information, including:
  - **Requirements, job description, and application deadline.**
- Users can apply for jobs directly through this page (limited to one application per job).

---

### Company’s Profile
- Companies can manage their profile, including:
  - **Updating details, uploading an avatar, and storing key information.**

---

### Company’s Home
- Displays information about costs for accessing user CVs.
- Includes navigation to:
  - **Profile, Job List, and Applied List.**

---

### Company Job List
- Companies can view, edit, or delete their posted jobs.
- Jobs can be updated for accuracy or removed if positions are filled.

---

### Company Applied List
- Lists applicants who have applied for posted jobs.
- Displays limited applicant details like:
  - **Username, work experience, and job title.**
- Companies can filter through applications to make decisions.

---

### Company Purchase CVs
- Companies can buy access to a set number of CVs.
- Payments are processed via Stripe, and purchased CVs are available immediately after payment.

---

### Company Payment
- Handles payment processing for CV access or other services.
- Redirects companies to Stripe for secure transactions.

---

### Upload a Job
- Companies can create job postings by providing:
  - **Job title, description, qualifications, salary, application deadline, and location.**
- Listings are stored in the platform’s database.

---

### Partner’s Profile
- Allows partners to upload and manage documents, including bulk uploads.
- Partners can edit personal and institutional details as needed.

---

### Dashboard (Admin)
- Provides an overview of platform activity:
  - **Total users, jobs posted, and applications received.**
- Admins can monitor platform health and performance.

---

### Job List Page (Admin)
- Admins can view and manage all job listings.
- Features options to **edit** or **delete** job postings.

---

### View Resume Page (Admin)
- Admins can manage applicant resumes by:
  - **Viewing, downloading, or deleting resumes.**
- Displays comprehensive applicant information for review.

---

### Contact List Page (Admin)
- Admins can respond to user inquiries directly via email.
- Provides tools to manage and delete resolved messages.

---

### Payment (Admin)
- Tracks payments made by users and companies for filters or CV access.
- Includes details like:
  - **Username, plan chosen, payment date, and user type.**

---

### Partner’s List (Admin)
- Admins can view and download documents uploaded by partners.
- Displays partner details like:
  - **Name, email, phone number, and uploaded files.**

---

### Payment Notification (Admin)
- Displays real-time payment updates.
- Notifications can be cleared after review (but remain stored in the database).

---

## Tech Stack

- **Frontend**: ASP.NET Web Forms, HTML, CSS, JavaScript, and Bootstrap.
- **Backend**: ASP.NET with C#, ADO.NET for database interaction.
- **Database**: Azure SQL Database for storing platform data.
- **Payment**: Stripe integration for secure payment handling.

---

## Deployment and Setup

### Azure SQL Database
1. Set up an Azure SQL Database with the required schema.
2. Update the connection string in `web.config` with your database credentials.

### Application Setup
1. Open the project in Visual Studio (ensure the correct .NET Framework version is installed).
2. Build the project using **Build > Build Solution**.

### Running the Application
1. Launch the application by pressing **Ctrl + F5** in Visual Studio.
2. Configure Stripe API keys for payment features in the designated section.

---

## Future Improvements
- Implement additional filtering options for job seekers without requiring purchases.
- Introduce a mobile application for better accessibility.
- Enhance reporting and analytics for employers and admins.

---

## Contact
For any issues or suggestions, please reach out via the **Contact Page** on the platform.


