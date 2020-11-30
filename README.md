# Social Media For Modelers (Working Title)
- Author: Trevor Stubbs

---
## Web Application
- A web API that will serve a database and business logic to a view application. 

---

## Tools Used
Microsoft Visual Studio Community 2019

- C#
- Entity Framework
- MVC

## Data Model 
### Overall Project Schema 
![ERD V2](assets/SMModelV2.png)

### Routes
[API Routes](Routes.md)
  
### Model Properties and Requirements TODO
---
## Project Organization
- [GitHub Projects](https://github.com/TrevorStubbs/SocialMediaForModelers/projects)

### Scrum Log
- Sprint 1
  - Milestone 1
    - Initial Repo Build
    - ERD Scaffold
    - EF Core setup
- Sprint 2
  - Milestone 1
    - US1 PostCommentManager
    - US2 PostCommentManager Tests
  - Milestone 2
    - US1 PostImageManager
    - US2 PostImageManager Tests
  - Milestone 3
    - US 1 ApplicationUser
    - US 2 RoleInitializer
  - Milestone 4
    - US 1 UserPageManager
    - US 2 UserPageManager Tests
  - Milestone 5
    - US 1 UserPostManager
    - US 2 UserPostManager Tests
  - Milestone 6
    - US 1 AWS Setup
    - US 2 AWS S3 Manager
    - US 3 AWS S3 Integration
- Sprint 3
  - Milestone 1
    - US1 Route Plan
    - US2 Swagger Install
    - US3 JWT Token initialization
    - US4 Account Controller Built
  - Milestone 2
    - US 1 UserPageController Scaffold
    - US 2 UserPageController Methods
    - US 3 UserPageController Swagger Testing
  - Milestone 3
    - US 1 UserPostController Scaffold
    - US 2 UserPostController Methods
    - US 3 UserPostController Swagger Testing
  - Milestone 4
    - US 1 PostCommentController Scaffold
    - US 2 PostCommentController Methods
    - US 3 PostCommentController Swagger Testing
  - Milestone 5
    - US 1 PostImageController Scaffold
    - US 2 PostImageController Methods
    - US 3 PostImageController Swagger Testing
- Sprint 4
  - Milestone 1
    - US 1 Updated each entity with DateTime
    - US 2 Added DateTime when entity is created/modified
    - US 3 DateTime Tests
    - Us 4 Update methods are fixed.
  - Milestone 2
    - US 1 LikeGetter
    - US 2 Implement LikeGetter
    - US 3 Testing all the Like getters
  - Milestone 3
    - US 1 PostComment Delete Procedure
    - US 2 PostImage Delete Procedure
    - US 3 UserPost Delete Procedure
    - US 4 UserPage Delete Procedure
