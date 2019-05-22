using CRM.DAL;
using CRM.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
   public class NoteBLL
    {
        DataContext db = new DataContext();
        public List<Note> GetNotes()
        {
            return db.Notes.ToList();
        }

        public Note GetNote(int Id)
        {
            return db.Notes.Where(x => x.NoteID == Id).FirstOrDefault();
        }

        public List<Note> GetCustomerNotes(int customerID)
        {
            return db.Notes.Where(x => x.CustomerID == customerID).ToList();
        }

        public void AddNote(Note notes)
        {
        //    Note note = new Note();
        //    note.CustomerID = cust.CustomerID;
        //    note.EmployeeID = employee.EmployeeID;
        //    note.NoteName = notes.NoteName;
        //    note.Status = notes.Status;
        //    note.Detail = notes.Detail;
        //    note.DateTime = DateTime.Now;
            db.Notes.Add(notes);
            db.SaveChanges();
        }

        public void Update(Note notes)
        {
            Note note = db.Notes.Where(x => x.NoteID == notes.NoteID).FirstOrDefault();
            note.DateTime = notes.DateTime;
            db.SaveChanges();
        }
        public void Delete(int Id)
        {
            Note note = db.Notes.Where(x => x.NoteID == Id).FirstOrDefault();
            db.Notes.Remove(note);
            db.SaveChanges();
        }
    }
}
