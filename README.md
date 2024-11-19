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
![image](https://github.com/user-attachments/assets/c30d4a9c-e3a0-435c-8415-1c80a8319e0f)

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
  ![image](https://github.com/user-attachments/assets/623b6072-afd3-4648-ab8a-523f383dc2a3)


---

### User Filter Purchase
- Users can purchase advanced filters for job searches.
- Payment is processed via Stripe, redirecting users to success or failure pages based on transaction outcomes.
![image](https://github.com/user-attachments/assets/5db0cda0-d1ea-4843-8840-1c3349373308)

---

### Job Details
- Provides comprehensive job information, including:
  - **Requirements, job description, and application deadline.**
- Users can apply for jobs directly through this page (limited to one application per job).
![image](https://github.com/user-attachments/assets/441546f6-2854-471d-8c9a-ed9190c8a329)

---

### Company’s Home
- Displays information about costs for accessing user CVs.
- Includes navigation to:
  - **Profile, Job List, and Applied List.**
![image](https://github.com/user-attachments/assets/62544d02-24b0-4770-a70f-e99d2ef831dc)

---
### Company’s Profile
- Companies can manage their profile, including:
  - **Updating details, uploading an avatar, and storing key information.**
![image](https://github.com/user-attachments/assets/0f6672ff-a4a0-4cb9-a23e-b4c5748b3c39)

---

### Company Job List
- Companies can view, edit, or delete their posted jobs.
- Jobs can be updated for accuracy or removed if positions are filled.
![image](https://github.com/user-attachments/assets/427a5bf4-93c2-4adb-88ed-f47bbe0c1414)

---

### Company Applied List
- Lists applicants who have applied for posted jobs.
- Displays limited applicant details like:
  - **Username, work experience, and job title.**
- Companies can filter through applications to make decisions.
![image](https://github.com/user-attachments/assets/f810b741-4aab-48b9-a0e6-e23b5212a6b6)

---

### Company Purchase CVs
- Companies can buy access to a set number of CVs.
- Payments are processed via Stripe, and purchased CVs are available immediately after payment.
![image](https://github.com/user-attachments/assets/3e61acf2-3695-4fa3-a704-a32d0f925810)

---

### Company Payment
- Handles payment processing for CV access or other services.
- Redirects companies to Stripe for secure transactions.
![image](https://github.com/user-attachments/assets/db5fe693-26cb-45e1-8225-00a733bf3a1b)

---
### Company Payment Thank you page
- Once payment is made users will be redirected to a thank you page 
![image](https://github.com/user-attachments/assets/e0226142-ce87-4d14-8dd2-c983b9468a71)
---
  
  ### Company failed payment page
- If the company occurs in an error with payment they will be redirected to a failed payment page 
![image](https://github.com/user-attachments/assets/feb69322-eb43-43bb-93f3-fd9992220966)
---

### Upload a Job
- Companies can create job postings by providing:
  - **Job title, description, qualifications, salary, application deadline, and location.**
- Listings are stored in the platform’s database.

---

### Partner’s Profile
- Allows partners to upload and manage documents, including bulk uploads.
- Partners can edit personal and institutional details as needed.
![image](https://github.com/user-attachments/assets/3e8f47af-0caf-4058-8946-c7cfc9831f74)

---

### Dashboard (Admin)
- Provides an overview of platform activity:
  - **Total users, jobs posted, and applications received.**
- Admins can monitor platform health and performance.
![image](https://github.com/user-attachments/assets/618242d7-5ce3-4af6-b2a5-cc7a39bd720f)

---

### Job List Page (Admin)
- Admins can view and manage all job listings.
- Features options to **edit** or **delete** job postings.
![image](https://github.com/user-attachments/assets/c6f7e20a-e0a1-4abc-9330-dd82b4f89196)

---

### Resume list Page (Admin)
- Admins can manage applicant resumes by:
  - **Viewing, downloading, or deleting resumes.**
- Displays comprehensive applicant information for review.
![image](https://github.com/user-attachments/assets/11f4c362-1f31-4604-b4c5-585ab9d98463)

---

### Contact List Page (Admin)
- Admins can respond to user inquiries directly via email.
- Provides tools to manage and delete resolved messages.
![image](https://github.com/user-attachments/assets/b0d2e7f1-f416-49f3-b810-765850cd855a)

---

### Payment list (Admin)
- Tracks payments made by users and companies for filters or CV access.
- Includes details like:
  - **Username, plan chosen, payment date, and user type.**
![image](https://github.com/user-attachments/assets/32838eca-b3e4-4a12-b0b2-eb724cbc17b3)


---

### Partner’s List (Admin)
- Admins can view and download documents uploaded by partners.
- Displays partner details like:
  - **Name, email, phone number, and uploaded files.**
![image](https://github.com/user-attachments/assets/cf21b188-155f-4156-9799-68cb0b99a46b)

---

### Payment Notification (Admin)
- Displays real-time payment updates.
- Notifications can be cleared after review (but remain stored in the database).
  ![image](https://github.com/user-attachments/assets/06478efa-59c5-4f17-880e-2d622ccecf2d)
---
### Create Admin page 
- Admins are the only users that will be able to create other admins 
![image](https://github.com/user-attachments/assets/90ee6836-a779-4e54-8a62-d7dcbb5231eb)

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

## Thank you PrimeCode 
---
##Group memebers
- KHATIJA ESSA
- SHEREL 
- THABANI
- KEEGAN
- RAVELLE 
- SAHIL 
---
