let RouteNames = class RouteNames {};

RouteNames.Root = "/";

RouteNames.Login = "/login";
RouteNames.Logout = "/logout";

RouteNames.App = "/app";
RouteNames.Unauthorized = "/app/unauthorized";
RouteNames.Home = "/app/home";
RouteNames.Matches = "/app/matches";
RouteNames.UserGroups = "/app/userGroups";
RouteNames.CreateGroup = "/app/createGroup";
RouteNames.Group = "/app/group/:id";
RouteNames.Group_Id = "/app/group/";
RouteNames.FriendsList = "/app/friendsList"

RouteNames.Counter = "/app/counter";

export { RouteNames };