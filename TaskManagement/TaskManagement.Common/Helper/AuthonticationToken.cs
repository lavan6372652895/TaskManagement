using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using TaskManagement.Modal;

namespace TaskManagement.Common.Helper
{
    public static class AuthonticationToken
    {
        //private static IConfiguration _config ;

        //public Task<Userdto> DecodeJwtToken(string jwtToken)
        //{
        //    Userdto userd = new Userdto();
        //    if (jwtToken == null)
        //    {
        //        return Task.FromResult(userd);
        //    }
        //    try
        //    {
        //        jwtToken = Regex.Replace(jwtToken, "Bearer ", "", RegexOptions.IgnoreCase);
        //        var handler = new JwtSecurityTokenHandler();
        //        JwtSecurityToken token = handler.ReadToken(jwtToken) as JwtSecurityToken;
        //        if (token != null)
        //        {
        //            var claims = token.Claims.ToList();
        //            userd.userid = Convert.ToInt32(claims.First(x => x.Type == "userid").Value);
        //            userd.FirstName = claims.First(x => x.Type == "FirstName").Value;
        //            userd.LastName = claims.First(x => x.Type == "LastName").Value;
        //            userd.Email = claims.First(x => x.Type == "Email").Value;
        //            userd.gender = claims.First(x => x.Type == "gender").Value;
        //            userd.username = claims.First(x => x.Type == "UserName").Value;
        //            userd.userprofile = claims.First(x => x.Type == "userprofile").Value;
        //            return Task.FromResult(userd);
        //        }
        //        else
        //        {
        //            return Task.FromResult(userd);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Task.FromResult(userd);
        //    }
        //}


        
    }
}
