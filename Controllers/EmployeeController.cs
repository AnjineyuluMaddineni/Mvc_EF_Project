using Mvc_EF_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_EF_Project.Controllers
{
    public class EmployeeController : Controller
    {
       private MVC_DBEntities dbContext = new MVC_DBEntities();
        // GET: Employee
        public ActionResult Index(string SearchBy,string Search)
        {
           
            //MVC_DBEntities dbContext = new MVC_DBEntities();
            //List<Employee> empList = dbContext.Employees.ToList();
            if (SearchBy == "Gender")
            {
                return View(dbContext.Employees.Where(x => x.Gender == Search ||Search==null).ToList());
            }
            else
            {
                return View(dbContext.Employees.Where(x => x.Name.StartsWith(Search) || Search == null).ToList());
            }

            //return View(empList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            MVC_DBEntities dbContext = new MVC_DBEntities();

            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(emp);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }
        public ActionResult Details(Int32 id = 0)
        {
            MVC_DBEntities dbContext = new MVC_DBEntities();
            Employee emp = dbContext.Employees.Find(id);
            if (emp != null)
            {
                return View(emp);
            }
            else
            {
                return HttpNotFound("Employee Not found !!!");
            }
        }

        //Get: /Employee/Edit
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            MVC_DBEntities dbContext = new MVC_DBEntities();
            if (ModelState.IsValid)
            {
                dbContext.Entry(emp).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }
        //POST: /Employee/Edit/1
        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            MVC_DBEntities dbContext = new MVC_DBEntities();
            Employee emp = dbContext.Employees.Find(id);
            if (emp != null)
            {
                return View(emp);
            }
            else
            {
                return HttpNotFound("Employee Not found !!!");
            }
        }
        public ActionResult Delete(int id = 0)
        {
            MVC_DBEntities dbContext = new MVC_DBEntities();
            Employee emp = dbContext.Employees.Find(id);

            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MVC_DBEntities dbContext = new MVC_DBEntities();
            Employee emp = dbContext.Employees.Find(id);

            dbContext.Employees.Remove(emp);

            dbContext.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}