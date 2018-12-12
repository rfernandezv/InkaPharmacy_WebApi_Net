# InkaPharmacy REST API

- Tecnología: Net Core 2.1
- Lenguaje: C#

## Librerías

- Dapper
- NHibernate
- AutoMapper

## Otros

- JWT Bearer Token
- Angular 6.0.8

## Patrones

- Chain of Responsibility: POST /api/Products/
- Domain Model Pattern
- Money Pattern
- Value Object Pattern: Money es un Value Object
- Data Transfer Object (DTO) Pattern
- Assembler Pattern
- Notification Pattern
- Unit of Work Pattern
- Repository Pattern
- Database Migrations
- Specification Pattern: para GET /api/Products/{ProductId}
- CQRS: consultas (Q) directas a la base de datos con Dapper para GET /api/Employees

## RabbitMQ Message Broker

- Send messages to RabbitMQ: al crear un Product o Customer, se envía un mensaje a una cola de RabbitMQ usando el método KipubitRabbitMQ.SendMessage(message)
- Process messages from RabbitMQ: el proceso inkapharmacy-receiver genera un archivo PDF y envía en email de notificación usando SendGrid

## Amazon S3

- Consumo de archivos estáticos (imágenes) alojados en Amazon S3, desde la aplicación web Angular

## Amazon RDS

- Base de datos relacional MySQL. Réplica con High Availability zone desactivada debido al costo.

## SendGrid

- Envío de email para notificaciones ante eventos

## Pivotal

- Deployment to Pivotal Cloud Foundry: usando Travis
- Uso de variables de entorno para la cadena de conexión a la base de datos, SendGrid API Key, RabbitMQ URL, Token Secret Key, etc

## Ejemplos de requests

POST /api/Security/Login

```
{
  "Username": "Jhonatan.Tirado1",
  "Password": "P@ssw0rd1"
}
```

POST /api/Products

```
{
    "id": 0,
    "name": "Chiquitolina",
    "price": 1,
    "currency": "PEN",
    "category_id": 1,
    "lot_number": 1,
    "sanitary_registration_number": "a",
    "registration_date": "2018-12-12",
    "expiration_date": "2018-12-27",
    "status": 1,
    "stock_status": 1
}
```

## URLs

Swagger (implementación)

https://dycsw-inkapharmacy-netcore-api-anxious-echidna.cfapps.io/swagger/index.html

REST API:

https://dycsw-inkapharmacy-netcore-api-anxious-echidna.cfapps.io

Aplicación web Angular:

https://inkafarma-web-brave-elephant.cfapps.io/login

SwaggerHub (diseño)

https://app.swaggerhub.com/apis/jhonatan.tirado/InkaPharmacy/1.0.0#/

GitHub RabbitMQ NetCore

https://github.com/jhonatantirado/dotnet-core-rabbitmq/tree/master/InkaPharmacyReceiver

GitHub API Java Spring

https://github.com/jgsistem/InkaPharmacySB

GitHub AngularClient

https://github.com/rfernandezv/inkafarma-web