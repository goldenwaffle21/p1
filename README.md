# PizzaBox

## Project Description

PizzaBox is a site for ordering pizza online. Choose between multiple stores to order from. Pick a pre-set pizza, or easily create a custom pizza by changing the sauce, crust, size, and toppings (up to 5 of any kind you want); the price is determined by the size and the number of toppings. Easily and intuitively add new pizzas to the order, and control how many of each pizza you're ordering, even the custom ones. Users can also view their previous orders, and can cancel or modify the ones that haven't been delivered yet.
Fake Webcomics are comics published on a website or mobile app. Read comics like you would on a newspaper but instead online! Authors can create new pages, modify/delete old ones, and update the About page for webcomics they own, as well as create new webcomics and delete their old ones. All users can view the comics, navigating either through an Archive page (sorted by number and title) or by using the links on each comic page that will take them to the next page, previous page, first page, last page, and even a random page.

## Technologies Used

Back-End Tech:
* Azure App Service
* Azure SQL
* C#
* .NET Core
* ASP.NET Core
* Docker
* Github
* Entity Framework Core for ORM
* Microsoft SQL Server
* MVC
* xUnit Testing

Front-End Tech:
* HTML, CSS, JS
* ASP.NET MVC

## Features

Currently Implemented:
* Any user can create and place an order, even without signing in.
* Any user can sign in.
* Signed in users can view all their previous orders, and modify or cancel those that haven't been delivered yet.
* Placing an order signs you in if you already have a profile, or creates one for you if you don't.
* The site tracks the current user, automatically filling in their personal information when they order with their name and the address they last used when ordering.

To-do list:
* Tracking the current user is implemented incorrectly, causing the build to fail. Store current user in the Repository, or perhaps create a singleton class for it.

## Getting Started
   
git clone https://github.com/goldenwaffle21/p1
dotnet run ~/p1.PizzaBox.Client/

## Usage

Currently, the build fails due to poor implementation of storing the current user. Should this be fixed, once on the site, usage is fairly self-explanatory. You start on the Order page; you can sign in via the nav-bar or by completing an order. If signed in, you can go to your user home page to view all previous orders and modify or delete those that haven't been delivered yet, or return to the order page.

## Contributors

Elliot Reid

## License

This project uses the following license: [MIT License](<https://opensource.org/licenses/MIT>).
