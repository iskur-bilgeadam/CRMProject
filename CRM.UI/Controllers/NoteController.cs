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
    public class NoteController : Controller
    {
        // GET: Note
        NoteBLL noteBLL = new NoteBLL();
        CustomerBLL customerBLL = new CustomerBLL();
        EmployeeBLL employeeBLL = new EmployeeBLL();

        [MyAuthenticationFilter]
        public ActionResult Index()
        {
            Customer customer = Session["Customer"] as Customer;
            List<Note> notes = noteBLL.GetCustomerNotes(customer.CustomerID);
            return View(notes);
        }

        [MyAuthenticationFilter]
        public ActionResult AddNote()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddNote(Note note)
        {           
            Employee emp = Session["Login"] as Employee;
            Customer cust = Session["Customer"] as Customer;
            note.CustomerID = cust.CustomerID;
            note.EmployeeID = emp.EmployeeID;
            note.DateTime = DateTime.Now;
            noteBLL.AddNote(note);
            return RedirectToAction("Detail","Customer", new { id=cust.CustomerID});
        }

        [MyAuthenticationFilter]
        public ActionResult Delete(int Id)
        {
            noteBLL.Delete(Id);
            return RedirectToAction("Index");
        }

        [MyAuthenticationFilter]
        public ActionResult Update(int Id)
        {
            Note note = noteBLL.GetNote(Id);
            return View(note);
        }

        [HttpPost]
        public ActionResult Update(Note note)
        {
            Note notes = noteBLL.GetNote(note.NoteID);
            Customer cust = Session["Customer"] as Customer;
            Employee emp = Session["Login"] as Employee;
            notes.CustomerID = cust.CustomerID;
            notes.NoteName = note.NoteName;
            notes.Detail = note.Detail;
            notes.Status = note.Status;           
            noteBLL.Update(notes);
            return RedirectToAction("Index");
        }
    }
}