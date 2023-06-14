<template>
    <div class="notes">
        <div class="notes__title">
            <h1>Notes</h1>
            <NuxtLink class="create" to="/notes/create">Create new note</NuxtLink>
        </div>
        <div class="NotesContent">
             <div class="noteContainer" v-for="note in UserNotes" :key="note.noteID">
                <div class="title"><h2>{{ note.title }}</h2></div>
                <p>{{ note.noteText }}</p>
                <p>{{ note.tag }}</p> 
                <div class="buttons">
                    <NuxtLink class="edit" :to="'/notes/edit/:id' + note.noteID">Edit</NuxtLink>
                    <button class="delete" @click="deleteNote(note)">Delete</button>
                </div>
             </div> 
        </div>
    </div>
</template>

<style scoped>

.notes {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin: 0 auto;
    width: 80%;
}

.notes__title {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: space-between;
    width: 100%;
}

.NotesContent {
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    grid-gap: 1rem;

    width: 100%;
}

.noteContainer {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    width: 300px;
    height: 300px;
    border: 1px solid var(--nord3);
    border-radius: 0.5rem;
    padding: 0.5rem;
    margin: 0.5rem 0;
    box-shadow: 0 0 10px var(--nord3);
}

.noteContainer h2 {
    font-size: 1.5rem;
    font-weight: bold;
}

.noteContainer p {
    font-size: 1rem;
}
.buttons {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: space-between;
    width: 100%;
}

.buttons a {
    width: 100px;
    padding: 0.5rem;
    border: 1px solid var(--nord3);
    border-radius: 0.5rem;
    background-color: var(--nord3);
    color: var(--nord6);
    font-size: 1rem;
    font-weight: bold;
    text-align: center;
    text-decoration: none;
}

.buttons button {
    width: 100px;
    padding: 0.5rem;
    border: 1px solid var(--nord3);
    border-radius: 0.5rem;
    background-color: var(--nord3);
    color: var(--nord6);
    font-size: 1rem;
    font-weight: bold;
    text-align: center;
    text-decoration: none;
    cursor: pointer;
}

.edit:hover {
    background-color: var(--nord10);
}

.delete:hover {
    background-color: var(--nord11);
}

.create {
    width: 150px;
    padding: 0.5rem;
    border: 1px solid var(--nord3);
    border-radius: 0.5rem;
    background-color: var(--nord3);
    color: var(--nord6);
    font-size: 1rem;
    font-weight: bold;
    text-align: center;
    text-decoration: none;
}



.create:hover {
    background-color: var(--nord10);
}


.delete {
    width: 150px;
    padding: 0.5rem;
    border: 1px solid var(--nord3);
    border-radius: 0.5rem;
    background-color: var(--nord3);
    color: var(--nord6);
    font-size: 1rem;
    font-weight: bold;
    text-align: center;
    text-decoration: none;
    cursor: pointer;
}

.title{
    width: 100%;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    border-bottom: 1px solid var(--nord3); 
    border-radius: 15px;
    margin-bottom: 10px;
    box-shadow: 0 0 10px var(--nord3);
}







</style>

<script lang="ts">

export default {
    data() {
        return {
            notes: [],
            UserNotes: [] // declare UserNotes as a property of data
        }
    },
    methods: {
        async deleteNote(note: any) {
            console.log(note)
  await $fetch('https://localhost:7114/api/Note/' + note.noteID, {
    method: 'DELETE'
  });
  this.notes = this.notes.filter((n: any) => n.NoteID !== note.NoteID);
  this.UserNotes = this.UserNotes.filter((n: any) => n.noteID !== note.noteID);
}
    },
    async mounted() {
        const cookie = useCookie('userID')
        const notes = await $fetch('https://localhost:7114/api/Note')
        this.notes = notes as any[] // add type assertion
        const UserNotes = this.notes.filter((note: any) => note.userId === cookie.value)
        this.UserNotes = UserNotes // assign filtered array to UserNotes property

    }
}
</script>