import { Matches, Counter, Dashboard, Unauthorized, UserGroups, CreateGroup } from "views/exports";
import { RouteNames } from "./names";

const appRoutes = [
    {
        path: RouteNames.Home,
        component: Dashboard,
        name: "Home",
        icon: "home"
    },
    {
        hide: true,
        path: RouteNames.Unauthorized,
        component: Unauthorized,
        name: "Unauthorized"
    },
    {
        useAuth: true,
        path: RouteNames.Matches,
        component: Matches,
        name: "Matches",
        icon: "futbol"
    },
    {
        useAuth: true,
        path: RouteNames.UserGroups,
        component: UserGroups,
        name: "Groups",
        icon: "users"
    },
    {
        hide: true,
        useAuth: true,
        path: RouteNames.CreateGroup,
        component: CreateGroup,
        name: "Group creation",
    },
    {
        useAuth: true,
        requireAdmin: true,
        path: RouteNames.Counter,
        component: Counter,
        name: "Counter"
    },
    {
        redirect: true,
        path: RouteNames.App,
        to: RouteNames.Home,
        name: "Home"
    }
];

export default appRoutes;