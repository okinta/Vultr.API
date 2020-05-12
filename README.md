# Vultr.API - Simple .NET Vultr API Client

Forked from https://github.com/koraykaraman/Vultr.API

.NET library to manage Vultr API currently supports;

* /v1/account/...
* /v1/app/...
* /v1/auth/...
* /v1/backup/...
* /v1/server/...

### Features

* Easy installation using [NuGet](https://www.nuget.org/packages/Vultr/) for most .NET flavors

### Example

C#
```csharp

var client = new VultrClient("YOUR-API-KEY-FROM-Vultr.com");
var account = client.Account.GetInfo();
var applications = client.Application.GetApplications();
var backups = client.Backup.GetBackups();
var servers = client.Server.GetServers();

```

