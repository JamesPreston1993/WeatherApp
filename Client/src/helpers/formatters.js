/**
 * Format a date string to locale time
 * @param date date string
 * @returns date in locale time format
 */
export function formatDate(date) {
   return new Date(date).toLocaleString();
}

/**
 * Format a temperature object into a string containing celsius and fahrenheit
 * @param temperature temperature object containing celsius and fahrenheit results
 * @returns string in format of "{celsius}°C / {fahrenheit}°F"
 */
export function formatTemperature(temperature) {
   return `${temperature.celsius}°C / ${temperature.fahrenheit}°F`
}

/**
 * Format a speed object into a string containing kmh and mph
 * @param speed speed object containing kmh and mph
 * @returns string in format of "{kmh}kmh / {mph}mph"
 */
export function formatSpeed(speed) {
   return `${speed.kilometresPerHour}kph / ${speed.milesPerHour}mph`
}