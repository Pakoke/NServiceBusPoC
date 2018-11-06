# NServiceBusPoC


## Getting Started

To build the project, you will need this programs before build the solution itself. we build the solution itself in one big solution, to see every moment all the code without loading more that one project.
You always have to open visual studio as administrator.

### Prerequisites

1. Windows 10: you need to have installed Windows 10 to run the other software without a problem. if you are not able to install windows 10, you can install windows 7 but I cannot assure you the compatibilities with other softwares.

2. Visual Studio 2017 Comunity edition: you can find the sofware here.  [link](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=15).The component that you need to install are:
    1. Development platform universal windows
    2. Development desktop .Net
    3. Development ASP.Net and web

3. Visual studio Productivity Tools extension, you can find that software here:[visual studio extension](https://marketplace.visualstudio.com/items?itemName=VisualStudioProductTeam.ProductivityPowerPack2017)

4. Net Core sdk 2.1: 
    1. x86: [dotnet x86](https://www.microsoft.com/net/download/thank-you/dotnet-sdk-2.1.300-windows-x86-installer).
    2. x64: [dotnet x64](https://www.microsoft.com/net/download/thank-you/dotnet-sdk-2.1.300-windows-x64-installer).
    To check that the sdk is installed go to powershell and write ```` dotnet --info ````
    At least, you will need a superior version than 2.1.*.
    
5. Docker for windows: you can get docker from this [link](https://store.docker.com/editions/community/docker-ce-desktop-windows?tab=resources)(before register into the web page)
    To check that docker is installed goes to powershell and write ```` docker -v ````, you will see the version installed.
    We are going to use docker-compose to build our mysql database. To check that you have installed docker compose write on powershell ```` docker-compose -v ````
    To run this project, I recomend you to install this, because we will install mysql database locally with this framework.
    When you installed docker, uncheck the option "Windows container instead of Linux containers"

6. Node.js and npm: you can get this software from this [link](https://www.npmjs.com/get-npm). You have select the latest stable version(LTS), for example 8.11.3.
    To check that you install node.js, go to powershell and write ```` node -v ```` and ```` npm -v ````.
    
7. Web essentials extension for Visual Studio 2017: [link](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.WebExtensionPack2017)

8. Install Powershell project, to open a powershell project on visual studio 2017. On this project,we are going to gather all the mysql script that build our mysql database.
    (powershell extension)[https://github.com/adamdriscoll/poshtools/wiki/Installing-PowerShell-Tools-in-Visual-Studio-2017]

9. To test that our mysql database is deploy successfully, we need to install [mysql workbench](https://www.mysql.com/products/workbench/). 
    With this Software we are going to query,update, execute and managed our mysql database.

10. Plantuml Languaje Service, with this extension we are going to be able to open and render uml based on code.[PlantUmlLanguageService](https://marketplace.visualstudio.com/items?itemName=KieranBorsden.PlantUmlLanguageService)
    To create the entire structure and organization of the entities and database related with the project NServiceBusPoC, we are going to use this to tool to code the entire structure of the project.

With all this installed, you are going to be able to build the project without any kind of problem.

## Authors

* **Francisco Javier Ruiz** - [Pakoke](https://github.com/Pakoke)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
