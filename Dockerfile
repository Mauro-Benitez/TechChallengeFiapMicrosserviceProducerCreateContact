FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

ARG ARG_SECRET_NUGET_PACKAGES

COPY . ./
# Adicionar a fonte privada do GitHub Packages
RUN dotnet nuget add source "https://nuget.pkg.github.com/caiofabiogomes/index.json" \
    --name github \
    --username caiofabiogomes \
    --password "$ARG_SECRET_NUGET_PACKAGES" \
    --store-password-in-clear-text


WORKDIR /App

RUN dotnet restore 
RUN dotnet publish TCFiapProducerCreateContact.API/TCFiapProducerCreateContact.API.csproj -c Release -o /App/out


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

COPY --from=build-env /App/out ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "TCFiapProducerCreateContact.API.dll"]
