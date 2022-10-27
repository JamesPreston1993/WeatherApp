<template>
   <li class="list-group-item d-flex justify-content-between align-items-start">
      <div class="ms-2 me-auto">
         <div class="fw-bold">{{name}}</div>
         {{value}}
      </div>
   </li>
</template>

<script>
   export default {
      props: {
         name: String,
         value: String
      }
   }
</script>