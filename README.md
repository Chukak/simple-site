# testsite

Simple site on `C#` and `ASP.NET Core` with registration and user account.

To install dotnet in Linux (Ubuntu 18.04)
```bash
wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo add-apt-repository universe
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-2.2
```

To install postgres in Linux 
```bash
sudo apt-get install postgresql-10 postgresql-client-10
```

To install npgsql
```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 2.2.0	
```
