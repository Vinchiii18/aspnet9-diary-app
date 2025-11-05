FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore "Diary.sln"
# Build and publish a release
RUN dotnet publish "DiaryApp/DiaryApp.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "DiaryApp.dll"]