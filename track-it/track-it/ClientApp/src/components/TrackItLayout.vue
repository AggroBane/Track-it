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
    fetchAssets() {
      axios.get(`/user/${this.$store.state.currentUser}/assets`)
          .then((response) => {
            this.$store.state.dev_env ? this.$toast.success('Fetched assets') : '';
            this.$store.commit('setTrackers', response.data);
          })
          .catch(() => {
            this.$toast.error('Something went wrong fetching assets');
          })
      }
    }
}
</script>