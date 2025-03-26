# TechChallengeFiapMicrosserviceProducerCreateContact

Este microsserviço .NET envia mensagens para o RabbitMQ e cria as respectivas filas para cada operação(Criar, Atualizar, Deletar).

## Este projeto foi desenvolvido como parte de um trabalho da pós-graduação de arquitetura de software da FIAP.
 - [🔗 Confira outros microsserviços do projeto.](https://github.com/caiofabiogomes/TechChallenge-FIAP-Microsservices)

## Tecnologias Utilizadas
- .NET 8
- MassTransit
- RabbitMQ
- Docker
- NUnit
- Moq
- TechChallenge.SDK

## Pré-requisitos
- .NET SDK 8.0
- RabbitMQ (local ou via container)
- Docker instalado (caso utilize container)

## Como Executar

### Localmente
```sh
git clone https://seurepositorio.com/TechChallengeFiapMicrosserviceProducerCreateContact.git
cd TechChallengeFiapMicrosserviceProducerCreateContact
dotnet restore
dotnet build
dotnet run --project TCFiapProducerCreateContact.API
```

### Docker
```sh
docker build --build-arg ARG_SECRET_NUGET_PACKAGES=SuaSenhaAqui -t microsservice-create-contact .
docker run -d -p 8080:8080 --env CONNECTION_DATABASE="SuaConnectionString" microsservice-create-contact
```

## Estrutura do Projeto
- `TCFiapProducerCreateContact.API`: Nesta camada recebemos as informações
- `TCFiapProducerCreateContact.Application`: Nesta camada processamos e enviamos as mensagens 
- `Dockerfile`: Configuração para build e publicação

## Testes
- Testes unitários com NUnit




