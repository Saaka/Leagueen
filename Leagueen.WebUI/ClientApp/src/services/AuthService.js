import { AuthHttpService, HttpService, Constants, UserTokenService } from 'Services';

export class AuthService {
    httpService = new HttpService();
    authHttpService = new AuthHttpService();
    tokenService = new UserTokenService();

    isLoggedIn = () => this.tokenService.isTokenValid();

    logout = () => this.tokenService.removeToken();
    
    loginWithCredentials = (email, password) => {
        return this.httpService
            .post(Constants.ApiRoutes.LOGIN, {
                password: password,
                email: email
            })
            .then(this.onLogin);
    };

    loginWithGoogle = (token) => {
        return this.httpService
            .post(Constants.ApiRoutes.GOOGLE, {
                googleToken: token
            })
            .then(this.onLogin);
    };

    loginWithFacebook = (token) => {
        return this.httpService
            .post(Constants.ApiRoutes.FACEBOOK, {
                facebookToken: token
            })
            .then(this.onLogin);
    };

    onLogin = (resp) => {

        this.tokenService
            .setToken(resp.data.token);
        return {
            ...resp.data.user,
            token: resp.data.token
        };
    };

    getUser = () => {
        var token = this.tokenService
            .getToken();
        return this.authHttpService
            .get(Constants.ApiRoutes.GETUSER)
            .then(resp => {
                return {
                    ...resp.data,
                    token: token
                };
            });
    };
}