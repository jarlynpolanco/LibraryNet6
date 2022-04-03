# Library


## Step to create the environment

- In the appsetting.Development of the web project: Library, place in the ConnectionStrings:DefaultConnection the connection data corresponding to the Server\Local SQL Server instance of the computer to be used.

- Using the console (cmd, powershell, terminal) go to the Models project of the solution to run the migration.

- After being in the Models folder, write the command: "dotnet ef database update -v" to create the tables contained in the project.

- Open any database editor using the connection of the first step to perform the insertion of the test data that is in the root of the solution with the name of "SeedData.sql"

- Open the project with Visual Studio IDE and select the Library web project as a startup.

- Run the project.

- Test the application according to the requirements indicated using the paths: https://localhost:5001/api/author/1/books and https://localhost:5001/api/book/1/page/3/html

- Consider that the version of .net 6.0 must be installed, which can be found in the following path: https://dotnet.microsoft.com/en-us/download/dotnet/6.0 
