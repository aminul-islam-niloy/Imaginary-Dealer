# Imaginary Dealer

ASP.Net Core and Entity Framework core Project for manage bike and car and sell them.

## Table of Contents

- [Introduction](#introduction)
- [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Contributing](#contributing)
- [License](#license)

## Introduction

Briefly explain what your project is and why it's useful.

## Installation

Provide instructions on how to install and set up your project. Include any prerequisites, steps, or dependencies needed.

```bash
# Example installation command
git clone https://github.com/aminul-islam-niloy/Imaginary-Dealer

install:
 Microsoft.EntityFrameworkCore;
 Microsoft.EntityFrameworkCore.Design;
 Microsoft.EntityFrameworkCore.SqlServer
 Microsoft.EntityFrameworkCore.SqlServer.Tools

Migration:
Add Migration firsttimemigration
Update-database

back to previous migration(if there is only one migration):
update-migration 0

remove-migration

 ```

## work:1

1.Add Class Model,brand and Features in model folder.
2.Create DB Context in Contex folder.
3.Install Entity framework core and SqlServer,tools.
4.Add Connectionstring
5.Setup setvice file with connectionstring in program file 
6.Set DbSet in DB_Contex 
7.Migration database

## work :2

1.Setup  for Annotations;
2.Razer CSHTML 
3.Implement CURD operation for Model and Bike 

## work 3
1.User authentication and authorization
2.Acces to the differnent role of this project

for authintication
1.Add Scaffold and Identity
2.Select DbContext.(Inharite Identity and confiqure for database.
3.Add-migration addIdentity
4.update-database

## For extra Phone added on Authentication

1.Create an Class on Model.Inherite it from IdentityUser.
2.Set Constrains [Not Mapped] on database.
3.add migration
4.update database.
5.Add this new on registration interface
6.Microsoft added Identity on razor pages



## ASP MVC
1. Controller:homeController 
2.--> model:PageClass.cs-->
3.View:Home:ManagePages.cshtml

## Razor Page:
1.Pages:ManagePages.cshtml.cs
setting up user and admin role.

## Bike features 
1.add class with property.
2.Setup db context
3. add migration and update database

note: onDelete: ReferentialAction.Cascade); remove Cascade with NoAction 
so that existing value of  brand and model did not delete.

4. Create Bike View model and Make payment method sysyem for view features
5. Add New BikeController in Controller
6.Add Index page razor view and design like model
1. function will bre continued. 





