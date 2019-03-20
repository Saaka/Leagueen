import { Home } from "components/tempComponents/Home";
import { Counter } from "components/tempComponents/Counter";

const appRoutes = [
    {
        path: "/home",
        component: Home,
        name: "Home"
    },
    {
        path: "/counter",
        component: Counter,
        name: "Counter"
    },
    {
        redirect: true,
        path: "/",
        to: "/home",
        name: "Home"
    }
];

export default appRoutes;