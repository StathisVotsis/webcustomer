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
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customerRepo = new CustomerRepository();
            return View(customerRepo.GetById(id));//return customer
        }

        // POST: Stathis2/Edit/5
        [HttpPut]
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
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var customerRepo = new CustomerRepository();
            customerRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
