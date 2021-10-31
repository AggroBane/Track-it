<template>
  <div class="m-5 d-flex flex-column justify-content-center">
    <button class="m-2" @click="$router.push('AddTracker')">Add tracker</button>
    <input id="assetname" v-model="assetName"/>
    <label for="assetname">Asset name</label>

    <select id="assettype" v-model="selectedAssetType">
      <option v-for="(value, key) in assetType" :key="key" :value="value">{{ key }}</option>
    </select>
    <label for="assettype">Asset type</label>

    <select id="linkedtracker" v-model="selectedTracker">
      <option v-for="(value, index) in allTrackers" :key="index" :value="allTrackers[index].id">{{
          allTrackers[index].id
        }}
      </option>
    </select>
    <label for="linkedtracker">Tracker</label>
    <button @click="submitAsset">submit</button>
  </div>
</template>

<script>
import {trackerTypeEnum} from "../assets/trackerDefaultImages";
import axios from "axios";

export default {
  name: "AddStuff",
  beforeMount() {
    // TODO poke backend for assets
    axios.get('/tracker').then(response => {
      this.allTrackers = response.data;
      console.log('added trackers to this shit');
    })
  },
  data() {
    return {
      assetType: trackerTypeEnum,
      allTrackers: [],
      selectedAssetType: undefined,
      assetName: '',
      selectedTracker: null
    }
  },
  methods: {
    submitAsset() {
      console.log('selectedTracker');
      axios.post('/asset', {
        id: this.assetName,
        type: this.selectedAssetType,
        imageurl: '',
        TrackerId: this.selectedTracker,
        UserId: this.$store.state.currentUser
      }).then(() => {
        this.$toast.success('Asset was created!');
        axios.get(`/user/${this.$store.state.currentUser}/assets`)
            .then((response) => {
              this.$store.state.dev_env ? this.$toast.success('Fetched assets') : '';
              this.$store.commit('setTrackers', response.data);
            })
            .catch(() => {
              this.$toast.error('Something went wrong fetching assets');
            })
      }).catch(() => {
        this.$toast.error('error creating asset')
      });
    }
  }
}
</script>

<style scoped>

</style>