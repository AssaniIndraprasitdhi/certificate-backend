# certificate-backend

A RESTful API for managing training courses and user authentication using ASP.NET Core (.NET 8), Entity Framework Core, SQL Server, and JWT.

## Features

- User Registration & JWT Authentication
- Role-based Access Control (default role: USER)
- CRUD operations for Training courses
- Swagger UI integration for API testing
- Middleware-based JWT validation
- Environment-based configuration with `.env`
- Seed data for default roles

## Tech Stack

- **Backend**: ASP.NET Core (.NET 8)
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: JWT Bearer Tokens
- **Middleware**: Custom JWT validation
- **Documentation**: Swagger UI
- **Environment Config**: DotNetEnv

## Folder Structure

```
CertificateAPI/
├── Controllers/
│   └── TrainingController.cs
├── DTOs/
│   └── Training/
│       └── TrainingDto.cs
├── Middleware/
│   └── JwtMiddleware.cs
├── Models/
│   ├── Training.cs
│   ├── User.cs
│   └── UserRole.cs
├── Services/
│   ├── Interfaces/
│   │   ├── IAuthService.cs
│   │   └── ITrainingService.cs
│   └── Implementations/
│       ├── AuthService.cs
│       └── TrainingService.cs
├── Data/
│   ├── AppDbContext.cs
│   └── SeedData.cs
├── Program.cs
└── appsettings.json
```

## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/AssaniIndraprasitdhi/certificate-backend.git
cd CertificateAPI
```

### 2. Setup Environment Variables

Create a `.env` file in the root directory with the following content:

```env
DB_CONNECTION_STRING=YourConnectionStringHere
JWT_SECRET=YourSecureSecretKeyHere
JWT_ISSUER=CertificateAPI
JWT_AUDIENCE=CertificateUser
```

> 💡 Use a secure random string (Base64 or ASCII ≥ 32 chars) for `JWT_SECRET`.

### 3. Run Migrations

Ensure your SQL Server instance is running, then:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

Access Swagger UI at: `https://localhost:{port}/swagger`

---

## API Endpoints

### Auth

- `POST /api/auth/register` – Register a new user (role: USER)
- `POST /api/auth/login` – Login and receive JWT token

### Training

- `GET /api/trainings` – Get all trainings
- `GET /api/trainings/{id}` – Get training by ID
- `POST /api/trainings` – Create new training (requires JWT)
- `PUT /api/trainings/{id}` – Update training (requires JWT)
- `DELETE /api/trainings/{id}` – Delete training (requires JWT)

> Add `Authorization: Bearer {token}` header when calling secured endpoints.

---

## Authentication (JWT)

The system uses JWT Bearer token for authentication. Token must be included in the request header:

```
Authorization: Bearer <your_token>
```

### Example Token Payload

```json
{
  "sub": "user_id",
  "email": "user@example.com",
  "role": "USER",
  "exp": 1750912761,
  "iss": "CertificateAPI",
  "aud": "CertificateUser"
}
```

---

## Error Handling

- `401 Unauthorized`: Missing/invalid token
- `400 Bad Request`: Invalid payload or missing fields
- `500 Internal Server Error`: Database or server issue

---

## License

This project is licensed under the MIT License.
