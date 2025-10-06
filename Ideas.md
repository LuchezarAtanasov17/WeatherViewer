# Ideas for future improvements

## 1. Backend extensions
    - Add caching layer to store recent weather responses and reduce the number of requests;
    - Add weather forecast endpoint (for example: GET /forecast?lat={lat}&lon={lon}) returning information about min and max temperature, description, icon, humidity, windspeed, precipitation chance, date, day of the week;
    - Localization of responses (returning the weather details according to the user's preffered language);
    - Add structured logging for better monitoring of requests and errors;
    - Add unit and integration tests.

---

## 2. Backend extensions
    - Add weather forecast table to display the multi-day forecast from API;
    - Add search bar for finding weather data by city name or specific coordinates;
    - Improve UI for better user experience (optional: add light/dark theme, animations, icons);
    - Make the layout responsive.