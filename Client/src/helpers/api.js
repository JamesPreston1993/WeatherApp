
var baseUrl = 'https://localhost:7058';

/**
 * Get timezone details for city from API
 * @param city city to get timezone details for
 * @returns timezone details for given city
 */
export async function getTimeZone(city) {
   const url = `${baseUrl}/weather/timezone?city=${city}`;

   return await sendGetRequest(url);
}

/**
 * Get astronomy details for city from API
 * @param city city to get astronomy details for
 * @returns astronomy details for given city
 */
export async function getAstronomy(city) {
   const url = `${baseUrl}/weather/astronomy?city=${city}`;

   return await sendGetRequest(url);
}

/**
 * Get current weather details for city from API
 * @param city city to get current weather details for
 * @returns current weather details for given city
 */
export async function getCurrentWeather(city) {
   const url = `${baseUrl}/weather/current?city=${city}`;

   return await sendGetRequest(url);
}

async function sendGetRequest(url) {
   try {
      const options = {
         headers: new Headers({
            'content-type': 'application/json'
         }),
         method: 'GET'
      }

      const response = await fetch(url, options);

      return await response.json();

   } catch(error) {
      console.error(`Error calling "${url}": ${error}`);
      return null;
   }
}