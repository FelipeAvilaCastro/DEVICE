using DEVICE.Web.Models;
using DEVICE.Web.Repos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DEVICE.Web.Controllers
{

    //[Authorize]
    public class SeguridadController : Controller
    {

        
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Index));
        }

        //[AllowAnonymous]
        
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(string codigo, string contrasena)
        //{
        //    Persona persona = await PersonaRepo.GetPersonaPorCredenciales(codigo, contrasena);
        //    if (persona != null)
        //    {
        //        return RedirectToAction("Dashboard", "Main", new { area = "Administrativo" });
        //    }

        //    return RedirectToAction(nameof(Login));
        //}



        [HttpPost]
        public async Task<ActionResult> Login(string codigo, string contrasena)
        {
            try
            {
                Persona persona = await PersonaRepo.GetPersonaPorCredenciales(codigo, contrasena);

                //validar si el user existe en la base de datos
                
                if (persona != null)
                {
                    var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,persona.Usuario),
                //new Claim(ClaimTypes.Role,user.perfil),
                new Claim(ClaimTypes.Sid,persona.Id.ToString())

            };
                    var claimsIdentity = new ClaimsIdentity(
                           claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    return RedirectToAction("Dashboard", "Main", new { area = "Administrativo" });

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario no existente, clave inválida o no vigente");
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return null;
            }
            return View();
        }




        public async Task<IActionResult> Logout()
        {

            #region snippet1
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            #endregion

            return RedirectToAction(nameof(Login));
        }



        //[Authorize]
        public IActionResult Privacy()
        {
            return View();
        }



    }
}
