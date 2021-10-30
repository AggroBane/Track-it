<template>
  <div>
    <button @click="updateState">Update State</button>
    <GoogleMap id="map"
               :api-key="apiKey"
               :center="mapCenterPoint"
               :scrollwheel="false"
               :style="{height: myheight}"
               :zoom="zoom"
               style="width: 100%;"
               @mousedown="showDetails = false">
      <Marker v-for="point in Object.values(manyPoints)" :key="point.lat" :options="{position: point}"
              @click="markerClicked(point.name)"/>
    </GoogleMap>
    <SmolPopup v-if="showDetails"
               :tracker="mapCenterPoint"
               style="position: fixed; top: 40%; left: 50%; z-index: 3; transform: translate(-50%, -50%);"/>
  </div>
</template>

<style>
.gmnoprint {
  margin-top: 65% !important;
}

.gm-svpc {
  /* Hides the streetview button */
  visibility: hidden;
}
</style>
<script>
import {GoogleMap, Marker} from "vue3-google-map";
import $ from 'jquery';
import SmolPopup from "./SmolPopup";

export default {
  name: "Maps", components: {SmolPopup, GoogleMap, Marker},
  data() {
    return {
      mapCenterPoint: {lat: 46.6120085, lng: -71.1074071},
      zoom: 5,
      showDetails: false,
      trackerarray: []
    }
  },
  mounted() {
    //TODO poke backend for our points
    this.trackerarray = [
      {lat: 46.6120085, lng: -71.1074071, name: "marker1"},
      {lat: 47.6120085, lng: -70.1074071, name: "marker2"},
      {lat: 48.6120085, lng: -72.1074071, name: "marker3"},
      {lat: 45.6120085, lng: -73.1074071, name: "marker4"}
    ];
    if(this.$route.query.trackerId && this.manyPoints[this.$route.query.trackerId])
    {
      this.markerClicked(this.$route.query.trackerId);
    }
  },
  methods: {
    markerClicked(markerName) {
      //Reset the variables
      this.mapCenterPoint = {lat: 0, lng: 0};
      this.zoom = 0;
      this.$router.push({ path: 'Map', query: { trackerId: markerName }});

      this.$nextTick(() => {
        this.mapCenterPoint = this.manyPoints[markerName];
        this.zoom = 9;

        setTimeout(() => {
          this.showDetails = true;
        }, 750);
      });
    },
    updateState() {
      this.$store.commit('setTrackers', this.trackerarray);
    }
  },
  computed: {
    apiKey() {
      return process.env.VUE_APP_GOOGLE_API_KEY;
    },
    myheight() {
      return $(window).height() + 'px';
    },
    manyPoints() {
      return this.$store.state.trackers;
    }
  }
};
</script>