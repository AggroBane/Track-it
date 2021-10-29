<template>
  <div id="app">
    <nav-menu/>
    <track-it-layout id="page-wrap"/>
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
  width: 100%;
  height: 100%;
}
</style>
