<template>
  <div class="d-flex flex-column justify-content-center">
    <h1>Track-It</h1>
    <img class="my-4 align-self-center" src="../assets/trackitlogo.png" style="height: 16rem; width:16rem;"/>
    <p>An all in one solution for all your tracking needs!</p>
    <router-link :to="{ name: 'Map' }">Go to the map</router-link>
  </div>
</template>

<script>

export default {
  name: 'Home'
}
</script>