using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;


namespace AuthencationApp
{
    public class MyAuthoriztionServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); //validate the user
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identiy = new ClaimsIdentity(context.Options.AuthenticationType);

            if (context.UserName == "admin" && context.Password == "admin")
            {
                identiy.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identiy.AddClaim(new Claim("username", "admin"));
                identiy.AddClaim(new Claim(ClaimTypes.Name, "Emma_admin"));
                context.Validated(identiy);
            } else if (context.UserName == "user" && context.Password == "user") {

                identiy.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identiy.AddClaim(new Claim("username", "user"));
                identiy.AddClaim(new Claim(ClaimTypes.Name, "Emma_user"));
                context.Validated(identiy);
            }
            else {
                context.SetError("invalida_grant", "Provide username and password is incorrect");
                    return;
                
            }
        }
    }
}