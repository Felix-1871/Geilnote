<template>

    <div class="notes__form">
        <form>
            <div class="notes__form__input">
                <label for="Title">Title</label>
                <input type="text" id="Title" name="Title" v-model="Title" />
            </div>
            <div class="notes__form__input">
                <label for="TitleColor">TitleColor</label>
                <input type="text" id="TitleColor" name="TitleColor" v-model="TitleColor" />
            </div>
            <div class="notes__form__input">
                <label for="NoteText">NoteText</label>
                <input type="text" id="NoteText" name="NoteText" v-model="NoteText" />
            </div>
            <div class="notes__form__input">
                <label for="Tag">Tag</label>
                <input type="text" id="Tag" name="Tag" v-model="Tag" />
            </div>
            <div class="notes__form__input">
                <button type="submit" @click="register">Create</button>
            </div>
        </form>
        
       
    </div>


</template>

<script lang="ts">

export default defineComponent({
    name: 'CreateNote',
    data() {
        return {
            Title: '',
            TitleColor: '',
            NoteText: '',
            Tag: '',
            UserId : ''
        }
    },
    methods: {
        async register(this: any) {
            const userID_cookie = document.cookie.split('; ').find(row => row.startsWith('userID='));
            const userID = userID_cookie ? userID_cookie.split('=')[1] : '';
            const response = await fetch('https://localhost:7114/api/Note', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    Title: this.Title,
                    TitleColor: this.TitleColor,
                    NoteText: this.NoteText,
                    Tag: this.Tag,
                    UserId: userID_cookie
                })
            });
            const responseBody = await response.text(); // log the response body
console.log(responseBody);
const data = JSON.parse(responseBody); // parse the response body as JSON
console.log(data);
            if (response.ok) {
                console.log('Success')
                this.$router.push('/notes')
            } else {
                console.log('Failure')
            }


        }
    }
});
</script>