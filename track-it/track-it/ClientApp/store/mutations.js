import {arrayToDictionary} from "./utilities";

export default {
    setUsername(state, name) {
        state.currentUser = name;
    },
    setTrackers(state, trackerArray) {
        state.trackers = arrayToDictionary(trackerArray, 'id');
    },
    setDevEnv(state, value) {
        if (typeof value == "boolean") {
            state.dev_env = value;
        } else {
            state.dev_env = (value === 'true');
        }
    },
    setReady(state, value) {
        state.ready = value;
    }
}