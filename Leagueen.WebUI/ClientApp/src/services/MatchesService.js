import { AuthHttpService, Constants } from "Services";

class MatchesService {
    httpAuth = new AuthHttpService();

    getTodaysMatches = () => {
        return this.httpAuth
            .get(Constants.ApiRoutes.Matches.TODAY);
    };
};

export { MatchesService };