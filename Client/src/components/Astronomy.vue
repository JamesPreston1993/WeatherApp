<script setup>
   import WeatherListItem from './WeatherListItem.vue';
</script>

<template>
   <ul class="list-group">
      <WeatherListItem name="Sunrise" :value="astronomy.sunrise" />
      <WeatherListItem name="Sunset" :value="astronomy.sunset" />
      <WeatherListItem name="Moonrise" :value="astronomy.moonrise" />
      <WeatherListItem name="Moonset" :value="astronomy.moonset" />
   </ul>
</template>

<script>
   export default {
      props: {
         astronomy: Object
      }
   }
</script>