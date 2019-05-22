using CRM.DAL;
using CRM.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
   public  class CustomerBLL
    {
        DataContext db = new DataContext();
        public List<Customer> GetCustomers()
        {
            return db.Customers.ToList();
        }
        public Customer GetCustomer(int CustomerId)
        {
            return db.Customers.Where(x => x.CustomerID == CustomerId).FirstOrDefault();
        }
        public void Update(Customer customer)
        {
            Customer cust = db.Customers.FirstOrDefault(x => x.CustomerID == customer.CustomerID);

            db.SaveChanges();
        }

        public void AddCustomer(Customer customer)
        {
            Customer cust = new Customer();
            cust.FirstName = customer.FirstName;
            cust.LastName = customer.LastName;
            cust.Phone = customer.Phone;
            cust.Email = customer.Email;
            cust.City = customer.City;
            cust.Country = customer.Country;
            cust.Birthday = customer.Birthday;
            cust.Address = customer.Address;
            db.Customers.Add(cust);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            Customer cust = db.Customers.Where(x => x.CustomerID == Id).FirstOrDefault();
            db.Customers.Remove(cust);
            db.SaveChanges();
        }
    }
}
