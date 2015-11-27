# ASP.NET + Angular.js TodoMvc Sample

This sample is based on the [TODO MVC Angular.js sample](http://todomvc.com/examples/angularjs/#/) and the Visual Studio 2015 single-page application template, but adding:
* An ASP.NET Web API as the backend for the angular app
* Support for multiple users (including Facebook auth)

### How to run the solution
1. Open **TodoApp.sln** using Visual Studio 2013/2015.
2. Press **F5** to run it. Entity Framework will create a new empty database for the app (and an `.mdf` file under the `App_Data` folder).

**Note:** The app was only tested in Chrome.
	
### Frameworks
The solution is using:
* Created with Visual Studio 2015
* ASP.NET MVC + ASP.NET Web API 2
* LocalDB SQL Database for storing users and lists
* Angular.js
* Bootstrap 3
* Font Awesome
* Social Buttons for Bootstrap
	
### Steps to create solution

1. Solution was bootstrapped using the ASP.NET Single Page Application template. 
1. Removed all non-essential auth features (2-factor-auth, account lockout, password recovery, etc.).
1. Web API: Configured Json formatter as default and removed XML formatter.
1. Added Web API as single page app backend.
1. Remove client-side support for localStorage to simplify sample.
1. Added `ng-strict-di` directive and updated code to use inline array annotation.
1. Configured Facebook authentication.
1. Added [Social Buttons for Bootstrap](http://lipis.github.io/bootstrap-social/) for the FB login button.
1. Fixed styles to have both bootstrap and TodoMVC styles present in the app.

See https://github.com/johnpapa/angular-styleguide for Angular style guidelines followed.

### TODO
1. Use Bootstrap consistently.
1. Font awesome is not working when ASP.NET bundling is enabled.
1. Update the login flow to use angular and tokens (not standard MVC views).
1. Autofocus on the textbox after adding a new TODO.
1. Test and fix mobile responsiveness.
1. Test in all browsers.
1. Add unit tests.

