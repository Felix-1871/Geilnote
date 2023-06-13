<template>

<div class="logout" @click="logout">
    <h1 class="cookieTERMINATOR" @click="animate">CLICK ME</h1>
    <h1>Thank you for using Geilnote!</h1>
    <h2>See you soon!</h2>
    <NuxtLink to="/" class="link">Back to login</NuxtLink>
    
</div>
   
   
</template>

<script setup lang="ts">

function logout () {
    const userID_cookie = useCookie('userID');
    userID_cookie.value = null;
}

function animate () {
    const cookieTERMINATOR = document.querySelector('.cookieTERMINATOR');
    cookieTERMINATOR.classList.add('animate__animated', 'animate__fadeOutUp');
   
    setTimeout(() => {
         cookieTERMINATOR.innerHTML = 'THANK YOU <3';
         cookieTERMINATOR.style.color = 'red';
        cookieTERMINATOR.classList.remove('animate__animated', 'animate__fadeOutUp');
    }, 1000);
}

</script>

<style scoped>

.logout {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
    height: 100vh;
    justify-content: center;
}

.logout h1 {
    font-size: 2rem;
    font-weight: bold;
}

.logout h2 {
    font-size: 1.5rem;
    font-weight: bold;
}

.cookieTERMINATOR {
    font-size: 1rem;
    font-weight: bold;
    cursor: pointer;
}

.animate__animated {
    animation-duration: 1s;
}

.animate__fadeOutUp {
    animation-name: fadeOutUp;
}

@keyframes fadeOutUp {
    from {
        opacity: 1;
    }
    to {
        opacity: 0;
        transform: translate3d(0, -100%, 0);
    }
}

.link {
    font-size: 1.5rem;
    font-weight: bold;
    margin-top: 1rem;
    text-decoration: none;
    color: var(--nord11);
}

.link:hover {
    color: var(--nord3);
}



</style>