<template>

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


</template>

<style scoped>

.navbar {
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: var(--nord3);
    padding: 0 1rem;
    height: 3rem;
    max-width: 100vw;
}

.navbar__title {
    font-size: 1.5rem;
    font-weight: bold;
}

.navbar__links {
    display: flex;
    justify-content: space-between;
    width: 40%;
    font-size: 1rem;
    font-weight: bold;
    position: relative;
    left: 0;
    transition: left 0.5s ease-in-out;

}

.navbar__links a {
    text-decoration: none;
    color: var(--nord5);
}

.navbar__links a:hover {
    color: var(--nord7);
}

</style>

<script setup lang="ts">

import { NuxtLink } from '~/.nuxt/components';

import { store } from '~/app.vue';

const isUserLoggedIn = store.isUserLoggedIn;
const IsAdmin = store.IsAdmin;


</script>