

---

# BreakevenApi

BreakevenApi is a medical scheduling and record-keeping application.

Developed for the breakeven process of the 2024 internship program at Stone Co, aiming to improve the author's knowledge in C#, Dotnet Core, Entity Framework, Docker, and Unit Testing.

Some tests still need to be implemented, and modifications are likely.

## Running the Application

To run BreakevenApi, Docker is mandatory. 

Simply type:
```sh
docker-compose up -d
```
(`-d` is optional for detached mode)

The Docker engine will create a bundle with 3 images:
* `sqldata-1`: The SQL Server instance used by the API.
* `service-migrations`: Instance responsible for running the database migrations (may be deprecated, needs further investigation).
* `breakevenapi`: The application instance itself, responsible for handling API requests.

## Features

* Manage medical consultations, including creating, finishing, and scheduling appointments.
* Create and manage patient records.
* Generate reports.
* Manage medical schedules for doctors.

## Services

* `ConsultaService`: Manages medical consultations, patient records, and reports.
* `AgendaService`: Manages medical schedules for reports.

## Endpoints

All endpoints are listed in the Swagger documentation, which can be accessed at `https://localhost:5000/swagger/index.html`. Here are the most important ones:

* `/paciente/adds-missing-data`: Used before the consultation starts if the patient is new and missing some data.
* `/consulta/cronograma`: Retrieves a list of all appointments today, with information about all the doctors, patients, and the appointment times.
* `/consulta/finaliza`: Finishes a consultation and registers all the information for the report.
* `/consulta/horariolivre/`: Gets a list of all free time slots for a doctor, by CRM and date.
* `/consulta/agenda-consulta/`: Schedules a new appointment, checking all necessary conditions.

