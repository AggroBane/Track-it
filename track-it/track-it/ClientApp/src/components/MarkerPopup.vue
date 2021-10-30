<template>
  <div class="smolPopup">
    <img :src="trackerImage" style="height: 4rem; width: 4rem;"/>
    <div class="d-flex flex-column align-items-center h-100">
      <h3 style="font-size: 16px;">{{ asset.id }}</h3>
      <p style="font-size: 12px;">Latitude: {{ asset.tracker.lat }}</p>
      <p style="font-size: 12px;">Longitude: {{ asset.tracker.lng }}</p>
    </div>
  </div>
</template>

<script>
import {defaultImages, trackerTypeEnum} from "../assets/trackerDefaultImages";

export default {
  name: "MarkerPopup",
  props: {
    asset: {
      type: Object,
      required: true
    }
  },
  computed: {
    trackerImage() {
      if (this.asset.imageUrl) return this.asset.imageUrl;
      else return defaultImages[this.asset.type] !== undefined ? defaultImages[this.asset.type] : defaultImages[trackerTypeEnum.DEFAULT];
    }
  }
}
</script>

<style scoped>
.smolPopup {
  background-color: #ea4335;
  width: 20rem;
  height: 7rem;
  border-radius: 10px;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  padding: 1rem;
}
</style>