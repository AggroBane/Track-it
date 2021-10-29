import 'bootstrap/dist/css/bootstrap.css';
import {createApp} from 'vue';
import {createStore} from 'vuex'
import App from './App.vue';
import router from './router';
import Toaster from '@meforma/vue-toaster';
import mutations from "../store/mutations";
import state from "../store/state";

const store = createStore({
    state() {
        return state;
    },
    mutations
})

const app = createApp(App);
app.use(Toaster)
    .use(router)
    .use(store);

app.config.devtools = true;
app.mount('#app');