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
    public class EmployeeController : Controller
    {
       
        EmployeeBLL employeeBLL = new EmployeeBLL();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Login(Employee emp)
        {
            Employee employee = employeeBLL.GetEmployee(emp.UserName);
            
                if (employee.Password == emp.Password)
                {
                    Session["Login"] = employee;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Hata","Home");
                }
        }

        [MyAuthenticationFilter]
        public ActionResult Logout()
        {
            Session["Login"] = null;
            return RedirectToAction("Login");
        }
    }
}