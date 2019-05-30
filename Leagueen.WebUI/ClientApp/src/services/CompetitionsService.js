import { AuthHttpService, Constants } from "Services";

class CompetitionsService {
    httpAuth = new AuthHttpService();

    getSeasonsDictionary = () => {
        return this.httpAuth
            .get(Constants.ApiRoutes.Competitions.SEASONS_DICTIONARY)
            .then(resp => resp.data.seasons);
    };
};

export { CompetitionsService };