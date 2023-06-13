<template>
    <div class="notes">
        <div class="notes__title">
            <h1>Notes</h1>
            <NuxtLink to="/notes/create">Create note</NuxtLink>
        </div>
        <div class="notes__content">
            <!-- <div class="notes__content__note" v-for="note in UserNotes" :key="note.NoteID">
                <h2>{{ note.title }}</h2>
                <p>{{ note.noteText }}</p>
                <p>{{ note.tag }}</p> -->
            <!-- </div> -->
        </div>
    </div>
</template>

<style scoped>

.notes {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
}

.notes__title {
    font-size: 1.5rem;
    font-weight: bold;
}

.notes__content {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
}

.notes__content__note {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
    border: 1px solid var(--nord3);
    border-radius: 0.5rem;
    padding: 1rem;
    margin: 1rem 0;
}

.notes__content__note h2 {
    font-size: 1.5rem;
    font-weight: bold;
}

.notes__content__note p {
    font-size: 1rem;
}


</style>

<script lang="ts">


export default {
    data() {
        return {
            notes: []
        }
    },
    async mounted(this: any) {
        const cookie = useCookie('userID')
        const notes = await $fetch('https://localhost:7114/api/Note')
        this.notes = notes

        const UserNotes = this.notes.filter((note: any) => note.userID === cookie)
        this.notes = UserNotes
        console.log(this.notes)
    }
}

</script>