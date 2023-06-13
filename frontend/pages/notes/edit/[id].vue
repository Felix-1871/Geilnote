<template>

    <div class="noteEdit">
        <form @submit.prevent="update">
            <div class="notes__form__input">
                <label for="Title">Title</label>
                <input type="text" id="Title" name="Title" v-model="Title" />
            </div>
            <div class="notes__form__input">
                <label for="TitleColor">TitleColor</label>
                <select id="TitleColor" name="TitleColor" v-model="TitleColor">
                    <option v-for="colour in colours" :value="colour.value">{{ colour.label }}</option>
                </select>
            </div>
            <div class="notes__form__input">
                <label for="NoteText">NoteText</label>
                <input type="text" id="NoteText" name="NoteText" v-model="NoteText" />
            </div>
            <div class="notes__form__input">
                <label for="Tag">Tags</label>
                <input type="text" id="Tag" name="Tag" v-model="Tag" />
            </div>
            <div class="notes__form__input">
                <button type="submit">Create</button>
            </div>
        </form>
    </div>
</template>

<script lang="ts">


export default {
    data() {
        return {
            Title: '',
            TitleColor: '',
            NoteText: '',
            Tag: '',
            UserId : '',
            colours: [
                { label: 'Red', value: 'red' },
                { label: 'Blue', value: 'blue' },
                { label: 'Green', value: 'green' },
                { label: 'Yellow', value: 'yellow' },
                { label: 'Purple', value: 'purple' },
                { label: 'Orange', value: 'orange' },
                { label: 'Pink', value: 'pink' },
                { label: 'Grey', value: 'grey' },
                { label: 'Black', value: 'black' },
                { label: 'White', value: 'white' },
            ]
        }
    },
    methods: {
        async update() {
            const note = {
                Title: this.Title,
                TitleColor: this.TitleColor,
                NoteText: this.NoteText,
                Tag: this.Tag,
                UserId : this.UserId
            }
            let id = this.$route.params.id
       id = id.slice(3)

            await $fetch('https://localhost:7114/api/Note/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(note)
            })
            
            this.$router.push('/notes')
        }
    },
    async mounted() {


        let id = this.$route.params.id
       id = id.slice(3)

        

        const note = await $fetch('https://localhost:7114/api/Note/' + id)
        this.Title = note.Title
        this.TitleColor = note.TitleColor
        this.NoteText = note.NoteText
        this.Tag = note.Tag
        this.UserId = note.UserId
    }
}


</script>