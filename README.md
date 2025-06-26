# 🎓 CertificateAPI

ระบบจัดการข้อมูลการอบรมภายในองค์กร พร้อมรองรับ JWT Authentication และ Swagger สำหรับ API Testing

---

## 🚀 Features

- ✅ ลงทะเบียนผู้ใช้งาน พร้อมกำหนด Role
- 🔐 ระบบ JWT Authentication แบบปลอดภัย
- 📄 จัดการข้อมูล Training (CRUD)
- 📦 RESTful API พร้อม Swagger UI
- 🛡 ใช้ Middleware ตรวจสอบ Token
- 📚 เชื่อมต่อฐานข้อมูล MS SQL Server ด้วย EF Core

---

## 🛠 Tech Stack

| Layer          | Technology                    |
|----------------|-------------------------------|
| Backend        | ASP.NET Core 8                |
| ORM            | Entity Framework Core         |
| DB             | Microsoft SQL Server          |
| Auth           | JWT (HS256)                   |
| Docs           | Swagger / Swashbuckle         |
| Config         | DotNetEnv (.env)              |

---

## 📁 Folder Structure

```
CertificateAPI/
├── Controllers/
│   └── TrainingController.cs
├── DTOs/
│   └── Training/
├── Middleware/
│   └── JwtMiddleware.cs
├── Models/
│   └── Training.cs
├── Services/
│   ├── Interfaces/
│   └── Implementations/
├── Data/
│   └── AppDbContext.cs
├── Program.cs
└── appsettings.json
```

---

## ⚙️ Environment Variables (`.env`)

```env
DB_CONNECTION_STRING=Server=...;Database=...;User Id=...;Password=...
JWT_SECRET=your-base64-secret-key
JWT_ISSUER=CertificateAPI
JWT_AUDIENCE=CertificateUser
```

---

## 🧪 Example API Request (via Swagger/Postman)

### 🔐 Auth Login

```http
POST /api/auth/login
```

### 🎓 Create Training

```http
POST /api/trainings
Authorization: Bearer {your_token}
Content-Type: application/json

{
  "title": "Intro to C#",
  "description": "Basic C# and .NET programming course",
  "date": "2025-07-01T09:00:00.000Z",
  "location": "Engineering Hall",
  "trainerName": "Dr. Somchai Wisawa"
}
```

---

## 🧭 Swagger URL

- 👉 http://localhost:{port}/swagger

---

## 🖥 Setup & Run

```bash
# 1. Clone repo
git clone https://github.com/AssaniIndraprasitdhi/CertificateAPI.git
cd CertificateAPI

cp .env.example .env  

# 3. Build & Run
dotnet restore
dotnet ef database update
dotnet run
```

---

## 📌 License

MIT © 2025 Assani Indraprasitdhi

---

> พัฒนาโดยนักศึกษาวิศวกรรมซอฟต์แวร์ — สำหรับฝึกทักษะ Full Stack และ .NET Core API Development
