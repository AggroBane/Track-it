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
  data() {
    return {
      something: 'THIS IS DATAAAAA'
    }
  }
}
</script>