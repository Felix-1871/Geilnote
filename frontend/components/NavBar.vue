<template>

   <div class="navbar">
        <div class="navbar__title">
             <h1>Notes</h1>
        </div>
        <div class="navbar__links">
            <NuxtLink to="/">Home</NuxtLink>
            <NuxtLink to="/about">About us</NuxtLink>
            <NuxtLink to="/contact">Contact</NuxtLink>
            <NuxtLink v-if="isLogged" to="/notes">My Notes</NuxtLink>
            <NuxtLink v-if="IsAdmin=true" to="/users">Manage users</NuxtLink>
            <NuxtLink v-if="isLogged" to="/logout">Logout</NuxtLink>
            <NuxtLink v-if="!isLogged" to="/login">Login</NuxtLink>
            <NuxtLink v-if="!isLogged" to="/register">Register</NuxtLink>
            

        </div>
   </div>


</template>

<style scoped>

.navbar {
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: var(--nord7);
    padding: 0 1rem;
    height: 3rem;
    width: 100%;
}

.navbar__title {
    font-size: 1.5rem;
    font-weight: bold;
}

.navbar__links {
    display: flex;
    justify-content: space-between;
    width: 30%;
}

.navbar__links a {
    text-decoration: none;
    color: #000;
}

.navbar__links a:hover {
    color: #666;
}

</style>

<script lang="ts">

import { NuxtLink } from '~/.nuxt/components';
export default {
    data() {
        return {
            isLogged: false,
            IsAdmin: false

        }
    }
}
</script>