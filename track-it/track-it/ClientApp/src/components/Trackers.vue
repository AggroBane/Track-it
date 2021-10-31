<template>
  <div style="padding-top: 4rem;">
    <TrackerListItem v-for="asset in trackers" :key="asset.id" :asset="asset" :list-click="listClick"/>
    <hr style="margin: 0px;">
  </div>
  <button class="kc_fab_main_btn" @click="$router.push('AddStuff')">+</button>
</template>

<style>
.kc_fab_main_btn {
  position: fixed;
  right: 5%;
  bottom: 5vh;
  background-color: #F44336;
  width: 60px;
  height: 60px;
  border-radius: 100%;
  background: #F44336;
  border: none;
  outline: none;
  color: #FFF;
  font-size: 36px;
  box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
  transition: .3s;
  -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
}

.imgTracker {
  float: left;
  width: 300px;
  height: 300px;
}

.divimg {
  display: flex;
  flex-wrap: nowrap;
}

.flex-item {
  margin: 10px;
}

img.flex-item {
  width: 400px;
  height: 300px;
}

.no-style {
  text-decoration: none;
}

.lat {
  color: red;
}

.lng {
  color: blue;
}

.accordion {
  background-color: #eee;
  color: #444;
  cursor: pointer;
  padding: 18px;
  width: 100%;
  text-align: center;
  border: none;
  outline: none;
  transition: 0.4s;
}

/* Add a background color to the button if it is clicked on (add the .active class with JS), and when you move the mouse over it (hover) */
.active, .accordion:hover {
  background-color: #ccc;
}

/* Style the accordion panel. Note: hidden by default */
.panel {
  display: flex;
  justify-content: center;
  flex-wrap: nowrap;
  padding: 0 18px;
  background-color: white;
  max-height: 0;
  overflow: hidden;
  transition: max-height 0.2s ease-out;
}

@media screen and (max-width: 950px) {
  .panel {
    flex-wrap: wrap;
    justify-content: left;
  }
}

@media screen and (max-width: 600px) {
  .panel {
    flex-wrap: wrap;
    justify-content: center;
  }

  .divimg {
    flex-wrap: wrap;
    justify-content: center;
  }
}
</style>

<script>
import TrackerListItem from "./TrackerListItem";

export default {
  name: "Trackers",
  components: {TrackerListItem},
  mounted() {
    if (this.$store.state.dev_env && Object.keys(this.trackers).length === 0) {
      this.$store.commit('setTrackers', [
        {
          id: "marker1",
          tracker: {
            imageurl: "https://static.wikia.nocookie.net/dogelore/images/9/97/Doge.jpg",
            lastPingUtc: new Date(),
            lat: 46.6120085,
            lng: -71.1074071
          }
        },
        {
          id: "marker2",
          tracker: {
            imageurl: "https://cdn.vox-cdn.com/thumbor/MfAL89LfeltyZgd9Ra8C2iBjq3U=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/19539772/cats4.jpg",
            lastPingUtc: new Date(),
            lat: 47.6120085,
            lng: -70.1074071
          }
        }
      ]);
      this.$toast.info('State was empty, populating map with random markers');
    }
  },
  methods: {
    listClick: function (event) {
      event.target.classList.toggle("active");
      var panel = event.target.nextElementSibling;
      if (panel.style.maxHeight) {
        panel.style.maxHeight = null;
      } else {
        panel.style.maxHeight = "800px";
      }
    }
  },
  computed: {
    trackers() {
      return this.$store.state.trackers;
    }
  }
}
</script>