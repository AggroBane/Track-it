import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Map from "@/components/Map.vue";
import TrackItLayout from "../components/TrackItLayout";
import Trackers from "../components/Trackers";
import AddTracker from "../components/AddTracker";

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
        path: "/Trackers",
        name: "Trackers",
        component: Trackers,
    },
    {
        path: "/trackit",
        name: "TrackItApp",
        component: TrackItLayout
    },
    {
        path: "/AddTracker",
        name: "AddTracker",
        component: AddTracker
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;