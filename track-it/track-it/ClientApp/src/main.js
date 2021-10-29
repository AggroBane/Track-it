import 'bootstrap/dist/css/bootstrap.css';
import {createApp} from 'vue';
import App from './App.vue';
import router from './router';
import Toaster from '@meforma/vue-toaster';

const app = createApp(App);
app.use(Toaster)
    .use(router);

app.config.devtools = true;
app.mount('#app');