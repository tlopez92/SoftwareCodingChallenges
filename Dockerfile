# Use the official .NET SDK image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:7.0

# Set the working directory in the container to /app
WORKDIR /app

# Copy the project file into the container
COPY *.csproj .

# Restore the NuGet packages
RUN dotnet restore

# Copy the entire project into the container
COPY . .

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Set the startup command to run the published application
CMD ["dotnet", "publish/SoftwareCodingChallenges.dll"]
