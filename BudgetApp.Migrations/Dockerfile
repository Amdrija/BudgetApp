FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BudgetApp.Migrations/BudgetApp.Migrations.csproj", "BudgetApp.Migrations/"]
RUN dotnet restore "BudgetApp.Migrations/BudgetApp.Migrations.csproj"
COPY . .
WORKDIR "/src/BudgetApp.Migrations"
RUN dotnet build "BudgetApp.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BudgetApp.Migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BudgetApp.Migrations.dll"]
