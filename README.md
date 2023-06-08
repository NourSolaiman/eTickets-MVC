# eTickets-MVC

Overview
eTickets is a web-based application that aims to streamline the process of buying and selling tickets for various movies'tickets from different Cinemas in the city. This user-friendly platform provides a convenient ticketing experience, making it straightforward for customers to find and purchase tickets, and for event organizers to manage their ticket sales and distributions.

Key Features
Event Creation and Management: eTickets allows event organizers to create and manage their movies effortlessly. They can add new movies, provide necessary details, set ticket prices, and oversee their listings.

Ticket Purchasing: Customers can browse through the movies listed, select the one they are interested in, and purchase tickets directly on the platform.

User Authentication and Authorization: The app includes secure user registration and sign-in processes. It also offers role-based access control, ensuring a clear distinction between event organizer and customer functionalities.

Payment Processing: eTickets integrates a secure and dependable payment gateway for ticket payment processing (this section is not done yet).

Interactive User Interface: The app offers a user-friendly, intuitive interface that ensures smooth navigation.

Error Handling: The application effectively handles and displays errors with user-friendly messages, contributing to a smoother user experience.

Technology Stack
eTickets is built using Microsoft's ASP.NET Core framework and leverages Entity Framework Core (EF Core) for its data access layer. EF Core is a powerful Object-Relational Mapping (ORM) framework that simplifies data access by allowing you to interact with your database using .NET objects.

For its database requirements, eTickets uses SQL Server. The project incorporates EF Core Migrations to manage database changes and keep the database schema in sync with the EF Core data model.

The application also uses various NuGet packages to extend its functionality, including the Microsoft.Owin.Host.SystemWeb package for managing the app's security and user authentication.

Getting Started
Follow these steps to get a local copy up and running:

Clone the repository.

Navigate to the 'eTickets' directory.

Install the required NuGet packages by running the command dotnet restore.

You need to apply the database migrations using Entity Framework tools. First, ensure that the EF Core tools are installed. If not, install it using the command dotnet tool install --global dotnet-ef. Once installed, you can apply the migrations using the command dotnet ef database update.

Start the application by running the command dotnet run.

Please remember to replace the "DefaultConnectionString" in your appsettings.json file with your actual connection string.

Conclusion
eTickets is a robust and scalable application, designed to address all your ticketing needs. Its extensive features combined with its simplicity and efficiency make it an ideal solution for both event organizers and ticket buyers. Whether you're planning a small local event or a large-scale concert, eTickets can handle your ticketing needs with ease.
