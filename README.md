# Demo.DWS 

### Steps to install and setup

> Kindly close/download the repository to an empty folder location on the local drive of your computer.

> There are 3 projects in the repository: 
> 
| # | application  |   type  | location | description |
| --- | --- | --- | ---| --- |
| a | Demo.DWS   |    netcore2.1 api | within "Server/Demo.DWS" folder | backend webapi/rest api logic|
| b | UI    |    reactjs app | within "Client" folder |  frontend |
| c | Demo.DWS.Test  |  Test app  | within "Server/Demo.DWS.Test" folder | backend api test application |


> Download/install   	

>	1.	[![.Net Framework](https://img.shields.io/badge/VisualStudio_2017-blue.svg?style=plastic)](https://visualstudio.microsoft.com/) to run backend webapi project
>	1.	[![.Net Framework](https://img.shields.io/badge/DotNet-2.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/2.1) to run backend webapi project
>   
>   2. [![Node](https://img.shields.io/badge/Node-Js-blue.svg?style=plastic)](https://nodejs.org/en/download/) to run the frontend application
>   
>	3. [![VSCode](https://img.shields.io/badge/VS-Code-blue.svg?style=plastic)](https://code.visualstudio.com/) to run the frontend applications

##### (a) To start the backend service
   
>   1. Within **Visual Studio 2017** open a command terminal by pressing the computer keyboard buttons `Control` and `~`
>    
>   2. Within the terminal, browse to folder location named as **"Server/Demo.DWS"** 
>  
>   3. Open the solution file Demo.DWS.sln in **Visual Studio 2017**
>
>   4. Within Visual Studio, Set **Demo.DWS** project as `startup project`, then run the project by hitting **F5** button
>   
>   5. **Server/Demo.DWS** [backend service] shall start running on port **5001**

##### (b) To start the front end application

>   1. Within **Visual Studio Code** Open a new command terminal
>   
>   2. Within the new terminal, browse to the folder named as **"Client"**
>   
>   3. To restore the dependencies, type `npm install` on the terminal
>   
>   4. Now in order to run the front end application, type `npm start` on the command terminal
>   
>   5. Shortly a browser shall open with url as `localhost:3000`

```
For better experience please chrome browser
```

##### (c) To run the unit test project

>   1. Within **Visual Studio 2017**, the test project  **"Demo.DWS.Test"** has tests
>   
>   2. To run the tests, open the `Test Explorer` window and run those discovered tests.


```
keep coding  :)
```
