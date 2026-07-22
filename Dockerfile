# ============================================
# E-Word-Api Dockerfile
# .NET 8 ASP.NET Core Web API
# ============================================

# --- Build Stage ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Restore dependencies (cache layer)
COPY ["E-Word-Api.csproj", "./"]
RUN dotnet restore "E-Word-Api.csproj"

# Copy everything and publish
COPY . .
RUN dotnet publish "E-Word-Api.csproj" -c Release -o /app/publish --no-restore

# --- Runtime Stage ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Create Statics directory for avatar uploads
RUN mkdir -p /app/Statics

# Copy published output
COPY --from=build /app/publish .

# Expose port
EXPOSE 5194
ENV ASPNETCORE_URLS=http://+:5194
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DISABLE_HTTPS_REDIRECT=true

ENTRYPOINT ["dotnet", "E-Word-Api.dll"]
