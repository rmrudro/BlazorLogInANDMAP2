using BlazorWasmAuthenticationAndAuthorization.Server.Authentication;
using BlazorWasmAuthenticationAndAuthorization.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace BlazorWasmAuthenticationAndAuthorization.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserAccountService _userAccountService;

        public AccountController(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }
        //With JWT
        //[HttpPost]
        //[Route("Login")]
        //[AllowAnonymous]
        //public ActionResult<UserSession> Login([FromBody] LoginRequest loginRequest)
        //{
        //    var jwtAuthenticationManager = new JwtAuthenticationManager(_userAccountService);
        //    var userSession = jwtAuthenticationManager.GenerateJwtToken(loginRequest.UserName, loginRequest.Password);
        //    if (userSession is null)
        //        return Unauthorized();
        //    else
        //        return userSession;
        //}


        //With UserSessionOnly

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult<UserSession1> Login([FromBody] LoginRequest loginRequest)
        {
            var sessionauthmanager = new SessionAuthenticationManager(_userAccountService);
            var usersession = sessionauthmanager.GenerateSession(loginRequest.UserName,loginRequest.Password);
            if(usersession is null)
            
                return Unauthorized();
            
            else
            
                return usersession;
            
        
        }
    }
}
