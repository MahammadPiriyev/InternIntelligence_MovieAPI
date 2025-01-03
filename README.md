# Movie API🎬

This is a RESTful Movie API built with ASP.NET Core Web API. It allows users to perform various CRUD operations on movies, including searching, filtering, and authentication using JWT tokens. 🚀

## Features ✨

- 🛡️ **JWT Authentication**: Secure user authentication using JSON Web Tokens (JWT).
- 🎥 **Movie CRUD Operations**: Create, Read, Update, Delete movie records.
- 🏷️ **Data Integration**: Fetch and manage movie data from TMDB API.
- 🔍 **Search and Filter**: Search and filter movies by title, genre, release date, etc.
- ✅ **Data Validation**: Input validation for movie creation and update.
- 🛠️ **Custom Error Handling**: Clear and structured error messages for better debugging.

## Technologies Used 🧑‍💻

- 🛠️ ASP.NET Core 8.0
- 🖥️ Entity Framework Core
- 🔑 JWT (JSON Web Token) for Authentication
- 🗄️ SQL Server

## API Endpoints 📡

### Authentication 🔒

-  **POST /api/auth/register** - Registers a new user
-  **POST /api/auth/login** - Logs in a user and returns a JWT token
-  **POST /api/auth/logout** - Logs out a user

### Movie Endpoints 🍿

-  **GET /api/movie** - Get a list of all movies (with optional filtering, sorting, and paging)
-  **GET /api/movie/{id}** - Get details of a movie by ID
-  **POST /api/movie/add** - Create a new movie
-  **PUT /api/movie/update/{id}** - Update an existing movie
-  **DELETE /api/movie/remove/{id}** - Delete a movie by ID

### TMDB Endpoints 🎥

-  **GET /api/tmdb/popular** - Get a list of all popular movies from TMDB API
-  **GET /api/tmdb/{movieId}** - Get details of a movie by ID from TMDB API

## Setup Instructions ⚙️

### Prerequisites 🚧

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- SQL Server or other database for storing movie data 💾

### Installation

1. 🌀 Clone the repository:
   ```bash
   git clone https://github.com/MahammadPiriyev/InternIntelligence_MovieAPI.git
   ```

2. 📂 Navigate to the project directory:
   ```bash
   cd MovieAPI
   ```

3. 🔧 Restore the required packages:
   ```bash
   dotnet restore
   ```

4. 📝 Update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=SchoolManagement;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```

5. 📦 Apply migrations and seed the database:
   ```bash
   dotnet ef database update
   ```

6. ▶️ Run the application:
   ```bash
   dotnet run
   ```

## API Endpoints (Authentication)

### 1. **POST /api/auth/register**
- Register a new user.
- Request body:
  ```
  {
    "username": "exampleuser",
    "email": "example@example.com",
    "password": "YourPassword123"
  }
  ```

### 2. **POST /api/auth/login**
- Login an existing user and receive a JWT token.
- Request body:
  ```
  {
    "username": "exampleuser",
    "password": "YourPassword123"
  }
  ```

- Response body:
  ```
  {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
  }
  ```

### 3. **POST /api/auth/logout**
- Logout the authenticated user and invalidate the JWT token.
- Requires a valid JWT token in the Authorization header.

## API Endpoints (CRUD)

### Create Movie 🍿
```bash
POST /api/movie/add
{
    "id": 1,
    "title": "Inception",
    "description": "Good Film",
    "author": "Christopher Nolan",
    "categoryId": 1,
    "rating": 5,
    "createdDate": "2025-01-02T18:31:21.961",
    "updatedDate": "2025-01-02T18:31:21.961"
}
```

### Get All Movies 🎥
```bash
GET /api/movie
```

### Get Movie by ID 🎬
```bash
GET /api/movie/1
```

### Update Movie 🔄
```bash
PUT /api/movie/update/1
{
    "id": 0,
    "title": "string",
    "description": "string",
    "author": "string",
    "categoryId": 0,
    "rating": 5,
    "createdDate": "2025-01-02T18:31:21.961",
    "updatedDate": "2025-01-02T18:31:21.961"
}
```

### Delete Movie 🗑️
```bash
DELETE /api/movie/remove/1
```

## API Endpoints (TMDB)

### Get Movie by ID 🎬
```bash
GET /api/tmdb/{movieId}
{
    "id": 1156593,
    "title": "Your Fault",
    "original_language": "es",
    "release_date": "2024-12-26T00:00:00"
}
```

### Get Popular Movies 🎥
```bash
GET /api/tmdb/popular
[
  {
    "id": 558449,
    "title": "Gladiator II",
    "original_language": "en",
    "release_date": "2024-11-05T00:00:00"
  },
  {
    "id": 1156593,
    "title": "Your Fault",
    "original_language": "es",
    "release_date": "2024-12-26T00:00:00"
  },
  {
    "id": 845781,
    "title": "Red One",
    "original_language": "en",
    "release_date": "2024-10-31T00:00:00"
  }
]
```

## 👤 Author  

**Mahammad Piriyev**  

- LinkedIn: [My LinkedIn Profile](https://linkedin.com/in/mahammadpiriyev)  
- Portfolio: [My Portfolio Website](https://mahammadpiriyev.onrender.com/)
