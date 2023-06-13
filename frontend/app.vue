<template>
  <div>
  <NavBar @isLogged="HandleEvent" />
    <NuxtPage />
  </div>
</template>

<style>
@import "assets\nord.css";

html, body {
  margin: 0;
  padding: 0;
  font-family: sans-serif;
  background-color: var(--nord0);
  color: var(--nord4);
}

</style>

<script lang="ts">


export default {
 methods: {
   HandleEvent(eventData: any) {
      console.log(eventData)
     
   }
 }
}



</script>

