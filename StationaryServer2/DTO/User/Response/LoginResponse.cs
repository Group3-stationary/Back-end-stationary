using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationaryServer2.DTO.User.Response
{
    public class LoginResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string RequestToken { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
    }
}
