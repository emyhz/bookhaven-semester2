# BookHaven – Book Store Management System (C#)

## Overview
BookHaven is a multi-application book store management system developed in C#. The project consists of a WinForms desktop application for administrators and employees and a Razor Pages web application for customers. The system allows customers to browse and purchase books online, while administrators and employees can manage books, users, and orders through the desktop application. The project was developed as part of a software engineering / object-oriented design course.

## Features
### Customer (Web Application - Razor Pages)
- Browse available books
- View book details
- Register and log in
- Add books to cart and place orders
- View order history

### Admin / Employee (Desktop Application - WinForms)
- Add, edit, and remove books
- Manage users
- View and manage orders
- View books and statistics

## Project Structure
This solution consists of multiple projects:
- BookHavenDesktop – WinForms desktop application for admins/employees
- BookHavenWebApp – Razor Pages web application for customers
- LogicLayer – Business logic
- DataAccessLayer – Data access and database logic
- BookHavenUnitTests – Unit tests

## Technologies Used
- C# (.NET)
- WinForms
- ASP.NET Razor Pages
- MSSQL Database


### Requirements
- Visual Studio 2022 (or newer)


## Testing
Unit tests are included in the BookHavenUnitTests project and can be run using the Visual Studio Test Explorer.

## Architecture
The project follows a layered architecture:
- Presentation Layer (WinForms / Razor Pages)
- Logic Layer
- Data Access Layer  

## Notes
- This is a school project created for educational purposes.
- The project demonstrates object-oriented design, layered architecture, and separation of concerns.

## Author
Emily Heinz

## License
Educational use only.

