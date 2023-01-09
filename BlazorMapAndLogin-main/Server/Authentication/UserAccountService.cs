namespace BlazorWasmAuthenticationAndAuthorization.Server.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _userAccountList;

        public UserAccountService()
        {
            _userAccountList = new List<UserAccount>
            {
                new UserAccount{ UserName = "admin", Password = "admin", Role = "Administrator" },
                new UserAccount{ UserName = "user", Password = "user", Role = "User" },
                new UserAccount{ UserName = "nishi", Password = "123", Role = "Administrator" },
                new UserAccount{ UserName = "fuji", Password = "123", Role = "Administrator" },
                new UserAccount{ UserName = "fuji", Password = "123", Role = "User" }
            };
        }

        public UserAccount? GetUserAccountByUserName(string userName)
        {
            return _userAccountList.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
