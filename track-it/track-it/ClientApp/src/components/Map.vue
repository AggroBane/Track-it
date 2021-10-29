<template>
  <GoogleMap
      :api-key="apiKey"
      :center="somePoint"
      :zoom="15"
      style="width: 100%; height: 500px"
      styles="dark">
    <Marker v-for="point in manyPoints" :key="point.lat" :options="{position: point}" @click="scream"/>
  </GoogleMap>
</template>
<script>
import {GoogleMap, Marker} from "vue3-google-map";

export default {
  name: "Maps", components: {GoogleMap, Marker},
  data() {
    return {
      somePoint: {lat: 46.6120085, lng: -71.1074071},
      manyPoints: []
    }
  },
  mounted() {
    //TODO poke backend for our points
    this.manyPoints = [
      {lat: 46.6120085, lng: -71.1074071},
      {lat: 47.6120085, lng: -70.1074071},
      {lat: 48.6120085, lng: -72.1074071},
      {lat: 45.6120085, lng: -73.1074071}
    ];
  },
  methods: {
    scream() {
      console.log("AAAAAAAAAAAAAAAAAAAAAAAAA");
    }
  },
  computed: {
    apiKey() {
      return process.env.VUE_APP_GOOGLE_API_KEY;
    }
  }
}
</script>