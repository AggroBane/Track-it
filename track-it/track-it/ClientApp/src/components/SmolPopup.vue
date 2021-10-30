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
      // TODO make this use actual images
      switch (this.asset.type) {
        case 1:
          return `https://wpcdn.us-east-1.vip.tn-cloud.net/www.abc6.com/content/uploads/2021/04/f/j/eg-car-in-water-2-credit-iafflocal3328-1-1024x768.jpg`;
        default:
          return `https://cdn.shopify.com/s/files/1/0250/3537/4674/products/582596d6d746e28b65b0aed958e49b4d_32958db2-332e-4018-a5e1-12d73614a90d.jpg?v=1594323451.png`;
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