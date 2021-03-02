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

To Verify the new container created (Ensure the docker container is up and running):

```
docker ps -a
```

To enter into the container

```
docker exec -it postgresql-container bash
```

## Cloning

```
git clone https://github.com/MehriGolchin/CoffeeMaker.git
```

## Running the App

Usually, all you have to do to run the app is starting the project in your IDE. However, if you encounter any issue regarding the node module package resolution, you can install them manually. In this case, go to the `ClientApp` directory in your terminal or Powershell and run the command below:

```
npm install
```

## Creating database

To create and seed your database, you can use EF migration. All you have to do is opening the `CafeeMaker.Web` directory in the terminal or Powershell and running the following command.

```
dotnet ef database update
```

## How to login

The database is seeded by two employees. As mentioned in the assignment, each employee has a badge containing the Employee Id. To login into the system, you can either use Employee Id 100 or 200 as the badge number.