using CustomersApp.Models.Interfaces;

namespace CustomersApp.Models.Services
{
    public class UserService:IUser
    {
        private readonly JwtTokenService _jwtTokenService;

        public UserService(JwtTokenService jwtTokenService)
        {

            _jwtTokenService = jwtTokenService; 

        }

        public string login(User user)
        {
            if(user.Name!="Admin" || user.Passowrd != "Admin@123")
            {
                return "Wrong Name OR Passowred";
            }
            string token =  _jwtTokenService.GetToken(user, TimeSpan.FromMinutes(30));
            return token;
        }
    }
}
