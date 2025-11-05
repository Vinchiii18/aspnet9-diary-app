# My Diary Application

A simple diary application built with ASP.NET Core MVC that allows users to create, read, update, and delete diary entries.

## Project Status
- ✅ Local Development: Working perfectly with SQL Server LocalDB
- ❌ Production Deployment: Attempted but currently not deployed

## Technical Stack
- ASP.NET Core MVC (.NET 9)
- Entity Framework Core
- SQL Server LocalDB (local development)
- Bootstrap for UI

## Features
- CRUD operations for diary entries
- Soft delete functionality
- Date picker integration
- Form validation
- Responsive design

## Deployment Attempts
We attempted deployment to Render.com but encountered several challenges:
- .NET 9 compatibility issues with Render's container runtime
- PostgreSQL migration complexities
- Docker configuration challenges

**Note**: Currently, this application is maintained for local development only, using SQL Server LocalDB. The deployment-related commits in this repository represent learning attempts but are not production-ready.

## Local Development
To run this application locally:
1. Clone the repository
2. Ensure you have SQL Server LocalDB installed
3. Update connection string if needed
4. Run the application in Visual Studio 2022

## Learning Experience
This project served as a valuable learning experience in:
- ASP.NET Core MVC development
- Database management with Entity Framework
- Understanding deployment challenges
- Working with Docker and PostgreSQL (though ultimately not implemented)

While the deployment wasn't successful, the local application remains fully functional and serves its purpose as a personal diary management system.
