<script setup>
import { formatDate } from '../helpers/formatters';
import Astronomy from './Astronomy.vue';
import Summary from './Summary.vue';
import Wind from './Wind.vue';
</script>

<template>
   <div class="border card">
      <div class="card-header text-white bg-primary">
         <h1>
            {{ timezone.name }}, {{ timezone.country }}
         </h1>
      </div>
      <div class="card-body">
         <div class="row">
            <div class="col-sm-12 col-lg-6 my-auto">
               <Summary
                  :temperature="currentWeather.temperature"
                  :condition="currentWeather.condition" :localTime="timezone.localTime" />
            </div>
            <div class="col-sm-12 col-lg-3 mb-sm-2">
               <h2>Wind</h2>
               <Wind :currentWeather="currentWeather" />
            </div>
            <div class="col-sm-12 col-lg-3">
               <h2>Astronomy</h2>
               <Astronomy :astronomy="astronomy" />
            </div>
         </div>
      </div>
      <div class="card-footer text-end">
         Last Updated: {{ formatDate(currentWeather.lastUpdatedTime) }}
      </div>
   </div>
</template>

<script>
   export default {
      props: {
         timezone: Object,
         astronomy: Object,
         currentWeather: Object
      }
   }
</script>