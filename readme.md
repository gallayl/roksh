# project roksh

## Usage

### Prerequisites

1. Dotnet Core SDK ^3.1
1. MSSQL Server

### Install & Start

1. Clone this repository: `git clone https://github.com/gallayl/roksh.git`
1. _cd_ into the directory `cd roksh`
1. Restore the NuGet Packages with `dotnet restore`
1. Check and update your connection string in `./appsettings.json` (the `ConnectionStrings.DefaultConnection` will be used)
1. (_optional_) Restore a database dump
1. Execute the migration(s) and seed the DB with `dotnet ef database update`
1. Start the app with `dotnet run`
1. The app will be available at https://localhost:5001/

### Basic features and usage

1. Open the main page at https://localhost:5001/
1. Register a new user providing an email, a password and a confirm password
1. Confirm the registration
1. Log in with your credentials
1. You can create a Mock Package from the home screen, providing with its unique `Identifier` and specifying its current Delivery State
1. You can list your packages (they are bound to your user) in the 'My Packages' menu
1. You can view a package details by selecting one from the list or searching one by code from the home screen

## Backend

The Backend service is written in ASP.NET Core, C#, using Entity Framework Code First Workflow.
The following [models](https://github.com/gallayl/roksh/tree/master/Models) are defined:

- ApplicationUser
- DeliveryState
- Item
- Package
  There are also generated [migrations](https://github.com/gallayl/roksh/tree/master/Migrations) to keep the db schema up to date and seed the required entities (~DeliveryStates).
  Authentication is provided by [AspNetCore.Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.1&tabs=visual-studio) without any considerable modifications.
  REST API is using the [OData](https://www.odata.org/) standard, the defined custom entities have endpoints. The metadata is available at https://localhost:5001/odata/$metadata.
  There is a custom [MockDataFetcher](https://github.com/gallayl/roksh/blob/master/Services/MockDataFetcher.cs) - a custom web scraper that collects the required demo items for the packages. It uses [HtmlAgilityPack](https://html-agility-pack.net/).

## UI

The UI is implemented using [Angular](https://angular.io/) and is written in [Typescript](https://www.typescriptlang.org/). The related components and services can be found at [./ClientApp/src/package-tracking](https://github.com/gallayl/roksh/tree/master/ClientApp/src/package-tracking) module.

- **rest-service** is a simple service class for calling the neccessary OData endpoints
- **package-tracking.constants** contains some constants (route definitions)
  The following custom page components are implemented:
- **package-details** for a detailed item list view
- **my-packages for** listing the user's packages
- **create-mock-package** is a form for creating a mock package for the current user
- **components** contains some reusable generic components, like displaying a delivery state, item- and package row components and a custom search bar

Some pages (Login, Profile, etc...) are using the build-in pages provided by the template.
