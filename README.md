# person-api

This application use dotnet 3.1 and the dotnet cli to run and test a webapi that adds people to a database. The application project uses three nuget packages `Microsoft.EntityFrameworkCore.Sqlite` and `Microsoft.EntityFrameworkCore.SqlServer` to run the backend db with entity framework and `Microsoft.VisualStudio.Web.CodeGeneration.Design` to scaffold the `Person` model into controllers. Run the application via the dotnet cli by navigating to the application directory `./PersonApplication` and using `dotnet run`.

With the application running we can view all present people in the db with GET on the Person endpoint, by visiting the following in the browser or using postman `https://localhost:5001/api/Person`. People can be added by posting to the same endpoint `https://localhost:5001/api/Person` with either just a name `{"Name" : "test name"}` or all of the fields in a Person object `{ "id": 21, "name": "first last", "dateAdded": "2020-08-17T21:19:57.1634195Z"}` 

Static html is hosted at `https://localhost:5001/` and lets you use a simple form to Add a new person with an inputted name.

The tests for the application can be started by running `dotnet test` at the root of the project or in the test project directory `./PersonApplication.Tests `
