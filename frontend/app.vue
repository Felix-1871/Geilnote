<template>
  <div>
    <div class="navbar">
        <div class="navbar__title">
             <h1>Notes</h1>
        </div>
        <div class="navbar__links">
            <NuxtLink to="/">Home</NuxtLink>
            <NuxtLink to="/about">About us</NuxtLink>
            <NuxtLink to="/contact">Contact</NuxtLink>
            <NuxtLink v-if="isUserLoggedIn" to="/notes">My Notes</NuxtLink>
            <NuxtLink v-if="IsAdmin" to="/users">Manage users</NuxtLink>
            <NuxtLink v-if="isUserLoggedIn" to="/logout">Logout</NuxtLink>
            <NuxtLink v-if="!isUserLoggedIn" to="/login">Login</NuxtLink>
            <NuxtLink v-if="!isUserLoggedIn" to="/register">Register</NuxtLink>
        </div>
   </div>

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

a {
  color: var(--nord4);
  text-decoration: none;
}

a:hover {
  color: var(--nord3);
}

.navbar {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
  padding: 1rem;
  background-color: var(--nord0);
  color: var(--nord4);
  border-bottom: 1px solid var(--nord3);
}

.navbar__title {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
  width: 100%;
}

.navbar__title h1 {
  font-size: 1.5rem;
  font-weight: bold;
}

.navbar__links {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
  width: 100%;
}

.navbar__links a {
  padding: 0.5rem;
  color: var(--nord6);
  border-radius: 15px;
  font-size: 1rem;
  font-weight: bold;
  text-align: center;
  text-decoration: none;
}

.navbar__links a:hover {
  background-color: var(--nord4);
  color: var(--nord3);
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

