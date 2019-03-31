import { Matches, Counter, Dashboard } from "views/exports";


const appRoutes = [
    {
        path: "/app/home",
        component: Dashboard,
        name: "Home",
    },
    {
        useAuth: true,
        path: "/app/counter",
        component: Counter,
        name: "Counter"
    },
    {
        path: "/app/mathes",
        component: Matches,
        name: "Matches"
    },
    {
        redirect: true,
        path: "/app",
        to: "/app/home",
        name: "Home"
    }
];

export default appRoutes;