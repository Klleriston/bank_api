## Project Overview

This API is designed to handle various banking operations, catering to both individual and legal users. It utilizes the .NET framework, Entity Framework Core for database interactions, and Swagger for API documentation.

## Technologies Used

- **ASP.NET Core:** The foundation of the web API.
- **Entity Framework Core:** Used for database modeling and interactions.
- **Swagger:** Provides a user-friendly interface for API documentation.
- **PostgreSQL:** Chosen as the database to store user and transaction data.

## Features

- **User Management:** Create, update, and delete individual and legal user profiles.
- **Transaction Handling:** Support for various banking transactions such as deposits, withdrawals, and transfers.
- **Scalability:** Designed with scalability in mind to handle a growing user base.

## Database Configuration

This project uses PostgreSQL as the database. Make sure to update the connection string in the `appsettings.json` file to match your PostgreSQL database configuration.

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=YourDatabaseName;Username=YourUsername;Password=YourPassword"
}
```

## Contributing

If you would like to contribute to this project, please contact me.

@kekz001
