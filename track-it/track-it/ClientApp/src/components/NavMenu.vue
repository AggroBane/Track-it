<template>
    <header>
        <Slide>
            <router-link :to="{ name: 'Home' }" class="nav-link">Home</router-link>
            <router-link :to="{ name: 'Counter' }" class="nav-link">Counter</router-link>
            <router-link :to="{ name: 'FetchData' }" class="nav-link">Fetch Data</router-link>
            <router-link :to="{ name: 'Map' }" class="nav-link">Map</router-link>
        </Slide>
    </header>
</template>

<style>
    a.navbar-brand {
        white-space: normal;
        text-align: center;
        word-break: break-all;
    }

    html {
        font-size: 14px;
    }

    @media (min-width: 768px) {
        html {
            font-size: 16px;
        }
    }

    .box-shadow {
        box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05);
    }
</style>
<script>
    import { Slide } from 'vue3-burger-menu'  // import the CSS transitions you wish to use, in this case we are using `Slide`

    export default {
        name: "NavMenu",
        components: {
            Slide // Register your component
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