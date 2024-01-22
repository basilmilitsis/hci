# Solution Overview

I've used a Vistual Studio template to get started with this project, it created:
- hci.client
- HCI.Server
> the template spat out the names with different casing


> NOTE: I've also left a few comments in the code here and there to explain some shortcuts I've taken.


---
## HCI.Server
### Summary:
- talks to SQL server
- EF (model first) used

### Folder Structure:
```
- /Database
    - /Initialiser (seed data)
    - /Migrations  (EF migrations)
    - /Models      (EF models)
- /Dto             (data transfer objects)
```

### Egregious Shortcuts:
- appsettings.Production.json is checked in to git
- controller method in program.cs


## HCI.Client
### Summary:
- very basic tailwind styling
- talks to HCI.Server over REST
- uses Tailwind CSS

### Folder Structure:
```
- /src
    - /apiSchema          (api schema types)
    - /components         (reusable components)
        - /framework      (page/layout components)
        - /inputs         (input components)
    - /pages              (page components)
```

### Egregious Shortcuts:
- hardcoded schema instead of code generation
- no DTO validation
- reused search filter for both user and hospital for time

---
# Tests
- no tests, left out for time


---
# Running locally
Ensure you have the following installed:
- dotnet-ef: `dotnet tool install --global dotnet-ef`

### Run:
- install node packages
  - `cd hci.client`
  - `npm i`
- run tailwind watch in dev mode 
    - `npm run tailwind`
- build and run from Visual Studio

---
# Deploying
### Steps:
- sync EF models to Production SQL
    - run `HCI.Server\update-production-db.ps1`
- publish
    - publish HCI.Server project (profile not checked in)
---