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
            //DataTable dtblCustomer = new DataTable();
            //using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
           // {
              //  connection.Open();
                //SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * From Table2",connection);
                //sqlDa.Fill(dtblCustomer);
           // }
            var customerRepo = new CustomerRepository();
            return View(customerRepo.GetCustomers());
        }

       

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Customer());
        }

        // POST: Stathis2/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stathis2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stathis2/Edit/5
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

        // GET: Stathis2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stathis2/Delete/5
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
