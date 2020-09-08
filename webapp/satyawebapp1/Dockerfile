# Create the base/runtime image. base word will be used for debugging the container
# Image mcr.microsoft.com/dotnet/core/runtime is not working hence we are using aspnet instead of runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as base
WORKDIR /app
# Set the environment to Developement for the container so that in case of errors we can check developer exception page
ENV ASPNETCORE_ENVIRONMENT="Development"
# Create the build environment image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# Copy the project file and restore the dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source files and build the application
COPY . ./
# This step threw error if dockerignore file is not added
RUN dotnet publish -c Release -o out --no-restore

# The runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/out ./

# Open up port (This just works as documentation. We still need to use -P or -p in run command)
EXPOSE 5000
ENTRYPOINT ["dotnet", "satyawebapp1.dll"]