<template>
    <div class="login">
        <div class="login__title">
            <h1>Login</h1>
        </div>
        <div class="login__form">
            <form @submit.prevent="login">
                <div class="login__form__input">
                    <label for="username">Username</label>
                    <input type="text" id="username" name="username" />
                </div>
                <div class="login__form__input">
                    <label for="password">Password</label>
                    <input type="password" id="password" name="password" />
                </div>
                <div class="login__form__input">
                    <button type="submit" @click="store.login()">Login</button>
                </div>
            </form>
        </div>
    </div>
</template>

<script setup lang="ts">

import { store } from '~/app.vue';
    
    
   async function login() {
            const user: { username: string; password: string; UserId: string } = await $fetch(
                "https://localhost:7114/api/User"
            );
            const usernameInput = document.getElementById(
                "username"
            ) as HTMLInputElement;
            const passwordInput = document.getElementById(
                "password"
            ) as HTMLInputElement;

            if (usernameInput && passwordInput) {
                const username = usernameInput.value;
                const password = passwordInput.value;
                for (let i = 0; i < user.length; i++) {
                    if (user[i].username === username && user[i].password === password) {
                       const userID_cookie = useCookie('userID');
                        userID_cookie.value = user[i].userId;
                        this.$router.push("/notes");
                        
 


                    } else {
                     console.log("Wrong username or password");   
                    }
                }
            }
        }
   

</script>

<style scoped>

.login {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    height: 100vh;
}

.login__title {
    margin-bottom: 2rem;
}

.login__form {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.login__form__input {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-bottom: 1rem;
}

.login__form__input label {
    margin-bottom: 0.5rem;
}

.login__form__input input {
    width: 20rem;
    height: 2rem;
    border: 1px solid var(--nord3);
    border-radius: 0.5rem;
    padding: 0.5rem;
}

.login__form__input button {
    width: 20rem;
    height: 2rem;
    border: 1px solid var(--nord3);
    border-radius: 0.5rem;
    padding: 0.5rem;
    background-color: var(--nord3);
    color: var(--nord6);
    font-weight: bold;
}

.login__form__input button:hover {
    background-color: var(--nord4);
}




</style>