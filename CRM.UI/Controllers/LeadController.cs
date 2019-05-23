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
    public class LeadController : Controller
    {
        LeadBLL leadBLL = new LeadBLL();
        CustomerBLL customerBLL = new CustomerBLL();
        EmployeeBLL employeeBLL = new EmployeeBLL();

        [MyAuthenticationFilter]
        public ActionResult Index()
        {
            Customer customer = Session["Customer"] as Customer;
            List<Lead> leads = leadBLL.GetCustomerLeads(customer.CustomerID);            
            return View(leads);
        }
        [MyAuthenticationFilter]
        public ActionResult AddLead()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddLead(Lead lead)
        {
            Employee emp = Session["Login"] as Employee;
            Customer cust = Session["Customer"] as Customer;
            lead.CustomerID = cust.CustomerID;
            lead.EmployeeID = emp.EmployeeID;
            lead.Date= DateTime.Now;
            leadBLL.AddLead(lead);
            return RedirectToAction("Detail","Customer",new { id=cust.CustomerID});
        }

        [MyAuthenticationFilter]
        public ActionResult Delete(int Id)
        {
            leadBLL.Delete(Id);
            return RedirectToAction("Index");
        }

        [MyAuthenticationFilter]
        public ActionResult Update(int Id)
        {
            Lead lead = leadBLL.GetLead(Id);
            return View(lead);
        }

        [HttpPost]
        public ActionResult Update(Lead lead)
        {
            Lead leads = leadBLL.GetLead(lead.LeadID);
            Customer cust = Session["Customer"] as Customer;
            Employee emp = Session["Login"] as Employee;
            leads.CustomerID = cust.CustomerID;
            leads.EmployeeID = emp.EmployeeID;
            leads.LeadTitle = lead.LeadTitle;
            leads.LeadDetail = lead.LeadDetail;
            leadBLL.Update(leads);
            return RedirectToAction("Detail", "Customer", new { id = cust.CustomerID });
        }
    }
}