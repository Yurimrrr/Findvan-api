# .NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Sets the working directory
WORKDIR /app

# Copy Projects
#COPY *.sln .
COPY Findvan.Domain/Findvan.Domain.csproj .
COPY Findvan.Domain.Api/Findvan.Domain.Api.csproj .
COPY Findvan.Domain.Infra/Findvan.Domain.Infra.csproj .
COPY Findvan.Domain.Tests/Findvan.Domain.Tests.csproj .

# .NET Core Restore
RUN dotnet restore Findvan.Domain.Api.csproj

# Copy All Files
COPY ./ .

# .NET Core Build and Publish
RUN dotnet publish ./Findvan.Domain.Api/Findvan.Domain.Api.csproj -c Release -o /publish

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS runtime
WORKDIR /app
COPY --from=build /publish ./
#EXPOSE 80
#EXPOSE 443
ENTRYPOINT ["dotnet", "Findvan.Domain.Api.dll"]
