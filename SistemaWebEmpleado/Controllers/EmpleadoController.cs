using Microsoft.AspNetCore.Mvc;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoDBContext _context;
        public EmpleadoController(EmpleadoDBContext context)
        {
            _context = context;
        }

        // GET: 
        public ActionResult Index()
        {
            List<Empleado> lista = _context.Empleados.ToList();
            return View("Index", lista);
        }

       
        [HttpGet]
        public IActionResult Create()
        {
            Empleado empleado = new Empleado();
            return View("Create", empleado);
        }
        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", empleado);
            }
            else
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpGet("/empleado/ListaPorTitulo/{titulo}")]
        // GET: /person/ListaPorTitulo/baas
        public IActionResult ListaPorTitulo(string titulo)
        {
            List<Empleado> lista = (from p in _context.Empleados
                                    where p.Titulo == titulo
                                    select p).ToList();
            return View("Index", lista);
        }
    }
}
