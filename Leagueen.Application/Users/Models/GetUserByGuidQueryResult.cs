namespace Leagueen.Application.Users.Models
{
    public class GetUserByGuidQueryResult
    {
        public bool UserExists { get; set; }
        public UserDto User { get; set; }
    }
}
