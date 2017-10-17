# BangazonAPI

This is an API that allows users to create and access a database of various assets of a company, including: Employees, Customers, Products etc.

## Getting Started

For this project you will need to install the following:

### .NET Core

## Windows

https://www.microsoft.com/net/core#windows

  1. Click the link to download the .NET Core SDK for Windows (https://go.microsoft.com/fwlink/?LinkID=827524)
  2. Once installed open a command line app to intialize some code.
  3. Make a directory for your app: mkdir HelloWorld
  4. Move to the newly created directory. : cd 
  HelloWorld
  5. Create a new app: dotnet new
  5. Build the app and restore any get any missing libraries (packages) : dotnet restore
  6. Run the app: dotnet run
  7. You should see the test "Hello World".
  8. Navigate to the folder where the app was created and https://docs.asp.net/en/latest/getting-started.html

## OSX

https://www.microsoft.com/net/core#macos

Create and run an ASP.NET application using .NET Core

https://docs.asp.net/en/latest/getting-started.html

### Text Editor

For a developer environment, you will also need an up-to-date version of Microsoft's Visual Studio or [Visual Studio Code](https://code.visualstudio.com/download) for Mac OS.

### SQLite  

## OSX Users

```
brew install sqlite
```

## For Windows Users

Visit the [SQLite downloads](https://www.sqlite.org/download.html) and download the 64-bit DLL (x64) for SQLite version, unzip and install it.

### SQL Browser

[DB browser for SQLite](http://sqlitebrowser.org/) 

###  Postman

We also recommend [Postman](https://www.getpostman.com/) for working with our API.

### Installing

After you have the appropriate tools installed you will can clone the repo to your local system and follow the below steps:

```
dotnet restore
dotnet ef migrations add initial
dotnet ef migrations database update
dotnet run
```

### Once API is running

The database will have the below tables available to add.  Tables with dependent tables listed will need to have instances of their dependent tables created before you can create an instance of them.

For a visual representation of our database structure and relationships, please open the Bangazon.xml file in the root directory of this project.

* Customer
* Product Type
* Product       -Must have a product Type
* Order         -Must have a customer and a payment type
* Payment Type  -Must have a customer
* Computer 
* Department 
* Employee      -Must have a department 
* Training Program 
