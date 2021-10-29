import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Map from "@/components/Map.vue";
import TrackItLayout from "../components/TrackItLayout";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/Map",
        name: "Map",
        component: Map,
    },
    {
        path: "/trackit",
        name: "TrackItApp",
        component: TrackItLayout
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;