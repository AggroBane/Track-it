<template>
  <div class="m-5 pt-3 d-flex flex-column justify-content-center">
    <input v-model="trackerId" placeholder="Name">
    <button class="m-2" @click="submit">Add tracker</button>
    <button class="m-2" @click="$router.push('AddStuff')">back to add asset</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Trackers",
  data() {
    return {
      trackerId: ''
    }
  },
  methods: {
    submit() {
      if (this.trackerId != '') {
        // Let user chose type soon
        axios.post('/tracker', {id: this.trackerId, lat: 46.6120085, lng: -71.1074071}).then(() => {
          this.$toast.success('Tracker was created!');
        }).catch(() => {
          this.$toast.error('error creating tracker');
        });
      }
    }
  }
}
</script>