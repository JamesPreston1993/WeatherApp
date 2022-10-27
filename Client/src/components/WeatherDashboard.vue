<script setup>
import { getTimeZone, getAstronomy, getCurrentWeather } from '../helpers/api';
import WeatherDetails from './WeatherDetails.vue';
import LoadingSpinner from './LoadingSpinner.vue';
</script>

<template>
  <div class="container">
     <div class="border p-4 my-4">
         <div class="row">
            <div class="col-sm-12 col-lg-4">
               <label class="form-label">Select your city:</label>
               <select class="form-select mb-4" v-model="selectedCity">
                  <option v-for="city in cities" v-bind:value="city">{{city}}</option>
               </select>
               <button class="btn btn-primary" @click="getResultsForCity">
                  Get Weather
               </button>
            </div>
         </div>
         
      </div>
      <WeatherDetails v-if="weatherResults"
         :timezone="weatherResults.timezone"
         :currentWeather="weatherResults.currentWeather"
         :astronomy="weatherResults.astronomy"
      />
      <div class="d-flex justify-content-center">
         <LoadingSpinner v-if="isLoading" />
      </div>
   </div>
</template>

<script>
   export default {
    data() {
        return {
            selectedCity: null,
            cities: [
                "Dublin",
                "Barcelona",
                "New York"
            ],
            weatherResults: null,
            isLoading: false
        };
    },
    mounted() {
        this.selectedCity = this.cities[0];
    },
    methods: {
        async getResultsForCity() {
            // clear existing results and display loading spinner
            this.weatherResults = null;
            this.isLoading = true;

            // populate weather results from API
            this.weatherResults = {
                timezone: await getTimeZone(this.selectedCity),
                astronomy: await getAstronomy(this.selectedCity),
                currentWeather: await getCurrentWeather(this.selectedCity)
            };
            
            // hide loading spinner
            this.isLoading = false;
        }
    }
}
</script>


<style scoped>

</style>

