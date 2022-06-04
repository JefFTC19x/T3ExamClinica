using System.Security.Claims;
using AppClinica.Entities.DB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppClinica.Controllers;

public class AuthController :Controller
{
    private DbEntities _dataBaseEntities;

    public AuthController(DbEntities DataBaseEntities)
    {
         _dataBaseEntities=DataBaseEntities;
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Login(string usuario, string password)
    {
        if (_dataBaseEntities.Usuarios.Any(x=>x.NUser ==usuario && x.password==password))
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,usuario),
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(claimsPrincipal);
            return RedirectToAction("Index", "Home");
        }
        ModelState.AddModelError("AuthError","Usuario y/o Contraseña Incorrecto");
        return View();
    }

    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }
    
}