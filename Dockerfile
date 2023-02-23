# Use the official .NET SDK image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set the working directory in the container to /app
WORKDIR /app

# Copy the entire project into the container
COPY . .

# Restore the NuGet packages
RUN dotnet restore



# Publish the application
RUN dotnet publish -c Release -o out

# Set the startup command to run the published application
# CMD ["dotnet", "publish/SoftwareCodingChallenges.dll"]


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SoftwareCodingChallenges.dll"]
