import { AuthHttpService, Constants } from "Services";

class UserGroupsService {
    httpAuth = new AuthHttpService();

    getUserGroups = () => {
        return this.httpAuth
            .get(Constants.ApiRoutes.UserGroups.LIST);
    };
};

export { UserGroupsService };