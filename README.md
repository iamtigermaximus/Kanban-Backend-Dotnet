# Kanban Dotnet Backend

This is the backend for a Kanban application built with .NET.

## Table of Contents
- [Introduction](#introduction)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)

## Introduction <a name="introduction"></a>

The Kanban Dotnet Backend is responsible for managing projects, tasks, subtasks and categories in a Kanban board. It provides RESTful API endpoints for creating, updating, and retrieving Kanban board data.

## Getting Started <a name="getting-started"></a>

To run the project locally, follow these steps:

1. Clone the repository: `git clone https://github.com/iamtigermaximus/Kanban-Backend-Dotnet.git`
2. Install the necessary dependencies: `dotnet restore`
3. Set up the database connection in the `appsettings.json` file.
4. Apply any necessary database migrations: `dotnet ef database update`
5. Run the application: `dotnet run`

Make sure you have .NET SDK installed on your machine.

## Project Structure <a name="project-structure"></a>

The project follows the following directory structure:

├── Controllers # Contains the API controllers

├── Data # Contains the data access layer

├── DTOs # Contains the Data Transfer Objects

├── Models # Contains the application models

├── Services # Contains the business logic services

├── Migrations # Contains database migration files

├── appsettings.json # Configuration file for the application

├── Program.cs # Entry point of the application

