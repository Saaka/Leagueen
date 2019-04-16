import { Matches, Counter, Dashboard, Unauthorized } from "views/exports";


const appRoutes = [
    {
        path: "/app/home",
        component: Dashboard,
        name: "Home",
    },
    {
        hide: true,
        path: "/app/unauthorized",
        component: Unauthorized,
        name: "Unauthorized"
    },
    {
        useAuth: true,
        path: "/app/matches",
        component: Matches,
        name: "Matches"
    },
    {
        useAuth: true,
        requireAdmin: true,
        path: "/app/counter",
        component: Counter,
        name: "Counter"
    },
    {
        redirect: true,
        path: "/app",
        to: "/app/home",
        name: "Home"
    }
];

export default appRoutes;