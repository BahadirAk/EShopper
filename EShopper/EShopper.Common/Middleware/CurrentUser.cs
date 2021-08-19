using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace EShopper.Common.Middleware
{
    public class CurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid Id
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(r => r.Type == "Id").Value;
                return Guid.Parse(userId);
            }
        }
    }
}
