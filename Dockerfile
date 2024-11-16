# Stage 1: Build
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2022 AS build

# Set working directory for build
WORKDIR /source

# Copy the solution and all project files into the container
COPY . .

# Restore NuGet packages for the solution
# RUN nuget restore UserInfoManager.sln

# Build the UserInfoManager.Web project
RUN msbuild ./UserInfoManager.Web/UserInfoManager.Web.csproj /p:Configuration=Release /p:OutputPath=C:\out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2022

# Set the working directory in the runtime container
WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /out/ .

# Expose port for the web application
EXPOSE 80

# Define the entry point for the web application
ENTRYPOINT ["w3wp"]
