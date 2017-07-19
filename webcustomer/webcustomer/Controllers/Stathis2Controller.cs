using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Stathis.Data;
using Stathis.Repository;

namespace webcustomer.Controllers
{
    public class Stathis2Controller : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var customerRepo = new CustomerRepository();
                return View(customerRepo.GetCustomers());
            }
            catch
            {
                return RedirectToAction("Index");
            }      
        }

       

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Customer());
        }

        // POST: Stathis2/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var customerRepo = new CustomerRepository();
                customerRepo.Insert(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customerRepo = new CustomerRepository();
            return View(customerRepo.GetById(id));//return customer
        }


        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                var customerRepo = new CustomerRepository();
                customerRepo.Update(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpDelete()]
        public ActionResult Delete(int id)
        {     
            try
            {
                var customerRepo = new CustomerRepository();
                customerRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
