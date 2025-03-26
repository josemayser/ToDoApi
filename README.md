# ToDoApi 📝

A simple, clean and modular .NET 8 Web API for managing to-do items, users, and authentication using JWT. Built
following Clean Architecture principles and backed by PostgreSQL.

## 🔧 Tech Stack

- **.NET 8**
- **PostgreSQL**
- **JWT Authentication**
- **Clean Architecture**
- **Postman Collection**

## 📦 Project Structure

This project follows Clean Architecture, splitting concerns into multiple layers:

```
src/
├── ToDoApi.Api            // Controllers
├── ToDoApi.Application    // Services, Use Cases
├── ToDoApi.Domain         // Models
├── ToDoApi.Infrastructure // DB Context, Repositories
```

## 🚀 Getting Started

### 1. Clone the repository:

```
bash
git clone https://github.com/josemayser/ToDoApi.git
```

### 2. Go to root directory:

```
bash
cd ToDoApi
```

### 3. Set your connection string:

```
bash
export ConnectionStrings__DefaultConnection=“Host=localhost;Port=5432;Database=to_do;Username=your_username;Password=your_password”
```

### 4. Run the app:

```
bash
dotnet run –project src/ToDoApi.Api
```

## 🔐 Authentication

This API uses JWT for authentication. After logging in, include the token in the Authorization header for protected
routes:

```
Authorization: Bearer <your_token>
```

## 📬 API Endpoints

### 🔑 Auth

- **POST - /api/auth/user-registration – Register a new user**
- **POST - /api/auth/login – Authenticate and get JWT token**

### 👤 Users

- **GET - /api/users/authenticated – Get authenticated user**

### ✅ Items

- **GET - /api/items – List all items of authenticated user**
- **GET - /api/items/{itemId} – Get a specific item**
- **POST - /api/items – Create a new item**
- **PUT - /api/items/{itemId} – Update a specific item**
- **DELETE - /api/items/{itemId} – Delete a specific item**

## 📫 Postman Collection

You can import the Postman collection and environment from:

```
postman/
├── ToDoApi.postman_collection.json
├── ToDoApiEnvironment.postman_environment.json
```