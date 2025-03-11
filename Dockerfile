FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

COPY . ./

WORKDIR /App/TCFiapProducerCreateContact

RUN dotnet restore 
RUN dotnet publish TCFiapProducerCreateContact.API/TCFiapProducerCreateContact.API.csproj -c Release -o /App/out


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

COPY --from=build-env /App/out ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "TCFiapProducerCreateContact.API.dll"]