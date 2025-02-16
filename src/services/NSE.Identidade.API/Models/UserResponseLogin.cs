namespace NSE.Identidade.API.Models
{
    public class UserResponseLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }

        public UserToken userToken { get; set; }
    }
}
