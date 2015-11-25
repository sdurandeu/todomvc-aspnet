# ASP.NET + Angular.js TODO Sample
This sample is based on the TODO MVC Angular.js Sample http://todomvc.com/examples/angularjs/#/ and adds authentication support.

## Frameworks
The solution is using:
* ASP.NET MVC + ASP.NET Web API 2
* LocalDB SQL Database for storing users and lists
* Angular.js
* Bootstrap 3
* Created with Visual Studio 2015

## How to run the solution
1. Open TodoApp.sln using Visual Studio 2013/2015.
2. Press **F5** to run it, Entity Framework will create a new empty database for the app.

## Steps to create solution

1. Solution was bootstrapped using the ASP.NET Single Page Application template. 
1. Removed all non-essential auth features (2-factor-auth, account lockout, password recovery).
1. Web API: Configured Json formatter as default and removed XML formatter.
1. Added Web API as SPA backend.
1. Remove support for localStorage to simplify sample.
1. Added 'ng-strict-di' directive and updated code to use inline array annotation.

See https://github.com/johnpapa/angular-styleguide for Style Guidelines.

