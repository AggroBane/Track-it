<template>
  <GoogleMap
      :api-key="apiKey"
      :center="somePoint"
      :zoom="15"
      style="width: 100%; height: 500px"
      styles="dark">
    <Marker v-for="point in manyPoints" :key="point.lat" :options="{position: point}" @click="scream(point.title)"/>
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
      {lat: 46.6120085, lng: -71.1074071, title: "j'ai mal"},
      {lat: 47.6120085, lng: -70.1074071, title: "j'ai mal2"},
      {lat: 48.6120085, lng: -72.1074071, title: "j'ai mal3"},
      {lat: 45.6120085, lng: -73.1074071, title: "j'ai mal5"}
    ];
  },
  methods: {
    scream(title) {
      let iCry = "AAAAAAAAAAAAAAAAAAAAAAAA " + title;
      console.log(iCry);
      this.$toast.success(iCry, {position: 'top-right'});
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