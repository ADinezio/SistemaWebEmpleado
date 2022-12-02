using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        {
            return View(_context.Empleados.ToList());
        }



        //:GET Empleado/Create
        [HttpGet]
        public IActionResult Create()
        {
            Empleado empleado= new Empleado();
            return View("Create",empleado);
        }

        //:GET Empleado/Create
        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if(ModelState.IsValid)
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return View("Create",empleado);
               
            }
        }

        public IActionResult EmpleadoXTitulo(string titulo)
        {
            List<Empleado> list = BuscaTitulo(titulo);
            if(list == null)
            {
                return NotFound();  
            }
            else
            {
                return View("Index",list);
            }
            
        }

        [NonAction]
        public List<Empleado> BuscaTitulo(string titulo) 
        {
            List<Empleado> list = (from t in _context.Empleados
                                   where t.Titulo.ToUpper() == titulo.ToUpper()
                                   select t).ToList();
            return list;
        }

        //GET: Empleado/Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);

            if (empleado == null) return NotFound();
            return View("Modificar", empleado);
        }

        //POST: Empleado/Edit
        [HttpPost]
        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(empleado).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Modificar");

        }

        //GET: Empleado/Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            if (empleado == null) return NotFound();
            return View("Detalle", empleado);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View("Eliminar", empleado);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
