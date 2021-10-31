<template>
  <div>
    <router-view v-if="ready"/>
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
  beforeMount() {
    // setting state
    this.$store.commit('setDevEnv', process.env.VUE_APP_DEV_ENV);

    this.fetchAssets();

    this.$store.commit('setReady', true);
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
  },
  computed: {
    ready() {
      return this.$store.state.ready;
    }
  }
}
</script>