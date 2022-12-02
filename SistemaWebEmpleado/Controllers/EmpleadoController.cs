using Microsoft.AspNetCore.Mvc;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

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

        //---------------------------2daParte--------------------------//

        // GET: /empleado/Delete/id 
        [HttpGet]
        public ActionResult Delete(int id)
        {

            Empleado empleado = _context.Empleados.Find(id);


            return View("Delete", empleado);

        }

        //POST /empleado/delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }





        [HttpGet]
        public ActionResult Edit(int id)
        {

            Empleado empleado = _context.Empleados.Find(id);

            return View("Edit", empleado);

        }

        [HttpPost]
        public ActionResult Edit(Empleado empleado)
        {

            if (ModelState.IsValid)
            {

                _context.Entry(empleado).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);

        }


        //GET
        public ActionResult Details(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);

                return View(empleado);
           
        }
    }
}
