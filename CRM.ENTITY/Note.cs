namespace CRM.ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Note
    {
        public int NoteID { get; set; }

        public int CustomerID { get; set; }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string NoteName { get; set; }

        [Required]
        [StringLength(250)]
        public string Detail { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
