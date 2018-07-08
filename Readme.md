# Welcome !

Hi, this sample application is developed using ReactJS/Redux/ES6/Webpack for frontend and .Net Core 2.0 for WebAPi. 

# Projects 

- ReactJS - This is located under '**Client**' folder.
- .Net Core WebAPI - This is located under '**WebAPI/src**' path.

# Get Started

## Web UI - ReactJS Application
1. **Install Node Packages.**  -  `npm install`
2. **Run the app.** - `npm run start` This will run the automated build process, start up a webserver, and open the application in your default browser.
3. When user checks for palindrome it returns result. If success then record is inserted in DB and plaindrome list is refreshed.
3. **Troubleshooting** - This application connects with WebAPI and end point is set in file `/Client/src/api/restApi.js` and look for variable `baseUrl`. 

## Web API - .Net Core Application

1. Load API solution `\WebAPI\src\Web.sln` in Visual Studio 2017
2. This solutions is connecting to local DB and .MDF is located in App_Data folder.
3. Run Application and this will open up on port:43628
