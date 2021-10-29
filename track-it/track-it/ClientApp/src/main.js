import 'bootstrap/dist/css/bootstrap.css';
import {createApp} from 'vue';
import App from './App.vue';
import router from './router';
import {GoogleMap} from "vue3-google-map";

const app = createApp(App);
app.use(router);
app.use(GoogleMap, {apiKey: process.env.VUE_APP_GOOGLE_API_KEY});

app.config.devtools = true;
app.mount('#app');