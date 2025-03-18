FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Definir argumento para a senha do NuGet
ARG ARG_SECRET_NUGET_PACKAGES


COPY . ./

WORKDIR /App/TCFiapProducerCreateContact

# Adicionar a fonte privada do GitHub Packages
RUN if ! dotnet nuget list source | grep -q "github"; then \
      dotnet nuget add source "https://nuget.pkg.github.com/caiofabiogomes/index.json" \
      --name github \
      --username caiofabiogomes \
      --password "$ARG_SECRET_NUGET_PACKAGES" \
      --store-password-in-clear-text; \
    fi

RUN dotnet restore 
RUN dotnet publish TCFiapProducerCreateContact.API/TCFiapProducerCreateContact.API.csproj -c Release -o /App/out


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

COPY --from=build-env /App/out ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "TCFiapProducerCreateContact.API.dll"]
