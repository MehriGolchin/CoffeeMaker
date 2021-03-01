# CoffeeMaker

## Prerequisite

- .Net 5.0 SDK
- Node LTS
- PostgreSql

## Database configuration

To install PostgreSql using Docker, run the commands bellow:

```
docker pull postgres
```

To launch container:

```
docker run --name postgresql-container -p 5432:5432 -e POSTGRES_PASSWORD=somePassword -d postgres
```

To Verify the new container created(Ensure the docker container is up and running):

```
docker ps -a
```

To enter into the container

```
docker exec -it postgresql-container bash
```

## Install

```
git clone https://github.com/MehriGolchin/CoffeeMaker.git
```

## ClientApp

After opening the project, go to ClientApp folder and run the command bellow:

```
npm run build
```

## Create Migrations

In CafeeMaker.Web project, the following command must be named and run:

```
dotnet ef migrations add <NAME> --project ../CafeeMaker.Infrastructure
```

In the same project, run update to make the database:

```
dotnet ef database update
```

## Seed data to login

Employee Ids are considered to use a badge number. We can use 100 and 200 as the badge numbers in the login page.