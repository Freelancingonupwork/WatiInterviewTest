# Use the official ASP.NET Core Runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the published web project into the image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["F:/Projects/Github/WatiInterviewTest/WatiInterviewTest.Web/WatiInterviewTest.Web.csproj", "watiInterviewtest.web/"]
RUN dotnet restore "watiInterviewtest.web/WatiInterviewTest.Web.csproj"
COPY . .
WORKDIR "/src/WatiInterviewTest.Web"
RUN dotnet build "WatiInterviewTest.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WatiInterviewTest.Web.csproj" -c Release -o /app/publish

# Use the base image and copy the published output from the build image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WatiInterviewTest.Web.dll"]
