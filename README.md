# Account payables payment processing

# Technical evaluation

## Functional Requirements 

A team in Plooto is building a payment processing system for account payables. They will need to create account payables payment(s), allowing users to:

* Select one or more vendor/supplier bills to pay from a list (this can be a static list)
* Create payment(s) with the following information:
  * Amount
  * Debit date
  * Payment method (e.g., Bank transfer, Email transfer, Credit card)
* Save the payment information
* Once payment(s) have been created, allow users to mark the selected bills as paid.
* View a list of paid bills (including payment information where applicable)

## Software Design Task

Describe the process of how you would engage with the team and associated stakeholders to help design this solution, including:
 
* The overall system design of the backend services & components you would recommend building, and the interfaces / contracts between them, and the consumers of the services.
* How you would resolve conflicting designs or technology choices
* How you would relate the solution design back to the business needs to ensure it is neither over nor under engineered, and fit for purpose
* How you would test the solution.

---

# Preparation 

See [there](./Preparation.md#preparation)

# Planning and Design

See [there](./Preparation.md#product-design-presentation-to-stakeholders)

# Software Design Tasks

## The overall system design

> The overall system design of the backend services & components you would recommend building, and the interfaces / contracts between them, and the consumers of the services.

* Due the lack of requirement I assume the application must run on Linux environment (on prem or within container) and be designed as APU utilizing MS technology stack.
* The application should be designed as API first and be ready to migrate to Azure with minimal changes
* Overall design must follow design principles listed below (not ordered):
  * Single responsibility
  * Separation of concerns
  * Persistence ignorance
  * Bounded contexts
  * CQRS

### Workflow

* End user requests all invoices (Call to `invoice` API)
* End user selected one or many invoices to be paid
* End user submitted list of selected for payment invoices (Call to `payment` API)
* End user received the list of paid invoices and asked to confirm (mark as `paid`)
* End user submits list of invoices marked as `paid` to change status (Call to `invoice` API)

### Dataflow
* From data point of view I can separate 3 domain:
  * Vendor
  * Invoice
  * Payment

### API First design

__Requirements__:
* All method must be secured with API key authentication
* API project must support OpenAPI standard using swagger.
* All API methods must accept and respond with JSON
* All API methods must be attributed according to OpenAPI spec
* All API methods should validate input parameters (if any) and return 404
* All routes for all domain must be prefixes with `/api/`

__Assumptions and definitions__:

* Security
  * Custom middleware for API key authentication is not a part of current project and will not be described here.
  * API key should be stored in `AppSettings.development.json` for local (dev) execution
  * API key should be provided as Environment Variable for Windows and Linux.
  * API key should be provided as Environment Variable for Docker.
  * Role based security is not part of current implementation. Can be implemented on UI or API gateway or additional orchestrator service.
  * API is not public facing and utilizes HTTP protocol only, in case to make it public:
    * Add SSL to API gateway or another similar service (depends on hosting)
    * Add JWT support for role based authorization

* Others
  * This project is not designed and not implemented pagination, filtering or sorting on backend.
  
* We assume API is set of 3 services as per domain definition (see above):

For simplification all 3 services will implemented as 3 API controllers under the same application with ability to run as Docker container or standalone under Windows or Linux OS.
* Vendor
* Invoice
* Payment

This will simplify migration to Azure or another cloud.<BR>
In case of cloud migration there are couple of options:
* Use every services as is or with minimal changes on K8S
* Convert to Azure Function (AWS Lambda)
* Use as standalone container running under ACI (AWS Fargate)

Any controller can be separated from others with minimal changes:
* Copy project to a new location 
* Remove other controllers and DI settings (from `Program.cs`)
* Modify `api keys` settings as required
* Add `HttpClient` to `builder.Services` (from `Program.cs`) to communicate with others

* API must support a minimal security requirement (defined below).

__Vendor__

Methods to implement:

  * __Get__ `/api/vendor/` - returns list of all vendors, but not payment info
  * __Get__ `/api/vendor/` with JSON payload  - returns list of all vendors, but not payment info
    * JSON payload:
    ```json
    {
      "active": true // Returns only active vendors if `true` or all vendors otherwise
    }
    ```
  * __Get__ `/api/vendor/:id` - returns one vendor selected by `id` or 404; where `id` is integer.

__Invoice__

Methods to implement:
  * __Get__ `/api/invoice/` - returns list of all invoices
  * __Get__ `/api/invoice/` with JSON payload  - returns list of all vendors, but not payment info
    * JSON payload:
      ```json
      {
        "status": 1, // Returns only paid invoices
        "validate": true, // Perform invoice validation
        "invoices": [] // comma separated list of invoices to return 
      }
      ```
      Where <br>
        `status=0` means all invoices but errored, <br>
        `status=1` means not paid and not errored, <br>
        `status=3` means paid, <br>
        `status=4` means invoice cannot be processed/errored<br>
      Where `invoices` is not empty, method should return only invoices listed with status defined above
      Where `"validate": true` preform validation and add validation status to result 

  * __Get__ `/api/invoice/:id` - returns one invoice selected by `id` or 404; where `id` is integer.
  * __PATCH__ `/api/invoice/` with JSON payload - returns OK along with list.
    * JSON payload:
    ```json
    {
      "invoices": [] // list of invoices to change status to `paid`
    }
    ```

__Payment__

Methods to implement:
  * __Get__ `/api/payment/` - returns list of all payments
  * __Get__ `/api/payment/` with JSON payload  - returns list of all payments
    * JSON payload:
      ```json
      {
        "status": 1, // Returns only paid invoices
        "from": startDate,
        "to": endDate,
      }
      ```
      Where <br>
        `status=0` means all invoices<br>
        `status=1` means not paid and not errored, <br>
        `status=3` means paid, <br>
        `status=4` means invoice cannot be processed/errored<br>
      When `from` specified - return invoices with payment date is equal or greater than `startDate`<br>
      When `to` specified - return invoices with payment date is less or equal than `endDate`
  * __Post__ `/api/payment/` with JSON payload - returns OK and list of paid invoices.
    * JSON payload:
    ```json
    {
      "invoices": [] // list of invoices to execute payment
    }
    ```

## Conflicting designs or technology choices
> How you would resolve conflicting designs or technology choices

As on every one project there are a lot of options and conflicts.<br>
Majority of them will be resolved during the [preparation phase](./Preparation.md). However, some of them will exist even after:
* Cost related
* Feature related
* Resource related
* Others

There is only one way to figure out the balance and it's evaluate pros and cons, gather stakeholder input, and make an informed decision.

## Business fulfillment
> How you would relate the solution design back to the business needs to ensure it is neither over nor under engineered, and fit for purpose.

On design stage:
* Define business objectives
* Consider the failure risks you need to mitigate.
* Document service level agreements (SLAs) and service level objectives (SLOs)
* Model applications for your business domain
* Decompose workloads (not in this project)
* Plan for growth
* Manage costs

There are not to many strategies to ensure business retirements met.<br>
From my experience following steps will help:
- Ensure implementation is in sync with functional and nonfunctional requirements during the whole SDLC
- Regular code reviews (on every PR) with rotating team members as optional reviewers
- Ensure the teams are following common design principals, patterns and best practices (usually handled by project manager, team leads and architect):
  - SOILD 
    - Single Responsibility Principle (SRP)
    - Open/Closed Principle (OCP)
    - Liscov Substitution Principle (LSP)
    - Interface Segregation Principle (ISP)
    - Dependency Inversion Principle (DIP)
  - DRY (Don’t Repeat Yourself)
  - KISS (Keep it simple, Stupid!)
  - YAGNI (You ain't gonna need it)
- Ensure the teams are implementing project utilizing common design patterns

Relating the solution design to business needs involves constant communication and alignment between technical teams and business stakeholders. Regularly assess and prioritize requirements, consider scalability, cost-effectiveness, and performance, and ensure that the design aligns with the overarching business goals and objectives. Regular feedback loops and agile practices can help maintain the right balance between engineering rigor and practicality.

## Testing
> How you would test the solution.

_Current implementation has no UI. This fact will limit testing to:_

* Unit tests (must be implemented by dev team) - local and CI/CD pipeline
  * functional
  * integration
  * moc (if required)
* Functional UAT tests
  * using Postman (originally implemented by dev team, updated/modified by qa team)
  * using Swagger UI (built in)
  * using HttpRepl (https://learn.microsoft.com/en-us/aspnet/core/web-api/http-repl/?view=aspnetcore-6.0&tabs=windows)
* Load and stress tests
  * Using third-party web performance tools (Load and stress tests should be done in __release__ and __production__ mode and not in debug and development mode.)
  * Using Azure Load Testing (in case of Azure hosting)

__Testing services under load balancers is not a part of current exercise.__