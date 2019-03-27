import { OPEN_SIDEBAR, CLOSE_SIDEBAR } from "./actionTypes";

function sidebarReducer(state, action) {
    switch(action.type) {
        case OPEN_SIDEBAR:
            return createState(true);
        case CLOSE_SIDEBAR:
            return createState(false);
        default:
            return state;
    }
};

function createState(show) {
    return {
        show: show
    };
}

export { sidebarReducer };