<template>
  <div>
    <button class="accordion" @click="listClick($event)">Tracker {{ asset.id }}</button>
    <div class="panel">
      <div class="divimg">
        <img :src="trackerImage" class="flex-item"
             style="float:left; width:300px; height:300px;">
        <div class="flex-item" style="text-align:left">
          <p>id: {{ asset.id }}</p>
          <p>Name: {{ asset.id }}</p>
          <p>Last tracked at: {{ asset.tracker.lastPingUtc }}</p>
          <p>Coordinates: (
            <router-link :to="{ name: 'Map', query:{ trackerId: asset.id }}" class="no-style">
              <span class="lat">{{ asset.tracker.lat }}</span>,
              <span class="lng">{{ asset.tracker.lng }}</span>
            </router-link>
            )
          </p>
        </div>
      </div>
      <router-link :to="{ name: 'Map', query: { trackerId: asset.id }}" class="no-style">
        <img :src="'https://www.mapquestapi.com/staticmap/v5/map?'+
      'key=FajS1lvGMdqN1HyNfTrdiAM8KIQziNqr&'+
      'center=' + asset.tracker.lat + ',' + asset.tracker.lng +
      '&zoom=12&size=1200,800&'+
      'locations=' + asset.tracker.lat + ',' + asset.tracker.lng + '|marker-lg-red'
      " class="flex-item"></router-link>
    </div>
  </div>
</template>

<script>
import {defaultImages, trackerTypeEnum} from "../assets/trackerDefaultImages";

export default {
  name: "TrackerListItem",
  props: {
    asset: {type: Object, required: true},
    listClick: {type: Function}
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

</style>