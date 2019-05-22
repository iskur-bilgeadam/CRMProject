using CRM.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.UI.Models
{
    public class NoteModel
    {
        public string Tip { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime? DateTime { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
    }
}