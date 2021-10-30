<template>
  <div>
    <router-view/>
  </div>
</template>
<style>
body, html {
  height: 100%;
  width: 100%;
}
</style>

<script>
export default {
  name: "TrackItLayout",
  mounted() {
    // setting state
    this.$store.commit('setDevEnv', process.env.VUE_APP_DEV_ENV);


    // TODO poke backend to populate trackers
    

  }
}
</script>