<template>

    <div class="register">
        <div class="register__title">
            <h1>Register</h1>
        </div>
        <div class="register__form">
            <form @submit.prevent="register">
                <div class="register__form__input">
                    <label for="username">Username</label>
                    <input type="text" id="username" v-model="username" />
                </div>
                <div class="register__form__input">
                    <label for="password">Password</label>
                    <input type="password" id="password" v-model="password" />
                </div>
                <div class="register__form__input">
                    <label for="confirmPassword">Confirm Password</label>
                    <input type="password" id="confirmPassword" v-model="confirmPassword" />
                </div>
                <div class="register__form__input">
                    <label for="email">Email</label>
                    <input type="email" id="email" v-model="email" />
                </div>
                <div class="register__form__input">
                    <label for="isAdmin">Admin</label>
                    <input type="checkbox" id="isAdmin" v-model="isAdmin" />
                </div>
                <div class="register__form__input">
                    <button type="submit" @click="isLogged">Register</button>
                </div>
            </form>
        </div>
    </div>

</template>

<style scoped>

.register {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
}

.register__title {
    font-size: 1.5rem;
    font-weight: bold;
}

.register__form {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
}

.register__form__input {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
    margin: 1rem 0;
}

.register__form__input label {
    font-size: 1rem;
}

.register__form__input input {
    width: 100%;
    padding: 0.5rem;
    border: 1px solid var(--nord3);
    border-radius: 0.5rem;
}

.register__form__input button {
    width: 100%;
    padding: 0.5rem;
    border: 1px solid var(--nord3);
    border-radius: 0.5rem;
    background-color: var(--nord3);
    color: var(--nord6);
    font-size: 1rem;
    font-weight: bold;
}

.register__form__input button:hover {
    background-color: var(--nord4);
}



</style>

<script lang="ts">

export default defineComponent({
    name: 'Register',
    data() {
        return {
            username: '',
            password: '',
            confirmPassword: '',
            email: '',
            isAdmin: false
        }
    },
    methods: {
        async register(this: any) {
            const response = await fetch('https://localhost:7114/api/User', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    username: this.username,
                    email: this.email,
                    password: this.password,
                    isAdmin: this.isAdmin
                })
            });
            if (response.ok) {
                console.log('Success')
                const userID_cookie = useCookie('userID');
                const userIsAdmin_cookie = useCookie('userIsAdmin');
                userIsAdmin_cookie.value = this.isAdmin;
                userID_cookie.value = (await response.json());
                this.$router.push('/notes');

                
            } else {
                console.log('Error');
                console.log(await response.json());
}
        },
        isLogged(this: any) {
           this.$emit('isLogged', true);
        }
    }
});
</script>