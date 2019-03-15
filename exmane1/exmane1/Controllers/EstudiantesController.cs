using exmane1.Collections;
using exmane1.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exmane1.Controllers
{
    public class EstudiantesController : Controller
    {

        private ContextoMongo elContexto = new ContextoMongo();

        public ActionResult LasVistas(string id)
        {
            var estudiantes = elContexto.LosEstudiantes;

            var elEstudiante = estudiantes.Find<Estudiante>(a => a.carne == id).FirstOrDefault();
            return View(elEstudiante.visitas);
        }


        // GET: Estudiantes
        public ActionResult Index()
        {
            var estudiantes = elContexto.LosEstudiantes;
            var losEstudiantes = estudiantes.AsQueryable().OrderBy(a => a.carrera).ThenBy(a => a.nombre).ToList();
            return View(losEstudiantes);
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create
        [HttpPost]
        public ActionResult Create(Estudiante elEstudiante)
        {
            try
            {
                var estudiantes = elContexto.LosEstudiantes;
                elEstudiante.visitas = new List<Visitas>();
                //Visitas visitas = new Visitas();
                //visitas.nombre_biblioteca = "Fidelitas";

                estudiantes.InsertOne(elEstudiante);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estudiantes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estudiantes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
