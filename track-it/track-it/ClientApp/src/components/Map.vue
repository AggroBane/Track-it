<template>
  <div>
    <GoogleMap id="map"
               :api-key="apiKey"
               :center="mapCenterPoint.tracker"
               :scrollwheel="false"
               :style="{height: myheight}"
               :zoom="zoom"
               style="width: 100%;"
               @mousedown="showDetails = false">
      <Marker v-for="point in Object.values(manyPoints)" :key="point.id" :options="{position: point.tracker}"
              @click="markerClicked(point.id)"/>
    </GoogleMap>
    <SmolPopup v-if="showDetails"
               :asset="mapCenterPoint"
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
      mapCenterPoint: {tracker: {lat: 46.6120085, lng: -71.1074071}},
      zoom: 5,
      showDetails: false
    }
  },
  mounted() {
    if (this.$store.state.dev_env && Object.keys(this.manyPoints).length === 0) {
      this.$store.commit('setTrackers', [
        {tracker: {lat: 46.6120085, lng: -71.1074071}, id: "marker1"},
        {tracker: {lat: 47.6120085, lng: -70.1074071}, id: "marker2"},
        {tracker: {lat: 46.3120085, lng: -72.1074071}, id: "marker3"},
        {tracker: {lat: 46.8120085, lng: -71.2074071}, id: "marker4"},
        {tracker: {lat: 46.3120085, lng: -71.1074071}, id: "marker5"}
      ]);
      this.$toast.info('State was empty, populating map with random markers');
    }
  },
  methods: {
    markerClicked(markerName) {
      //Reset the variables
      this.mapCenterPoint = {tracker: {lat: 0, lng: 0}};
      this.zoom = 0;

      this.$nextTick(() => {
        this.mapCenterPoint = this.manyPoints[markerName];
        this.zoom = 9;

        setTimeout(() => {
          this.showDetails = true;
        }, 750);
      });
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