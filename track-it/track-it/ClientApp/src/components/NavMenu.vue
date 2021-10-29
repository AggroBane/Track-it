<template>
    <header>
        <Reveal>
            <router-link :to="{ name: 'Home' }" class="nav-link">Home</router-link>
            <router-link :to="{ name: 'Counter' }" class="nav-link">Counter</router-link>
            <router-link :to="{ name: 'FetchData' }" class="nav-link">Fetch Data</router-link>
            <router-link :to="{ name: 'Map' }" class="nav-link">Map</router-link>
        </Reveal>
    </header>
</template>

<style>
    a.navbar-brand {
        white-space: normal;
        text-align: center;
        word-break: break-all;
    }
    .bm-burger-button {
      position: absolute;
      z-index:10;
      width: 36px;
      height: 30px;
      left: 36px;
      top: 70px;
      cursor: pointer;
    }
    .bm-burger-button:hover {
        filter: brightness(150%);
    }
    .bm-cross-button {
        margin-right:25%;
        padding-top:3%;
        padding-left:40%;
        padding-right:3%;
        width:50%;
        transform:scale(2)
    }
    .bm-cross-button:hover {
        filter: brightness(75%);
    }
    .bm-menu {
        padding-top:50px;
    }

</style>
<script>
    import { Reveal } from 'vue3-burger-menu'  // import the CSS transitions you wish to use, in this case we are using `Slide`

    export default {
        name: "NavMenu",
        components: {
            Reveal // Register your component
        },
        data() {
            return {
                isExpanded: false
            }
        },
        methods: {
            collapse() {
                this.isExpanded = false;
            },

            toggle() {
                this.isExpanded = !this.isExpanded;
            }
        }
    }
</script>