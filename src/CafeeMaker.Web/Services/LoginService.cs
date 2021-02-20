// ReSharper disable AssignNullToNotNullAttribute
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace CafeeMaker.Web.Services {

    public class LoginService : ILoginService {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task SignInAsync(IEnumerable<Claim> claims) {
            EnsureHttpContextIsAvailable();
            return _httpContextAccessor.HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme)));
        }

        public Task SignOutAsync() {
            EnsureHttpContextIsAvailable();
            return _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private void EnsureHttpContextIsAvailable() {
            if (_httpContextAccessor.HttpContext is null)
                throw new InvalidOperationException("The HttpContext is null.");
        }

    }

}