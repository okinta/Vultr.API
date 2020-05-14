# Vultr.API - Simple .NET Vultr API Client

Originally forked from https://github.com/koraykaraman/Vultr.API

C# library to interact with the Vultr API.

**Important:** This library has very minimal testing. Some components may
either be missing or non-functional.

### Example

```csharp
var client = new VultrClient("YOUR-API-KEY-FROM-Vultr.com");
var account = client.Account.GetInfo();
var applications = client.Application.GetApplications();
var backups = client.Backup.GetBackups();
var servers = client.Server.GetServers();
```
