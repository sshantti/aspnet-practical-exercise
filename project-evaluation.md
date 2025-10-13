# To-do List Application

## Project Evaluation

The project is evaluated using both technical evaluation criteria and an assessment of the scope and quality of the implementation of user stories. The evaluation criteria depend on the architectural approach you choose.


### Technical Evaluation Criteria

The technical evaluation criteria are shown in the table below. Some criteria apply differently based on your chosen architecture:

| Evaluation Criteria | Evaluation Grade                                                                                                                                   | Points | Min. Eval.     |
|---------------------|----------------------------------------------------------------------------------------------------------------------------------------------------|--------|----------------|
| C# Projects         | The solution does not contain the required C# projects for the chosen architecture.                                                               | 0      |                |
| C# Projects         | The solution contains only some of the required C# projects for the chosen architecture, or not all required dependencies are established.       | 5      | +              |
| C# Projects         | The solution contains all the required C# projects for the chosen architecture and has established the necessary dependencies.                    | 15     |                |
| Code Analysis       | Built-in .NET code analysis tools and StyleCop are not enabled for C# projects in the solution.                                                    | 0      | +              |
| Code Analysis       | Built-in .NET code analysis tools and StyleCop are enabled for a few C# projects in the solution.                                                  | 5      |                |
| Code Analysis       | Built-in .NET code analysis tools and StyleCop are enabled for all C# projects in the solution.                                                    | 15     |                |
| Code Quality        | There are major or critical code issues found by code analysis tools, or code analysis is not enabled for the C# projects in the solution.         | 0      | +              |
| Code Quality        | There are a few minor code issues found by code analysis tools.                                                                                    | 5      |                |
| Code Quality        | There are no minor, major, or critical issues found by code analysis tools.                                                                        | 15     |                |
| Architecture        | The solution architecture does not comply with the chosen architectural approach (monolithic or 3-tier).                                          | 0      |                |
| Architecture        | The solution architecture partially complies with the chosen architectural approach.                                                               | 5      | +              |
| Architecture        | The solution architecture fully complies with the chosen architectural approach.                                                                   | 15     |                |
| Database            | The application does not use a database for storing user data.                                                                                     | 0      |                |
| Database            | The application uses a database for storing user data.                                                                                             | 10     | +              |
| Database            | The application uses a database for storing user data and authentication data (Identity).                                                          | 15     |                |
| Entity Framework    | The application does not use the Entity Framework to access database data.                                                                         | 0      |                |
| Entity Framework    | The application uses the Entity Framework to access database data.                                                                                 | 15     | +              |
| EF Core Migrations  | The application does not use the EF Core Migrations feature to update the database schema to keep it in sync with the application's data model.    | 0      | +              |
| EF Core Migrations  | The application uses the EF Core Migrations feature to update the database schema to keep it in sync with the application's data model.            | 15     |                |
| REST Endpoints      | **For 3-Tier Architecture Only:** There are no REST endpoints in the application.                                                                 | 0      |                |
| REST Endpoints      | **For 3-Tier Architecture Only:** Most REST application endpoints are poorly designed.                                                            | 5      | +              |
| REST Endpoints      | **For 3-Tier Architecture Only:** The design of a few REST application endpoints has major issues.                                                | 10     |                |
| REST Endpoints      | **For 3-Tier Architecture Only:** Most REST application endpoints are well designed.                                                              | 15     |                |
| Data Validation     | The application does not have data validation that checks the correctness of the input data.                                                       | 0      |                |
| Data Validation     | The application has data validation that checks the correctness of some input data.                                                                | 5      | +              |
| Data Validation     | The application has data validation that checks that all input data is correct.                                                                    | 15     |                |
| Services            | There are no implemented services in the application.                                                                                              | 0      |                |
| Services            | Most service interfaces, data classes, and service implementation classes are poorly designed.                                                     | 10     | +              |
| Services            | The design of a few service interfaces, data classes, and service implementation classes has major issues.                                         | 15     |                |
| Services            | Most service interfaces, data classes, and service implementation classes are well designed.                                                       | 20     |                |
| Web Application     | The web application is not implemented.                                                                                                            | 0      |                |
| Web Application     | The web application is poorly designed and/or poorly implemented.                                                                                  | 10     | +              |
| Web Application     | The web application has a few design or implementation issues.                                                                                     | 15     |                |
| Web Application     | The web application is well designed and implemented.                                                                                              | 20     |                |
| Web API Application | **For 3-Tier Architecture Only:** The web API application is not implemented.                                                                     | 0      |                |
| Web API Application | **For 3-Tier Architecture Only:** The web API application is poorly designed and/or poorly implemented.                                           | 10     | +              |
| Web API Application | **For 3-Tier Architecture Only:** The web API application has a few design or implementation issues.                                              | 15     |                |
| Web API Application | **For 3-Tier Architecture Only:** The web API application is well designed and well implemented.                                                  | 20     |                |
| Web UI              | The application does not have a user interface.                                                                                                    | 0      |                |
| Web UI              | The application has the default ASP.NET Core user interface.                                                                                       | 5      | +              |
| Web UI              | The application has an interface designed by a student.                                                                                            | 10     |                |
| Web UI              | The application has a good-looking interface designed by a student.                                                                                | 20     |                |

**Scoring Notes:**
- **For Monolithic Architecture:** REST Endpoints and Web API Application criteria do not apply. Maximum possible score: 175 points.
- **For 3-Tier Architecture:** All criteria apply. Maximum possible score: 215 points.
- The minimum evaluation score is 80 points for both approaches.


### User Stories Assessment

The scope and quality of implementation of user stories are assessed on five-point scale.

| Epic | User Stories | Poor      | Fair      | Good      | Very Good | Excellent | Min. Eval.     |
|------|--------------|-----------|-----------|-----------|-----------|-----------|----------------|
| EP01 | 4            | 0         | 5         | 10        | 15        | 20        | Good           |
| EP02 | 6            | 0         | 5         | 10        | 15        | 20        | Good           |
| EP03 | 4            | 0         | 5         | 10        | 15        | 20        | Good           |
| EP04 | 2            | 0         | 5         | 10        | 15        | 20        | Fair           |
| EP05 | 5            | 0         | 5         | 10        | 15        | 20        | Fair           |
| EP06 | 4            | 0         | 5         | 10        | 15        | 20        | Fair           |
| EP07 | 5            | 0         | 5         | 10        | 15        | 20        | Poor           |
| EP08 | 1            | 0         | 5         | 10        | 15        | 20        | Good           |

The maximum number of points a student can score on by completing all users stories is 160 points. The minimum evaluation score is 55 points.