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



