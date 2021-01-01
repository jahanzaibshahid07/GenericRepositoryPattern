using GenericRepositoryPattern.Models;
using GenericRepositoryPattern.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenericRepositoryPattern.Controllers
{
    public class EmployeeController : Controller
    {
        private _IAllRepository<Employee> _employeedata;

        public EmployeeController()
        {
            _employeedata = new AllRepository<Employee>();
        }

        // GET: Employee
        public ActionResult Index()
        {
            var data = from n in _employeedata.GetaData() select n;
            return View(data);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var data = _employeedata.GetDataById(id);
            return View(data);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee collection)
        {
            try
            {
                // TODO: Add insert logic here
                _employeedata.InsertData(collection);
                _employeedata.SaveData();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _employeedata.GetDataById(id);
            return View(data);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee collection)
        {
            try
            {
                // TODO: Add update logic here
                _employeedata.UpdateData(id, collection);
                _employeedata.SaveData();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _employeedata.GetDataById(id);
            return View(data);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee collection)
        {
            try
            {
                // TODO: Add delete logic here
                _employeedata.DeleteData(id);
                _employeedata.SaveData();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
