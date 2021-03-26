using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Filters
{
    public class AuthorizeAttribute : IAuthorizationFilter
    {
        private static List<Role> roles = new List<Role>(){
            new Role(){RoleId = 1, RoleName = "admin"},
            new Role(){RoleId = 2, RoleName = "member"}
        };
        private readonly string _permission;
        public AuthorizeAttribute(string permission)
        {
            _permission = permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }
}