# Welcome !

Hi, this sample application is developed using ReactJS for frontend and .Net Core 2.0 for WebAPis. 

# Projects 

- ReactJS - This is located under '**Client**' folder.
- .Net Core WebAPI - This is located under '**WebAPI/src**' path.

# Get Started

## Web UI - ReactJS Application
1. **Install Node Packages.**  -  `npm install`
2. **Run the app.** - `npm run start` This will run the automated build process, start up a webserver, and open the application in your default browser.
3. **Troubleshooting** - This application connects with WebAPI and end point is set in file `/Client/src/api/restApi.js` and look for variable `baseUrl`. 

## Web API - .Net Core Application

1. Open Database and create table from DB Script located at - `\WebAPI\src\DataManager\Scripts\CreatePalindromeTable.sql`
2. Load API solution `\WebAPI\src\Web.sln` in Visual Studio 2017
3. Open `appSettings.json` under project `Web.API` and set connection string to Database where SQL Script was run
4. Run Application
