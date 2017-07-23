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
using FluentValidation.Validators;
using webcustomer.Validation;
using FluentValidation.Results;
using FluentValidation.Mvc;

namespace webcustomer.Controllers
{
    public class Stathis2Controller : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if(Session["username"] == null)
            {
                return RedirectToAction("Login","Login");
            }
            else
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
        }

       

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                Customer model = new Customer();
                //CustomerViewModelValidator validator = new CustomerViewModelValidator();
                //ValidationResult results = validator.Validate(model);
                //results.AddToModelState(ModelState, null);
                return View(model);
            }                      
        }

        // POST: Stathis2/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                CustomerViewModelValidator validator = new CustomerViewModelValidator();
                ValidationResult result = validator.Validate(customer);
                if (result.IsValid)
                {
                    //ViewBag.Name = model.Name;
                    //ViewBag.Email = model.Email;
                    var customerRepo = new CustomerRepository();
                    customerRepo.Insert(customer);
                    return RedirectToAction("Index");
                }
                else
                {                    
                    result.AddToModelState(ModelState, null);
                    return View();
                    //return RedirectToAction("Create");
                }

               
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customerRepo = new CustomerRepository();
                return View(customerRepo.GetById(id));//return customer
            }           
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
