FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /src
COPY . .
RUN dotnet restore ECommerceApp.API/ECommerceApp.API.csproj
WORKDIR /src/ECommerceApp.API
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as run
expose 80
WORKDIR /app
COPY --from=build /app/ .
CMD dotnet ECommerceApp.API.dll