using System;
using System.Collections.Generic;

namespace homework4
{
   class NotesStore
    {
        #region members and properties
        private List<Note> list = new List<Note>(); 
        private int Count {get; set;}
        private int ActiveNotes {get; set;}
        private int CompletedNotes {get; set;}
        #endregion

        #region methods
        public void AddNote(NoteState state, string name)
        {
            if (name.Length == 0)
            {
                Console.WriteLine("Name cannot be empty");
            }
            else if (Enum.IsDefined(typeof(NoteState), state))
            {
                Note note = new Note(state, name, DateTime.Now);
                list.Add(note);
                UpdateCounts(note, true);
            }
            else
            {
                Console.WriteLine($"Invalid state {state}");
            }
        }
        public List<Note> GetNotes(NoteState state)
        {
            if (Enum.IsDefined(typeof(NoteState), state))
            {
                List<Note> result = new List<Note>();
                this.list.ForEach(note => 
                {
                    if (state == note.noteState)
                    {
                        result.Add(note);
                    }
                });
                return result;
            }
            else
            {
                Console.WriteLine($"Invalid state {state}");
                return null;
            }        
        }
        public void DeleteNote(string name)
        {
           Object temp = new Object();
           this.list.ForEach(note => 
                {
                    if (name == note.name)
                    {
                        temp = note;
                    }
                });
            if(temp is Note t)
            {
                this.UpdateCounts(t);
                this.list.Remove(t);
            }
            else
            {
                Console.WriteLine("The note has not found.");
            }
        }
        # endregion
        #region helper methods
        public override string ToString()
        {
            Console.WriteLine($"You have {this.Count} notes");
            for (int i = 0; i < this.Count; i++)
            {
                Console.WriteLine($"note number: {i + 1}");
                Console.WriteLine($"name: {this.list[i].name}");
                Console.WriteLine($"state: {this.list[i].noteState}");
                Console.WriteLine($"created at: {this.list[i].createdAt}");
            }
            return "";
        }
        private void UpdateCounts(Note note, bool isAdded = false)
        {
            if (isAdded)
            {
                if (note.noteState == NoteState.active)
                {
                    this.ActiveNotes ++;
                }
                else if(note.noteState == NoteState.completed)
                {
                    this.CompletedNotes ++;
                }
                this.Count ++;
            }
            else
            {
                if (note.noteState == NoteState.active)
                {
                    this.ActiveNotes --;
                }
                else if(note.noteState == NoteState.completed)
                {
                    this.CompletedNotes --;
                }
                this.Count --;
            }
        }
        #endregion
    }
}