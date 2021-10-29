<template>
  <div>
    <nav-menu/>
    <track-it-layout/>
  </div>
</template>

<script>
import NavMenu from './components/NavMenu.vue';
import TrackItLayout from "./components/TrackItLayout";

export default {
  name: 'App',
  components: {
    NavMenu,
    TrackItLayout
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
