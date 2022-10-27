<script setup>
   import WeatherListItem from './WeatherListItem.vue';
   import { formatSpeed } from '../helpers/formatters';
</script>

<template>
   <ul class="list-group">
      <WeatherListItem name="Wind Speed" :value="formatSpeed(currentWeather.windSpeed)" />
      <WeatherListItem name="Gust Speed" :value="formatSpeed(currentWeather.gustSpeed)" />
      <WeatherListItem name="Direction" :value="currentWeather.windDirection.compassDirection" />
   </ul>
</template>

<script>
   export default {
      props: {
         currentWeather: Object
      }
   }
</script>