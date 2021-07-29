# Digital Rain Gauge 

## Code Louisville C# Project 

### Basic Requirements Met 
- Over 5 commits
- Readme 
- Additional classes: APIWeatherData, Day (APIWeatherData creates a list of Day which are historical weather data for the past 7 days)
- More than 3 methods with values returned and used

### 3+ Features From List 
1. Connect to an external/3rd party API and read data into your app
    - APIWeatherData.cs has methods to call Visual Crossing's weather data API and deserialize a Json into weather data objects)
2. Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
    - The above deserialized Json creates an <APIWeatherData> object with a list of <Day> objects representing the past 7 days of weather data. Rainfall and temperature values are taken from within and used with the LINQ queries below
3. Use a LINQ query to retrieve information from a data structure (such as a list or array) or file
    - In WaterCalculations.cs the methods IncreaseWaterDemands and TotalRainfall use LINQ to pull from the list APIWeatherData.Days
4. Build a conversion tool that converts user input to another type and displays it
    - Two methods in WaterCalculations.cs - one converts inches to centimeters and another converts °F to °C

### Logic Behind Project
A good starting point for a vegetable garden is 1 inch of water or rainfall per week with an increased demand of about .5 inches for every 10 degree increase above 60 degrees Fahrenheit. It’s also generally always recommended to water deeply and then let the soil dry somewhat (not completely), then water again. Thus, it would be better to water the same amount more often instead of more water once a week in hot weather. I decided that whenever the accumulated water reaches that base need of 1 inch then that’s likely a good time to water.  

### What It Does
- Gets last 7 days of weather data from Visual Crossing’s weather api
- Gets user input to determine days since watering (limits to 7 as days beyond this are not relevant to the app)
- Calculates base water need - 1/7 of an inch per day since watering
- Calculates increased water demand - for each day since watering it uses the previously stated formula (divided by 7 because it’s accumulating daily not weekly) 
- Calculates total rainfall in the days since watering
- Calculates the average temperature of the days since watering
- Displays some of the relevant results above to the user including some unit conversions
- Adds all water needs minus rainfall and determines the user should water if the accumulated water needs reach 1 inch or higher and otherwise suggests the user does not need to water.

### Additional Notes
- Line 26 of APIWeatherData.cs reads my API key from a file that is not uploaded to GitHub but the key will be submitted with the project and will need to replace the existing value of the variable. If anyone outside of Code Louisville is interested, You can obtain your own free key through Visual Crossing (https://www.visualcrossing.com)
- Line 27 of APIWeatherData.cs contains a zip code variable for the user’s location which can be changed if desired. (later I may adjust this with user input)