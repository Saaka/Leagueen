import { AuthHttpService, Constants } from "Services";

class MatchesService {
    httpAuth = new AuthHttpService();

    getTodaysMatches = () => {
        return this.httpAuth
            .get(Constants.ApiRoutes.Matches.TODAY);
    };

    getMatchesByDate = (date) => {
        var qs = `?date=${date.toISOString()}`;
        return this.httpAuth
            .get(`${Constants.ApiRoutes.Matches.ROOT}${qs}`);
    };
};

export { MatchesService };