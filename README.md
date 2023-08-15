# GeilNote

Project for the "REST application programming" courses at the University of Gdańsk.

## Description

GeilNote is a REST API for managing notes. It allows you to create, read, update and delete notes. Each note has a title, content and a tag. Backend is writen in C# using ASP.NET with Entity Framework Core. Frontend is written in Nuxt.js with TypeScript.

## Installation

### Backend

1. Install .NET Core 3.1 SDK
2. Install Microsoft SQL Server
3. Install Entity Framework Core CLI
4. Set connection string in `appsettings.json`
5. Run `dotnet ef database update` in `GeilNote.backend` directory or `Update-Database` in VS Package Manager Console
6. Run `dotnet run` in `GeilNote.backend` directory or run in VS Studio

### Frontend

1. Install Node.js
2. Run `npm install` in `GeilNote.frontend` directory
3. Run `npm run dev` in `GeilNote.frontend` directory

## Usage

### Backend

API is available at `http://localhost:7114/api/`

### Frontend

Frontend is available at `http://localhost:3000`

## License

[MIT](https://choosealicense.com/licenses/mit/)
