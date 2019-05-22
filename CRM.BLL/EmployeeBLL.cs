using CRM.DAL;
using CRM.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
   public class EmployeeBLL
    {
        DataContext db = new DataContext();
        public List<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }
        public Employee GetEmployee(string username)
        {
            return db.Employees.Where(x=>x.UserName==username).FirstOrDefault();
        }
        public Employee GetEmployee(int ID)
        {
            return db.Employees.Where(x => x.EmployeeID == ID).FirstOrDefault();
        }

    }
}
