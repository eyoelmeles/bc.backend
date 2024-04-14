# last step

> Run every command inside the site folder

## Migrations

- cd Site.Infrastructure

- dotnet ef migrations add InitialCreate --startup-project ../Site.Api

- dotnet ef database update --startup-project ../Site.Api
