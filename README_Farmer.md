
# Cloud Farming Management System

## Overview
The Cloud Farming Management System is an ASP.NET Core MVC application designed to help farmers manage their products and for employees to manage farmer profiles and view all listed products. It features secure user authentication and role-based access control.

## Features
- Role-Based User Management:
  - Farmers can add, view, edit, and delete their own products.
  - Employees can add farmer profiles and view all products.

- Modern User Interface:
  - Dark theme with a clean, responsive design.

- Secure Authentication System:
  - ASP.NET Identity with secure password management.

- Product Search Functionality:
  - Search for products by name or category.

## User Roles
1. **Farmer:** Can add, edit, delete, and view their own products.
2. **Employee:** Can add farmer profiles and view products from all farmers.

## Prerequisites
- Visual Studio 2022 or later.
- .NET 6.0 SDK or later.
- SQL Server (LocalDB or SQL Server).
- Git installed.

## Setup Instructions
1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-username/CloudFarmingManagementSystem.git
   cd CloudFarmingManagementSystem
   ```

2. **Configure Database Connection:**
   - Open `appsettings.json` and update the connection strings with your database details.

3. **Apply Database Migrations:**
   - Run the following commands in the Package Manager Console:
     ```bash
     Update-Database -Context ApplicationDbContext
     Update-Database -Context ApplicationBBContext
     ```

4. **Run the Project:**
   - Open the solution file (`.sln`) in Visual Studio.
   - Build the solution (`Ctrl + Shift + B`).
   - Run the application (`F5`).

## Usage
- Farmers can register, log in, and manage their own products.
- Employees can register, log in, add farmer profiles, and view all products.
- Products can be searched by name or category.

## Technologies Used
- ASP.NET Core MVC (C#)
- Entity Framework Core (Code-First Approach)
- ASP.NET Identity (User Authentication)
- SQL Server (Database)
- HTML, CSS, Bootstrap for UI

## License
This project is licensed under the MIT License.
