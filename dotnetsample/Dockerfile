# Create the base/runtime image. base word will be used for debugging the container
FROM mcr.microsoft.com/dotnet/core/runtime:3.1 as base
WORKDIR /app

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
ENTRYPOINT ["dotnet", "dotnetsample.dll"]
#RUN ["dotnet", "dotnetsample.dll"]
#ENTRYPOINT ["cmd", "/S", "/C"] or CMD ["cmd", "/S", "/C"] both will give same resize error 