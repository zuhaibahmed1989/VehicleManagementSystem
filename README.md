# Vehicle Management System
This is a demo project for managing vehicles. 
At this stage it's designed to allow Clients (eg. a UI interface) to pass car data and add it to the system.

## Prerequisites

- .Net Core 5.0
- NetStandard 2.1
- c# 9
- Visual Studio 16.8.0

## Clone Project

- First clone project into a local directory by using following command:

```git clone -b master https://github.com/zuhaibahmed1989/VehicleManagementSystem.git```

##Run in Debug Mode

- After cloning, open up project from solution file, ensure project VehicleManagementSystem is selected as startup project.

- Run project in visual studio debug mode.

- Broswer will open up Swagger UI and you should see one Post Action under Cars (/api/Cars)
 
- Make Http Post call to /api/Cars by copying the following JSON into request body

```
{
  "make": "Honda",
  "model": "Civic",
  "engine": "4 cyl",
  "doors": 5,
  "wheels": 4,
  "bodyType": 2
}
```

- Execute request

### That's it you have successfully added Car to Vehicle Management System.

If you want to check flow of project put a breakpoint on CarsController Post Action and debug step by step.

Happy Coding :+1:
