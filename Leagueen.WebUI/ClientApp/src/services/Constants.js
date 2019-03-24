let Constants = class Constants {}

Constants.ApiRoutes = class ApiRoutes {
    static get LOGIN() {
        return "auth/login";
    }
    static get GOOGLE() {
        return "auth/google";
    }
    static get GETUSER() {
        return "auth/user";
    }
}

export { Constants };