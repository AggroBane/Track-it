<template>
  <div>
    <p class="font-medium">{{ something }}</p>
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