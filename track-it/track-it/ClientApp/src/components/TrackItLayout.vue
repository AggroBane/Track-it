<template>
  <div>
    <h1>This is the layout</h1>
    <h2>{{ something }}</h2>
    <router-view/>
  </div>
</template>

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