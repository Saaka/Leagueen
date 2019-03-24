import { Home } from "components/tempComponents/Home";
import { Counter } from "components/tempComponents/Counter";

const appRoutes = [
    {
        path: "/app/home",
        component: Home,
        name: "Home",
    },
    {
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