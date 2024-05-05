# Comply Test Project
A web application that allows users to view a list of items and add new items. The application is developed using Angular and .NET 8.

## Directory Structure

This project contains the following folders:
- `todo-core`: Contains domain enties, repositories and services
- `todo-data`: Data layer that host entity database migrations, EF Core context and implementations of the domain repositories
- `todo-services`: Service layer contains implementations of the domain services
- `todo-api`: Entrypoint that bootstraps and runs the backend .NET Core Web Api
- `Todo.IntegrationTests`: Contains Api integration tests
- `todo-ui`: Frontend application in Angular

## Application Setup

- `Database`: The application uses SQLServer database, and EF Core migrations tool for applying domain entity changes to the database.
- `Backend`: The Api is written using `.NET Core 8.0`
- `Frontend`: The front is built using `Angular v17`

## Database
The EF Core tools is needed to create a database and run migrations. Runs this command to install the EF core tools `dotnet tool install --global dotnet-ef`. 
In the root folder run docker compose to spin up the SQL Server database `docker-compose up -d`.
Once the EF Core tools is installed, proceed to apply any pending migrations by executing this command `dotnet ef database update --verbose --project todo-data   --startup-project todo-api`

## API
To run the API, execute this command: `dotnet run --project todo-api --launch-profile http`

## UI
The frontend can be run by first installing packages with `npm i`, then start server with: `npm start` command

## Integration Tests
The API integration tests can be executed by this command `dotnet test Todo.IntegrationTests`