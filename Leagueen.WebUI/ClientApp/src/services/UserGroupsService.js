import { AuthHttpService, Constants } from "Services";

class UserGroupsService {
    httpAuth = new AuthHttpService();

    getUserGroups = () => {
        return this.httpAuth
            .get(Constants.ApiRoutes.UserGroups.LIST);
    };

    saveGroup = (request) => {
        return this.httpAuth
            .post(Constants.ApiRoutes.UserGroups.CREATE_GROUP, request);
    };
};

export { UserGroupsService };