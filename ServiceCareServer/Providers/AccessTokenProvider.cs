using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WEB_API.Models;
using WEB_API.Repository;

namespace WEB_API.Providers
{
    public class AccessTokenProvider : OAuthAuthorizationServerProvider
    {

        AuthRepository _auth = new AuthRepository();
        public override async Task ValidateClientAuthentication (OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task  GrantResourceOwnerCredentials (OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            List<UserModel> user = _auth.AuthenticateUser(context.UserName, context.Password);

            int userLength = user.Count();

            if (userLength > 0)
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, user[userLength-1].username));
                foreach (var modid in user)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, modid.modid.ToString().Trim()));
                }
                await Task.Run(() => context.Validated(identity));
            }
            else
            {
                context.Response.StatusCode = 403;
                context.SetError("Incorrect username and password. Please try again.");
            }
        }
    }
}