# TechChallengeFiapMicrosserviceConsumerUpdateContact

Este microsserviço .NET consome mensagens para atualização de contatos usando MassTransit e RabbitMQ. Ao receber uma mensagem do tipo `UpdateContactMessage`, ele busca o contato no banco de dados e aplica as atualizações.

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
- Variável de ambiente `CONNECTION_DATABASE` com a string de conexão
- Docker instalado (caso utilize container)

## Como Executar

### Localmente
```sh
git clone https://seurepositorio.com/MicrosserviceConsumerUpdateContact.git
cd MicrosserviceConsumerUpdateContact
dotnet restore
dotnet build
dotnet run --project MicrosserviceConsumerUpdateContact.API
```

### Docker
```sh
docker build --build-arg ARG_SECRET_NUGET_PACKAGES=SuaSenhaAqui -t microsservice-update-contact .
docker run -d -p 8080:8080 --env CONNECTION_DATABASE="SuaConnectionString" microsservice-update-contact
```

## Estrutura do Projeto
- `MicrosserviceConsumerUpdateContact.API`: Serviço principal
- `UpdateContactConsumer.cs`: Processa mensagens de atualização
- `Worker.cs`: Gerencia o ciclo de vida do bus
- `Dockerfile`: Configuração para build e publicação

## Testes
- Testes unitários com XUnit

## Configuração
- Fila: `update-contact-queue`
- SDK registrado via `RegisterSdkModule`


