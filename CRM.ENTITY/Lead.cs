namespace CRM.ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lead
    {
        public int LeadID { get; set; }

        public int CustomerID { get; set; }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(250)]
        public string LeadDetail { get; set; }
        [Required]
        [StringLength(50)]
        public string LeadTitle { get; set; }

        public DateTime Date { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
