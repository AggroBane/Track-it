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
</style>
