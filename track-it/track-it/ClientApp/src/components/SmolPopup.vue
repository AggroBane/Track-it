<template>
  <div class="smolPopup">
    <img src="../assets/trackitlogo.png" style="height: 4rem; width: 4rem;"/>
    <div class="d-flex flex-column align-items-center h-100">
      <h3 style="font-size: 16px;">{{ tracker.name }}</h3>
      <p style="font-size: 12px;">Latitude: {{ tracker.lat }}</p>
      <p style="font-size: 12px;">Longitude: {{ tracker.lng }}</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "SmolPopup",
  props: {
    tracker: {
      type: Object,
      required: true
    }
  },
  computed: {
    trackerImage() {
      switch (this.tracker.type) {
        case 'dog':
          return 'dog.png';
        default:
          return 'logo.png'
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