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
    <MarkerPopup v-if="showDetails"
                 :asset="mapCenterPoint"
                 style="position: fixed; top: 40%; left: 50%; z-index: 3; transform: translate(-50%, -50%);"/>
  </div>
</template>

<style>
.gmnoprint {
  margin-top: 85vh !important;
}

.gm-svpc {
  /* Hides the streetview button */
  visibility: hidden;
}
</style>
<script>
import {GoogleMap, Marker} from "vue3-google-map";
import $ from 'jquery';
import MarkerPopup from "./MarkerPopup";
import axios from "axios";

export default {
  name: "Maps", components: {MarkerPopup, GoogleMap, Marker},
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

    setTimeout(() => {
      if (this.$route.query.trackerId && !!this.manyPoints[this.$route.query.trackerId]) {
        this.markerClicked(this.$route.query.trackerId);
      }
    }, 100);

    this.refreshTrackers();
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
    },
    refreshTrackers() {
      setTimeout(() => {
        axios.get(`/user/${this.$store.state.currentUser}/assets`)
            .then((response) => {
              this.$toast.success('Assets refreshed');
              this.$store.commit('setTrackers', response.data);
            })
            .catch(() => {
              this.$toast.error('Something went wrong fetching assets');
            });
        this.refreshTrackers();
      }, 30000);
    }
  },
  computed: {
    apiKey() {
      return "AIzaSyA60EGif9CSjhW_koDfNNIZM2QSsgL-pM0";
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