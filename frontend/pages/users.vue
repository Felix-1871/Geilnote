<template>

    <div class="users">
        <div class="users__title">
            <h1>Users</h1>
        </div>
        <div class="users__content">
            <div class="users__content__user" v-for="user in users" :key="user.UserId">
                <h2>{{ user.username }}</h2>
                <p>{{ user.email }}</p>
            </div>
        </div>
    </div>
   
</template>

<script lang="ts">

export default {
    name: 'users',
    data() {
        return {
            users: []
        }
    },
    async mounted(this: any) {
        const users = await $fetch('https://localhost:7114/api/User')
        this.users = users
    }
}

</script>