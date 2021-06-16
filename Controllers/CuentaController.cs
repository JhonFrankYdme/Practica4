using Microsoft.Extensions.Logging;
using peru_fails.Models;
using peru_fails.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace peru_fails.Controllers
{
    public class CuentaController : Controller
    {
        private readonly UserManager<IdentityUser> _um;
        private readonly SignInManager<IdentityUser> _sim;
        public CuentaController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            _um = um;
            _sim = sim;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string nombre, string password)
        {
            var result = _sim.PasswordSignInAsync(nombre, password, false, false).Result;

            if (result.Succeeded) {
                return RedirectToAction("index", "Home");
            } 

            ModelState.AddModelError("", "Usuario y/o contraseña incorrectos");

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _sim.SignOutAsync();

            return RedirectToAction("Login", "Cuenta");
        }

        

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(string nombre, string correo, string password)
        {
            var user = new IdentityUser();
            user.Email = correo;
            user.UserName = nombre;

            var result = _um.CreateAsync(user, password).Result;

            if (result.Succeeded) {
                return RedirectToAction("Login", "Cuenta");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }
    }
}            