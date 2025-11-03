FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/myproject.Web.Mvc/myproject.Web.Mvc.csproj", "src/myproject.Web.Mvc/"]
COPY ["src/myproject.Web.Core/myproject.Web.Core.csproj", "src/myproject.Web.Core/"]
COPY ["src/myproject.Application/myproject.Application.csproj", "src/myproject.Application/"]
COPY ["src/myproject.Core/myproject.Core.csproj", "src/myproject.Core/"]
COPY ["src/myproject.EntityFrameworkCore/myproject.EntityFrameworkCore.csproj", "src/myproject.EntityFrameworkCore/"]
WORKDIR "/src/src/myproject.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/myproject.Web.Mvc", "src/myproject.Web.Mvc"]
COPY ["src/myproject.Web.Core", "src/myproject.Web.Core"]
COPY ["src/myproject.Application", "src/myproject.Application"]
COPY ["src/myproject.Core", "src/myproject.Core"]
COPY ["src/myproject.EntityFrameworkCore", "src/myproject.EntityFrameworkCore"]
WORKDIR "/src/src/myproject.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "myproject.Web.Mvc.dll"]
