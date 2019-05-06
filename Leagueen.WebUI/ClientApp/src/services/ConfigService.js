export class ConfigService {
    constructor(){
        this.ApiUrl = process.env.REACT_APP_API_URL;
        this.GoogleClientId = process.env.REACT_APP_GOOGLE_ID;
        this.FacebookAppId = process.env.REACT_APP_FACEBOOK_ID;
    }
}