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
  font-size: 16px;
  font-weight: 400;
  line-height: 1.5;
  text-align: left;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

</style>

<script lang="ts">

import { reactive } from 'vue';

export const store = reactive({
  isUserLoggedIn: false,
  IsAdmin: false,
  login(){
    this.isUserLoggedIn = true
  }
});
</script>

