$ErrorActionPreference = "Continue"

if (Test-Path ".git") {
    cmd /c "rmdir /s /q .git"
}

git init
git remote add origin https://github.com/mohamedabdelstar06/Companies-and-branches.git
git branch -M main

git add ZAD.sln .config
git commit -m "Initialize project structure and solution files"

git add src/Core/ZAD.Domain/Entities
git commit -m "Create base entity and domain models"

git add src/Core/ZAD.Domain/Interfaces
git commit -m "Define repository and unit of work interfaces"

git add src/Core/ZAD.Domain
git commit -m "Finalize domain layer configuration"

git add src/Core/ZAD.Application/DTOs
git commit -m "Add data transfer objects for API communication"

git add src/Core/ZAD.Application/Exceptions src/Core/ZAD.Application/Validators src/Core/ZAD.Application/Mapping
git commit -m "Setup application validation mapping and exceptions"

git add src/Core/ZAD.Application/Interfaces src/Core/ZAD.Application/Services src/Core/ZAD.Application
git commit -m "Implement core business logic services"

git add src/Infrastructure/ZAD.Persistence/Configurations src/Infrastructure/ZAD.Persistence/Context
git commit -m "Configure Entity Framework Core application context"

git add src/Infrastructure/ZAD.Persistence/Repositories
git commit -m "Implement repository patterns and unit of work"

git add src/Infrastructure/ZAD.Persistence
git commit -m "Generate initial database migrations"

git add src/Presentation/ZAD.WebAPI/Controllers
git commit -m "Build REST API controllers and endpoints"

git add src/Presentation/ZAD.WebAPI
git commit -m "Configure API middleware logging and settings"

git add ZAD_ERD.drawio README.md .gitignore
git commit -m "Add ERD documentation and repository configuration"

git add .
git commit -m "Finalize repository cleanup and setup"

git push -f -u origin main
