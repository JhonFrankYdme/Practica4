using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using peru_fails.Models;
using peru_fails.Data;

namespace peru_fails.Controllers
{
    public class FailController : Controller
    {

        private readonly ApplicationDbContext _context;

        public FailController(ApplicationDbContext db){
            _context=db;
        }


    public IActionResult ListaFail()
        {
            List<Fail> lista= Listar();
            return View(lista);
        }

        public List<Fail> Listar()
        {
            var listaFail= _context.Fails.ToList();
            List<Fail> lista= new List<Fail>();
            DateTime limitDate= DateTime.Today.AddDays(-7);

            foreach(Fail fail in listaFail)
            {
                if(DateTime.Compare(fail.fec_envio,limitDate)>=0)
                {
                    lista.Add(fail);
                }
            }

            return(lista);
        }

        public IActionResult RegistroFail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistroFail(Fail objFail)
        {
            objFail.fec_envio= DateTime.Today;
            if(ModelState.IsValid){
                _context.Add(objFail);
                _context.SaveChanges();
                return RedirectToAction("ListaFail");
            }
            return View(objFail);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}