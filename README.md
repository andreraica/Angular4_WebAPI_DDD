# AndreRaica Simple Memory Register

This simple angular interface with .Net WebAPI is an example how insert a name and document using Rest, Angular and JWT

### Requeriments

* [Visual Studio] - Microsoft Visual Studio!
* [.NET Framework 4.6] - Microsoft .NET Framework 4.6
* Node / NPM / AngularCli 6

### Run Steps

#### >>> Visual Studio Solution - WebAPI
1) Open solution file [UserRegisterApp.sln] in your Visual Studio
2) Set the project [1-Services/AndreRaicaRegister.Services.WebAPI] as StartUp Project
3) Press play button (This action should restore the Nuget Packages)

#### >>> Prompt - Angular 6
1) Open your favorite prompt
2) Open the folder [...\Angular4_WebAPI_DDD\AndreRaicaRegister.Presentation.Angular4]
3) execute:
```sh
npm install
ng serve
````

### How to use
**After execute the Run Steps**
1) Open your browser http://localost:4200
2) Input admin/admin at login
3) Input participant information and click Add

### Documentation

You can use the [PostMan] to invoke all WebAPIs. https://www.getpostman.com/
There is a folder in root named [Documents/WepAPI], in there you can get the file [UserRegister.postman_collection.json] and import in your local postman

**this project uses JWT token, so this [PostMan] contains all enviroments variables to help you :) **

# About Project!

### Data API

> Every data are using 'Application' memory to emulate the database making this project simpler.

### Basic Tech

**This project is using base SOLID concepts**

* User Input: Angular 6 Application
* Project Tiers: Class Library

**Tiers:**
>Domain 
* Model & Services: Domain is a global tier used by all tiers providing the main entities and services

>Application
* this layer orchestrate the services invokes between API and Service

>Infrastructure
* Data: This tier consumes the WebAPI. It has your own model to manipulate the JSON and response to Services 
* IoC: This tier just Inject all dependencies (DI) - using package SimpleInjector


### Next Steps Todo

 - Improve layout and Angular features
 - Refactor code
 - Full translate to English

License
----

**Free by Andre Raiça Silva**