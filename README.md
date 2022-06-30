# Library-Management-System


This is a Library Management System project built using ASP.NET CORE and MVC Concept. 

In order to get this project up and running 
- Firstly, download the Zip folder and unzip it into your local system.
- Secondly install all the necessary tools for the project

- Visual Studio 2019 Community Edition 

        link to download Visual Studio Code: https://code.visualstudio.com/download

- Microsoft .NET Core Framework 3.1 

       link to download dontnet core 3.1: https://dotnet.microsoft.com/en-us/download/dotnet/3.1

- You'll be needing SQL Server in order to store the data into the database for that download:
        
        - Microsoft SQL Server 
          link to download Microsoft SQL Server: https://www.microsoft.com/en-in/sql-server/sql-server-downloads
            &
        - SQL Server Management Studio(SSMS)
          link to download  SQL Server Management Studio(SSMS): https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

- Open the file structure in the Visual Studio Code
- Open the Package Manager; Tools > NuGet Package Manager >  Manage NuGet Packages; and install the following:

      - Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
      - Microsoft.EntityFrameworkCore
      - Microsoft.EntityFrameworkCore.SqlServer
      - Microsoft.EntityFrameworkCore.Tools
- After installing the above packages run migrations(adding migrations adds the tables to your database automatically, it removes the need to add, update, delete, and manage the database tables manually.)
       
       - Commands: 
            - Open Package Manager > Package Manager Console 
            - add-migration
            - update-database

- The last step run the IIS Express and voila you have the Library Management System application up and running successfully!!!
              
