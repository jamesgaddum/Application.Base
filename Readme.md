# Base Application


### Migrations

All migrations are run from and stored in the `Application.Base.Persistence` project.

In order to create and run a migration for a startup project (i.e. `Application.Base.WebApi` or `Application.Base.Application.Tests`), you need to invoke the following commands from the `Application.Base.Persistence` directory:

```
dotnet ef migrations add InitialCreate --startup-project ../Application.Base.Application.Tests/Application.Base.Application.Tests.csproj

dotnet ef database update --startup-project ../Application.Base.Application.Tests/Application.Base.Application.Tests.csproj
```

The migration will be applied to the database that the startup project is configured to connect to.
