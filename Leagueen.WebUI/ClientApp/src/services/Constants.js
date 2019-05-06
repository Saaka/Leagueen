let Constants = class Constants {};

Constants.ApiRoutes = class ApiRoutes {
    static get LOGIN() {
        return "auth/login";
    }
    static get GOOGLE() {
        return "auth/google";
    }
    static get FACEBOOK() {
        return "auth/facebook";
    }
    static get GETUSER() {
        return "auth/user";
    }
};

Constants.ApiRoutes.Matches = class MatchesRoutes {
    static get TODAY() {
        return "matches/today";
    }
    static get ROOT() {
        return "matches";
    }
};

Constants.MatchStatus = class MatchStatus {
    static get SCHEDULED() {
        return 1;
    }
    static get IN_PLAY() {
        return 2;
    }
    static get PAUSED() {
        return 3;
    }
    static get FINISHED() {
        return 4;
    }
    static get POSTPONED() {
        return 5;
    }
    static get SUSPENDED() {
        return 6;
    }
    static get CANCELED() {
        return 7;
    }
};

export { Constants };