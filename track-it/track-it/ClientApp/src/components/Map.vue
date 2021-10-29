<template>
  <GoogleMap
      :center="{lat: 40.689247, lng: -74.044502}"
      :zoom="15"
      style="width: 100%; height: 500px">
  </GoogleMap>
</template>
<script>
import {GoogleMap} from "vue3-google-map";

export default {
  name: "Maps", components: {GoogleMap}
}
</script>