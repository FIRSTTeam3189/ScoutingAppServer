using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net;
using System;
using FlipitServer.Interfaces;
using FlipitServer.SQLDataObjects;
using System.IdentityModel.Tokens;
using Microsoft.Azure.Mobile.Server.Login;
using System.Security.Claims;
using flipyserverService.Models;
using FlipitServer.Models;
using Microsoft.Azure.Mobile.Server.Config;
using FlipitServer.ClientData;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.WindowsAzure.Storage.Table;

namespace FlipitServer.Controllers {

    [MobileAppController]
    [RoutePrefix("api/accounts")]
    public class AccountController : ApiController {

        protected override void Initialize(HttpControllerContext controllerContext) {
            base.Initialize(controllerContext);
        }
        
        [Route("Register")]
        [ActionName("Register")]
        [Authorize]
        [HttpPost]
        public HttpResponseMessage Register(RegistrationRequest request) {
            MobileServiceContext context = new MobileServiceContext();

            string error = null;//RegisterCheck(request.Username, null, request.Email);
            if(error != null) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, error);
            } else {
                Account newAccount = new Account(User.Identity.GetUserId()) {
                    Username = request.Username,
                    Email = request.Email
                };
                context.Accounts.Add(newAccount);
                context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created);
            }
        }

        public static string RegisterCheck(string username, string email) {
            if(username.Length >= 4 && username.Length <= 16 && !Regex.IsMatch(username, "^[a-zA-Z0-9]{4,}$")) {
                return "Invalid username (at least 4 chars and less than 16, alphanumeric only)";
            }
            try {
                var addr = new System.Net.Mail.MailAddress(email);
            } catch {
                return "Invalid Email";
            }
            MobileServiceContext context = new MobileServiceContext();
            Account account = context.Accounts.Where(a => a.Username == username || a.Email == email).SingleOrDefault();
            if(account != null) {
                if(!string.IsNullOrWhiteSpace(account.Email) && account.Email == email) {
                    return "That email already exists.";
                } else if(!string.IsNullOrWhiteSpace(account.Username) && account.Username == username) {
                    return "That username already exists.";
                } /*else if(!string.IsNullOrWhiteSpace(account.Id) && account.Id == username) {
                    return "That account already ecists.";
                }*/
                //TODO fix the commented code.
            }
            return null;
        }
        
        [Route("IsRegistered")]
        [ActionName("IsRegistered")]
        [Authorize]
        [HttpPost]
        public bool IsUserRegistered() {
            MobileServiceContext context = new MobileServiceContext();
            var result = context.Accounts.Where(a => a.Id == User.Identity.GetUserId()).SingleOrDefault();
            if(result != null || string.IsNullOrWhiteSpace(result.Id)) {
                return false;
            }
            return true;
        }

        private JwtSecurityToken GetAuthenticationTokenForUser(string username) {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username)
            };

            var signingKey = Environment.GetEnvironmentVariable("WEBSITE_AUTH_SIGNING_KEY");
            var audience = "https://myservice.azurewebsites.net/"; // audience must match the url of the site
            var issuer = "https://myservice.azurewebsites.net/"; // audience must match the url of the site

            JwtSecurityToken token = AppServiceLoginHandler.CreateToken(
                claims,
                signingKey,
                audience,
                issuer,
                TimeSpan.FromHours(24)
            );

            return token;
        }

        [Authorize]
        [Route("GetMyAccount")]
        [ActionName("GetMyAccount")]
        [HttpPost]
        public ClientAccount GetMyAccount() {
            MobileServiceContext context = new MobileServiceContext();
            return GetAccount(context, User).GetClientAccount();
        }

        [Authorize]
        [Route("UsernameExists")]
        [ActionName("UsernameExists")]
        [HttpPost]
        public HttpResponseMessage UsernameExists(string un) {
            MobileServiceContext context = new MobileServiceContext();
            var thing = context.Accounts.Where(a => a.Username == un).SingleOrDefault();
            if(thing != null && thing.Id != null) {
                return Request.CreateResponse(HttpStatusCode.Found);
            }
            return Request.CreateResponse(HttpStatusCode.Unused);
        }

        /*[Authorize]
        [Route("ChangeRole")]
        [ActionName("ChangeRole")]
        [HttpPost]
        public HttpResponseMessage ChangeRole(ChangeRoleRequest request) {
            MobileServiceContext context = new MobileServiceContext();
            var account = GetAccount(context, User);
            if(account.role.IsDevLevel()) {
                var user = context.Accounts.Where(a => a.Id == request.UserId).SingleOrDefault();

                if(user != null) {
                    user.role.SetLevel(request.Level);
                    return Request.CreateResponse(HttpStatusCode.OK);
                } else {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Could not find User");
                }
            } else {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [Authorize]
        [Route("GetRole")]
        [ActionName("GetRole")]
        [HttpPost]
        public int GetRole(string UserId) {
            MobileServiceContext context = new MobileServiceContext();
            var account = GetAccount(context, User);
            if(account.role.IsModLevel()) {
                var user = context.Accounts.Where(a => a.Id == UserId).SingleOrDefault();

                if(user != null) {
                    return user.role.GetLevel();
                } else {
                    return -1;
                }
            } else {
                return -1;
            }
        }*/

        public static Account GetAccount(MobileServiceContext context, IPrincipal User) {
            System.Diagnostics.Trace.TraceError(User.Identity.GetUserId());
            return context.Accounts.Where(a => a.Id == User.Identity.GetUserId()).SingleOrDefault();
        }
    }
}