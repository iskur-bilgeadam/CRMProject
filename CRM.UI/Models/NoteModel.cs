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
        public int Id { get; set; }
        public Note Note { get; set; }       
        public Lead Lead { get; set; }
        
    }
}