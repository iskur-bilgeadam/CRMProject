using CRM.DAL;
using CRM.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
   public class LeadBLL
    {
        DataContext db = new DataContext();
        public List<Lead> GetLeads()
        {
            return db.Leads.ToList();
        }

        public List<Lead> GetCustomerLeads(int CustID)
        {
            return db.Leads.Where(x=>x.CustomerID==CustID).ToList();
        }
        public Lead GetLead(int LeadId)
        {
            return db.Leads.Where(x => x.LeadID == LeadId).FirstOrDefault();
        }

        public void AddLead(Lead lead)
        {
            db.Leads.Add(lead);
            db.SaveChanges();
        }
        public void Update(Lead leads)
        {
            Lead lead = db.Leads.Where(x => x.LeadID == leads.LeadID).FirstOrDefault();
            lead.Date = leads.Date;
            db.SaveChanges();
        }
        public void Delete(int Id)
        {
            Lead lead = db.Leads.Where(x => x.LeadID == Id).FirstOrDefault();
            db.Leads.Remove(lead);
            db.SaveChanges();
        }
    }
}
