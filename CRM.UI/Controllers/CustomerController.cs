using CRM.BLL;
using CRM.ENTITY;
using CRM.UI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CustomerBLL customerBLL = new CustomerBLL();
        LeadBLL leadBLL = new LeadBLL();
        NoteBLL noteBLL = new NoteBLL();
        [MyAuthenticationFilter]
        public ActionResult Index()
        {
            List<Customer> customers = customerBLL.GetCustomers();
            Employee emp = Session["Login"] as Employee;
            foreach (EmployeesRole item in emp.EmployeesRoles)
            {
                if (item.Role.RoleName == "Admin")
                {
                    ViewBag.Delete = "visible";
                }
                else if (item.Role.RoleName == "Manager")
                {
                    ViewBag.Delete = "visible";
                }
                else
                {
                    ViewBag.Delete = "hidden";
                }
            }
            return View(customers);
        }

        [MyAuthenticationFilter]
        public ActionResult Update(int Id)
        {
            Customer cust = customerBLL.GetCustomer(Id);
            return View(cust);
        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            Customer cust = customerBLL.GetCustomer(customer.CustomerID);
            cust.Address = customer.Address;
            cust.Birthday = customer.Birthday;
            cust.City = customer.City;
            cust.Country = customer.Country;
            cust.FirstName = customer.FirstName;
            cust.LastName = customer.LastName;
            cust.Phone = customer.Phone;
            cust.Email = customer.Email;
            customerBLL.Update(cust);
            return RedirectToAction("Index");
        }

        [MyAuthenticationFilter]
        public ActionResult AddCustomer()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer cust)
        {
            customerBLL.AddCustomer(cust);
            return RedirectToAction("Index");
        }

        [MyAuthenticationFilter]
        public ActionResult Delete(int Id)
        {
            List<Lead> leads = leadBLL.GetCustomerLeads(Id);
            List<Note> notes = noteBLL.GetCustomerNotes(Id);

            foreach (Lead item in leads)
            {
                leadBLL.Delete(item.LeadID);
            }
            foreach (Note item in notes)
            {
                noteBLL.Delete(item.NoteID);
            }
            customerBLL.Delete(Id);
            return RedirectToAction("Index");
        }

        [MyAuthenticationFilter]
        public ActionResult Detail(int Id)
        {
            Customer cust = customerBLL.GetCustomer(Id);
            Session["Customer"] = cust;
            return View(cust);
        }
    }
}