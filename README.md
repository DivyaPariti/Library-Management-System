#📖 Library-Management-System


This is a Library Management System project built using ASP.NET CORE and MVC Concept. 


#📝 Required Tools:

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

      

#🚀 Steps to run the code

- After installing the above packages run migrations(adding migrations adds the tables to your database automatically, it removes the need to add, update, delete, and manage the database tables manually.)
       - Commands: 
            - Open Package Manager > Package Manager Console 
            - add-migration
            - update-database

- The last step run the IIS Express and voila you have the Library Management System application up and running successfully!!!
              


#📸 Snippets of the output screen:

        
     User Display Screen:
      
![CP-1](https://user-images.githubusercontent.com/65856784/176759103-53727cf8-8528-4c70-b72e-f148fca4956c.png)

     User Books Catalogue Display Screen:
     
![CP-2](https://user-images.githubusercontent.com/65856784/176759109-5474247c-8ea0-48a6-bcb3-ff11eedcc54a.png)

     Search functionality:
     
![CP-3](https://user-images.githubusercontent.com/65856784/176759111-4db2e773-8669-4014-83cf-f72590cd5304.png)

     Creating a LendRequest:
     
![CP-4](https://user-images.githubusercontent.com/65856784/176759115-ff260ab9-e7aa-4a21-8450-f80cf5ace99c.png)

     
![CP-5](https://user-images.githubusercontent.com/65856784/176759119-a365cd84-1d1d-4fb0-a2ed-28a86ad0967a.png)


![CP-6](https://user-images.githubusercontent.com/65856784/176759124-84df344f-36a4-4185-9851-117a3bcc3866.png)

     Admin/Librarian Display Page: 
        
![CP-7](https://user-images.githubusercontent.com/65856784/176759126-78b73488-ceae-4f5b-b63b-eff40ec8417e.png)

     Admin/Librarian Approval for LendRequest created by the User:
     
![CP-8](https://user-images.githubusercontent.com/65856784/176759128-92df2095-105c-4627-927e-6943dcb0d3d0.png)

     Returnimg the book and calculating the Fine Amount:
     
![CP-9](https://user-images.githubusercontent.com/65856784/176759132-0242c8b6-2093-4832-8c7d-9af7deed164f.png)
