<h1 align="center">Epoch - Smart Time Management</h1>

<div align="center">

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](CONTRIBUTING.md)

---

![.NET 10](https://img.shields.io/badge/.NET_10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Angular 22](https://img.shields.io/badge/Angular_22-DD0031?style=for-the-badge&logo=angular&logoColor=white)
![TypeScript](https://img.shields.io/badge/TypeScript-007ACC?style=for-the-badge&logo=typescript&logoColor=white)
![SignalR](https://img.shields.io/badge/SignalR-00599C?style=for-the-badge&logo=signal&logoColor=white)
![Vitest](https://img.shields.io/badge/Vitest-FCC72B?style=for-the-badge&logo=vitest&logoColor=1E1E20)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)
![Tailwind CSS](https://img.shields.io/badge/Tailwind_CSS-38B2AC?style=for-the-badge&logo=tailwind-css&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)

---

</div>

Epoch is a real-time, timezone-aware smart agenda designed to solve the complexities of modern time management, cross-timezone scheduling, and event collision prevention.

This project serves as a reference implementation of a pragmatic **N-Tier Architecture** using a modern full-stack ecosystem powered by .NET 10, Angular 22, PostgreSQL, and Docker.

---

## 🚧 Project Status

Epoch is currently under active development.

The project is being built as a portfolio piece and reference implementation focused on:
- strict UTC timezone management
- real-time bidirectional communication via WebSockets
- pragmatic N-Tier application structure
- modern Angular patterns (Zoneless + Signals)
- clean developer experience

---

## ✨ Technical Highlights

- **Timezone Engine:** All dates and times are stored and calculated strictly in UTC, delegating local time conversion to the client UI.
- **Smart CRUD & Collision Engine:** Automated calculation of event end-times based on duration, with server-side validation to prevent schedule overlapping.
- **Real-Time Proximity Alerts:** Active pushing of notifications to the frontend via SignalR when an event is 15 minutes away.
- **Pragmatic N-Tier Architecture:** Clean separation of Presentation, Business Logic, and Data Access within a unified, maintainable Web API project.
- **Angular Signals + Zoneless:** Leveraging Angular 22's latest reactivity model.
- **Dockerized Environment:** Zero-friction setup for PostgreSQL and the API.

---

## 🏗️ Architectural Vision

Epoch deliberately avoids over-engineering. Instead of forcing complex architectures (like Clean Architecture or Modular Monoliths) onto a domain that is fundamentally CRUD-heavy, it embraces a well-structured **N-Tier (Layered) Architecture**.

## Core Architectural Principles

- **Layered Responsibilities**
  - **Controllers:** Handle HTTP routing, JWT validation, and input mapping.
  - **Services (BLL):** The heart of the application. Contains the Timezone Engine and Collision Detection logic.
  - **Repositories (DAL):** Exclusive owners of EF Core logic and PostgreSQL interactions.

- **The Timezone Golden Rule**
  The backend speaks only one temporal language: **Absolute UTC**. The UI is strictly responsible for detecting the user's local timezone and mapping the UTC data for display.

- **Mono-repo Strategy**
  Backend and frontend coexist in the same repository, enabling:
  - atomic commits
  - simpler CI/CD orchestration
  - unified versioning
  - easier onboarding

---

## 🚀 Tech Stack

### Backend (.NET 10)
- **Framework:** ASP.NET Core 10 (LTS) Web API
- **Language:** C# 14
- **Database:** PostgreSQL 17 with EF Core 10
- **Architecture:** N-Tier (Layered Monolith)
- **Real-Time:** SignalR
- **Documentation:** Swagger / OpenAPI
- **Testing:** xUnit & Moq

### Frontend (Angular 22)
- **Framework:** Angular 22
- **Language:** TypeScript
- **Rendering Model:** Zoneless by default
- **State Management:** Angular Signals
- **Architecture:** Standalone Components
- **Styling:** Tailwind CSS + SCSS (Hybrid Approach)
- **Testing:** Vitest

### DevOps & Infrastructure
- Docker & Docker Compose
- Multi-stage Docker builds
- PostgreSQL containerized development environment

---

## 📁 Project Structure

```text
src/
 ├── Epoch.Api/                   # ASP.NET Core Web API 
 │    ├── Controllers/            # Presentation Layer
 │    ├── Services/               # Business Logic & Validation Engine
 │    ├── Repositories/           # Data Access Layer
 │    ├── Models/                 # Domain Entities & DTOs
 │    ├── Hubs/                   # SignalR WebSockets Configuration
 │    └── Data/                   # EF Core DbContext & Migrations
 │
 └── Epoch.Client/                # Angular 22 Application
      └── src/app/
           ├── core/              # Guards, Interceptors, Base Services
           ├── shared/            # Reusable UI Components
           └── features/          # Routed modules (Dashboard, Auth)

```

## 🛠️ Getting Started

The project supports two development workflows:

1. Fully containerized setup using Docker
2. Hybrid local development workflow (recommended for active development)

### 🐳 Option 1 — Full Docker Experience

This option requires only Docker installed on your machine. Perfect for recruiters, reviewers, and quick demos.

#### Prerequisites

* Docker (Desktop or Engine)
* Docker Compose

#### Run Everything

```bash
git clone https://github.com/hugoesparzac/NorthwindElementary.git
```
```bash
cd Epoch
```
```bash
docker compose up --build
```

#### Application URLs

| Service | URL |
| --- | --- |
| Frontend | [http://localhost:4200](https://www.google.com/search?q=http://localhost:4200) |
| Backend API | [http://localhost:8080](https://www.google.com/search?q=http://localhost:8080) |
| Swagger UI | [http://localhost:8080/swagger](https://www.google.com/search?q=http://localhost:8080/swagger) |

### 💻 Option 2 — Hybrid Local Development (Recommended)

This workflow provides the best developer experience with Angular Hot Reload and `dotnet watch`.

#### Prerequisites

* .NET 10 SDK
* Node.js 22+
* Angular CLI 22
* Docker (for PostgreSQL)

#### 1. Clone the Repository

```bash
git clone https://github.com/hugoesparzac/NorthwindElementary.git
```
```bash
cd Epoch
```

#### 2. Start PostgreSQL

The development database configuration is included in `appsettings.Development.json`.

```bash
docker compose up database -d
```

#### 3. Run the Backend

```bash
cd src/Epoch.Api
```
```bash
dotnet restore
```
```bash
dotnet watch
```

#### 4. Run the Frontend

Open another terminal:

```bash
cd src/Epoch.Client
```
```bash
npm install
```
```bash
ng serve
```

#### Application URLs

| Service | URL |
| --- | --- |
| Frontend | http://localhost:4200 |
| Backend API | http://localhost:5000 |
| Swagger UI | http://localhost:5000/swagger |

## 🔧 Environment Configuration

> [!NOTE]
> No manual environment configuration is required for local development. The repository includes a preconfigured `appsettings.Development.json` file intended exclusively for development and onboarding purposes.

> [!WARNING]
> **Development Credentials Only:** The `docker-compose.yml` includes default credentials for development purposes only. **Never use these in production.**

## 📝 API Documentation

Interactive documentation is available via Swagger when the API is running in development mode:

* **Swagger UI:** `http://localhost:PORT/swagger`
* **OpenAPI Spec:** `http://localhost:PORT/swagger/v1/swagger.json`

## 🤝 Contributing

Contributions are welcome! Please review our [CONTRIBUTING.md](https://www.google.com/search?q=CONTRIBUTING.md) file for more details on our Git workflow, N-Tier standards, and Timezone Engine rules.

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](https://www.google.com/search?q=LICENSE) file for more details.
