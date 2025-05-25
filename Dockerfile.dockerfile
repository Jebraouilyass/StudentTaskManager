# Use the official .NET SDK image to build the app
     FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
     WORKDIR /app

     # Copy project file and restore dependencies
     COPY *.fsproj ./
     RUN dotnet restore

     # Copy the rest of the application and build
     COPY . ./
     RUN dotnet publish -c Release -o out

     # Use the official .NET runtime image to run the app
     FROM mcr.microsoft.com/dotnet/aspnet:8.0
     WORKDIR /app
     COPY --from=build /app/out .
     EXPOSE 8080
     ENV ASPNETCORE_URLS=http://+:8080
     ENTRYPOINT ["dotnet", "StudentTaskManager.dll"]