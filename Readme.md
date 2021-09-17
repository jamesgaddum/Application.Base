# Flatties


### Migrations

All migrations are run from and stored in the `Flatties.Matching.Persistence` project.

In order to create and run a migration for a startup project (i.e. `Flatties.Matching.WebApi` or `Flatties.Matching.Application.Tests`), you need to invoke the following commands from the `Flatties.Matching.Persistence` directory:

```
dotnet ef migrations add InitialCreate --startup-project ../Flatties.Matching.Application.Tests/Flatties.Matching.Application.Tests.csproj

dotnet ef database update --startup-project ../Flatties.Matching.Application.Tests/Flatties.Matching.Application.Tests.csproj
```

The migration will be applied to the database that the startup project is configured to connect to.
