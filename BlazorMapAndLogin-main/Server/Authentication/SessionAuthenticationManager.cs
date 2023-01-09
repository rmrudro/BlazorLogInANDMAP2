using BlazorWasmAuthenticationAndAuthorization.Shared;

namespace BlazorWasmAuthenticationAndAuthorization.Server.Authentication
{
    public class SessionAuthenticationManager
    {
        private UserAccountService _userAccountService;

        public SessionAuthenticationManager(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        public UserSession1? GenerateSession(string userName, string password)
        {
            if(string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password)) 
                return null;

            /* Validating the User Credentials */

            var userAccount = _userAccountService.GetUserAccountByUserName(userName);
            if (userAccount == null || userAccount.Password != password)
                return null;


            var session = new UserSession1
            {
                UserName = userAccount.UserName,
                Role = userAccount.Role
            };
            return session;
        }
    }
}
