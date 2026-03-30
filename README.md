# Student Management System API

## Overview
This project is a RESTful API built using ASP.NET Core and SQL Server.  
It manages student records and demonstrates backend development skills including CRUD operations, filtering, pagination, and reporting.

## Tech Stack
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server

## Features

### Core Functionality
- Add, update, delete students
- Retrieve all students or a single student by ID

### Advanced Features
- Filtering by name and minimum mark
- Pagination support
- Top-performing student endpoint
- Average mark calculation
- Pass/Fail reporting with percentages

### Architecture
- Controller → Service Layer structure
- DTOs for clean API design
- Asynchronous operations (async/await)
- Entity Framework Core for database access

## API Endpoints

| Method | Endpoint | Description |
|--------|--------|------------|
| GET | /api/students | Get all students (filter + pagination) |
| GET | /api/students/{id} | Get student by ID |
| POST | /api/students | Create a new student |
| PUT | /api/students/{id} | Update student |
| DELETE | /api/students/{id} | Delete student |
| GET | /api/students/top-student | Get top student |
| GET | /api/students/average-mark | Get average mark |
| GET | /api/students/pass-fail-report | Get pass/fail report |

## How to Run

1. Clone the repository
2. Open the project in Visual Studio
3. Update connection string in `appsettings.json`
4. Run the following command:
5. dotnet ef database update
6. Start the application
7. Open Swagger UI to test endpoints

## API Preview

### Swagger Overview
<img width="1508" height="748" alt="swagger-overview" src="https://github.com/user-attachments/assets/85e14767-9ab4-4bf6-ba37-2288f3c9c775" />


(swagger-overview.png)

### Get Students
<img width="1443" height="560" alt="get-students pic 1" src="https://github.com/user-attachments/assets/0d591749-a288-4a69-9c1b-0f0ea3653364" />

<img width="1420" height="941" alt="get-students pic 2" src="https://github.com/user-attachments/assets/c1669d02-21a8-4d61-b5d3-d55703e6153c" />

### Create Student
<img width="1458" height="665" alt="post-student pic 1" src="https://github.com/user-attachments/assets/04bfdbf6-bb36-4c9e-bd97-c0febc8b955a" />

<img width="1425" height="801" alt="post-student pic 2" src="https://github.com/user-attachments/assets/3788c4e9-f264-4b05-b9b4-0bc18f56e940" />



## Author
Odwa Dyantyi
