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

## Backend Specs
