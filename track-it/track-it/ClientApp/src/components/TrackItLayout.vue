<template>
  <div>
    <nav-menu/>
    <h1>This is the layout</h1>
    <h2>{{ something }}</h2>
    <router-view/>
  </div>
</template>

<script>
import NavMenu from './NavMenu.vue'
export default {
  components: { NavMenu },
  name: "TrackItLayout",
  data() {
    return {
      something: 'THIS IS DATAAAAA'
    }
  }
}
</script>