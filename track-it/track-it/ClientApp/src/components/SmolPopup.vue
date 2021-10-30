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
export default {
  name: "SmolPopup",
  props: {
    asset: {
      type: Object,
      required: true
    }
  },
  computed: {
    trackerImage() {
      let assetPath = '../assets';
      // TODO make this use actual images
      switch (this.asset.type) {
        case 1:
          return `${assetPath}/logo.png`;
        default:
          return `${assetPath}/trackitlogo.png`;
      }
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