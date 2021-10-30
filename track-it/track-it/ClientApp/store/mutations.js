import {arrayToDictionary} from "./utilities";

export default {
    setUsername(state, name) {
        state.currentUser = name;
    },
    setTrackers(state, trackerArray) {
        state.trackers = arrayToDictionary(trackerArray, 'name');
    },
    setDevEnv(state, value) {
        if (typeof value == "boolean") {
            state.dev_env = value;
        } else {
            state.dev_env = (value === 'true');
        }
    }
}