<template>

    <div class="notes__form">
        <form @submit.prevent="register">
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
        async register(this: any) {
            const userID_cookie = useCookie('userID');
            const userID = userID_cookie.value;
            // if any of the fields are empty, return an error
            if (!this.Title || !this.TitleColor || !this.NoteText || !this.Tag) {
                alert('Please fill in all fields');
                return;
            } else {
                
            const response = await fetch('https://localhost:7114/api/Note', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    Title: this.Title,
                    TitleColor: this.TitleColor,
                    NoteText: this.NoteText,
                    Tag: this.Tag,
                    UserId: userID
                })
            });
            if (response.ok) {
                console.log('Success')
                this.$router.push('/notes');
            } else {
                console.log('Error');
                console.log(await response.json());
            }


        }  
    }

    }
};
</script>

<style scoped>
.notes__form {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    width: 100%;
    margin-top: 2rem;
}

.notes__form__input {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-bottom: 1rem;
}

.notes__form__input label {
    margin-bottom: 0.5rem;
}

.notes__form__input input {
    width: 100%;
    padding: 0.5rem;
    border: 1px solid #ccc;
    border-radius: 0.25rem;
}

.notes__form__input select {
    width: 100%;
    padding: 0.5rem;
    border: 1px solid #ccc;
    border-radius: 0.25rem;
}

.notes__form__input button {
    width: 100%;
    padding: 0.5rem;
    border: 1px solid #ccc;
    border-radius: 0.25rem;
    background-color: #ccc;
    color: #fff;
    font-size: 1rem;
    font-weight: bold;
}

.notes__form__input button:hover {
    background-color: #aaa;
    cursor: pointer;
}


</style>