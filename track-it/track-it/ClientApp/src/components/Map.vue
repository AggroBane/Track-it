<template>
  <GoogleMap
      :api-key="apiKey"
      :center="somePoint"
      :zoom="15"
      style="width: 100%; height: 500px">
    <Marker :options="{ position: somePoint }"/>
  </GoogleMap>
</template>
<script>
import {GoogleMap, Marker} from "vue3-google-map";

export default {
  name: "Maps", components: {GoogleMap, Marker},
  data() {
    return {
      somePoint: {lat: 40.689247, lng: -74.044502}
    }
  },
  computed: {
    apiKey() {
      return process.env.VUE_APP_GOOGLE_API_KEY;
    }
  }
}
</script>
<style>

</style>