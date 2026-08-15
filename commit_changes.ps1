$ErrorActionPreference = "Stop"

# Set Git identity
git config user.name "mohamedabdelstar06"
git config user.email "mohamedabdelstar06@users.noreply.github.com"

# 1. Update Domain Entities
git add src/Core/ZAD.Domain/Entities/Branches/Branch.cs src/Core/ZAD.Domain/Entities/Companies/Company.cs
git commit -m "Update Domain Entities for Company and Branch"

# 2. Update EF Core configurations
git add src/Infrastructure/ZAD.Persistence/Configurations/BranchConfiguration.cs src/Infrastructure/ZAD.Persistence/Configurations/CompanyConfiguration.cs src/Infrastructure/ZAD.Persistence/Context/ApplicationDbContext.cs
git commit -m "Update EF Core configurations for Company and Branch"

# 3. Generate migrations
git add src/Infrastructure/ZAD.Persistence/Migrations/
git commit -m "Generate migrations for new table structures"

# 4. Update Repositories
git add src/Infrastructure/ZAD.Persistence/Repositories/
git commit -m "Update Repositories for data access"

# 5. Update Company DTOs
git add src/Core/ZAD.Application/DTOs/Company/
git commit -m "Update DTOs for Company details and listing"

# 6. Update Branch DTOs
git add src/Core/ZAD.Application/DTOs/Branch/
git commit -m "Update DTOs for Branch details and listing"

# 7. Add Lookups
git add src/Core/ZAD.Application/DTOs/Lookups/
git commit -m "Add Lookups DTO"

# 8. Update AutoMapper profiles
git add src/Core/ZAD.Application/Mapping/
git commit -m "Update AutoMapper profiles"

# 9. Update Application interfaces and services
git add src/Core/ZAD.Application/Interfaces/ src/Core/ZAD.Application/Services/
git commit -m "Update Application interfaces and services"

# 10. Update Web API Controllers
git add src/Presentation/ZAD.WebAPI/Controllers/
git commit -m "Update Web API Controllers"

# 11. Configure GlobalExceptionMiddleware and FileUploadService
git add src/Presentation/ZAD.WebAPI/Middleware/ src/Presentation/ZAD.WebAPI/Services/ src/Presentation/ZAD.WebAPI/Program.cs
git commit -m "Configure GlobalExceptionMiddleware and FileUploadService"

# 12. Initialize Angular frontend core structure
git add src/Presentation/ZAD.Erp/angular.json src/Presentation/ZAD.Erp/package.json src/Presentation/ZAD.Erp/package-lock.json src/Presentation/ZAD.Erp/tsconfig*.json src/Presentation/ZAD.Erp/src/main.ts src/Presentation/ZAD.Erp/src/index.html src/Presentation/ZAD.Erp/src/styles.scss src/Presentation/ZAD.Erp/src/app/app.*
git commit -m "Initialize Angular frontend core structure"

# 13. Add Angular core services and intercepts
git add src/Presentation/ZAD.Erp/src/app/core/
git commit -m "Add Angular core services and interceptors"

# 14. Add Angular shared UI components
git add src/Presentation/ZAD.Erp/src/app/shared/ src/Presentation/ZAD.Erp/src/app/layout/
git commit -m "Add Angular shared UI components"

# 15. Implement Company feature module in frontend
git add src/Presentation/ZAD.Erp/src/app/features/companies/
git commit -m "Implement Company feature module in frontend"

# 16. Implement Branch feature module in frontend
git add src/Presentation/ZAD.Erp/src/app/features/branches/
git commit -m "Implement Branch feature module in frontend"

# 17. Add assets and remaining frontend files
git add src/Presentation/ZAD.Erp/
git commit -m "Add assets and remaining frontend files"

# 18. Add any remaining untracked/modified files
git add .
git commit -m "Misc fixes and cleanup"

# Push
git push origin main
