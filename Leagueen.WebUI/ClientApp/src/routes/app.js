import { Matches, Counter, Dashboard } from "views/exports";


const appRoutes = [
    {
        path: "/app/home",
        component: Dashboard,
        name: "Home",
    },
    {
        path: "/app/mathes",
        component: Matches,
        name: "Matches"
    },
    {
        useAuth: true,
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