<script setup>
   import { formatDate, formatTemperature } from '../helpers/formatters';
</script>

<template>
   <div class="text-center">
      <p class="lead">{{formatDate(localTime)}}</p>
      <p class="display-3">{{formatTemperature(temperature)}}</p>
      <p class="h2">{{condition}}</p>
   </div>
</template>

<script>
   export default {
      props: {
         condition: String,
         localTime: String,
         temperature: Object
      }
   }
</script>