<template>
  <div>
    <router-view/>
  </div>
</template>
<style>
body, html {
  height: 100%;
  width: 100%;
}
</style>

<script>
import axios from 'axios'

export default {
  name: "TrackItLayout",
  async beforeMount() {
    // setting state
    this.$store.commit('setDevEnv', process.env.VUE_APP_DEV_ENV);

    await this.fetchAssets();
    // TODO poke backend to populate trackers
  },
  methods: {
    async fetchAssets() {
      try {
          let axiosResponse = await axios.get(`/asset/${this.$store.state.currentUser}`);
          
            this.$store.state.dev_env ? this.$toast.success('Fetched assets') : this.$toast.error('aaaaaaas');
            this.$store.commit('setTrackers', axiosResponse.data);
      } catch (e) {
            this.$toast.error('Something went wrong fetching assets');
          }
    }
  }
}
</script>