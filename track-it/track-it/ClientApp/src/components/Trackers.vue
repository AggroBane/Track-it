<template>
  <div>
    <nav class="navbar navbar-light light-blue lighten-4">
        <div id="accordion">
            <div class="card">
                <div class="card-header" id="headingOne">
                    <h5 class="mb-0">
                    <button class="btn btn-link" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                        Collapsible Group Item #1
                    </button>
                    </h5>
                </div>
            </div>
        </div>
    <li v-for="tracker in trackers" in items :key="tracker.id">
          
    </li>
    </nav>
  </div>
</template>

<script>

export default {
  name: 'Trackers',
  data() {
    return {
        trackers: [
            { tracker1: {
              id:1,
              name:"mon chien",
              img: "https://static.wikia.nocookie.net/dogelore/images/9/97/Doge.jpg"
            }},
            { tracker2: {
              id:2,
              name:"mon chat",
              img: "https://cdn.vox-cdn.com/thumbor/MfAL89LfeltyZgd9Ra8C2iBjq3U=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/19539772/cats4.jpg"
            }}
        ]
    }
  }

}
</script>