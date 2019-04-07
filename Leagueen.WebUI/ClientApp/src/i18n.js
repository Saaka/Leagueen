import { registerLocale, setDefaultLocale } from "react-datepicker";
import enGb from "date-fns/locale/en-GB";

function configureInternationalization() {
    registerLocale("en-GB", enGb);
    setDefaultLocale("en-GB");
}

export default configureInternationalization;