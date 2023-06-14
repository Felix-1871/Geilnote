<template>

    <div class="about">
        <div class="about__title">
            <h1>About</h1>
        </div>
        <div class="about__content">
            <p>Geilnote is a simple application that allows you to create, read, update and delete notes.</p>
            <p>It is built with Vue.js, Node.js, .Net and Microsoft SQL Server.</p>
            <p>It is a project for the course "REST application programming" at the University of Gdańsk.</p>
            
        </div>
    </div>
</template>

<style scoped>

.about {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin: 0 auto;
    width: 80%;
}


.about__content {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    width: 100%;
}



</style>