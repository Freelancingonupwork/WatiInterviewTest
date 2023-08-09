# Use the official ASP.NET Core Runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the published web project into the image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["F:/Projects/Github/WatiInterviewTest/WatiInterviewTest.Api/WatiInterviewTest.Api.csproj", "WatiInterviewTest.Api/"]
RUN dotnet restore "WatiInterviewTest.Api/WatiInterviewTest.Api.csproj"
COPY . .
WORKDIR "/src/WatiInterviewTest.Api"
RUN dotnet build "WatiInterviewTest.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WatiInterviewTest.Api.csproj" -c Release -o /app/publish

# Use the base image and copy the published output from the build image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WatiInterviewTest.Api.dll"]
