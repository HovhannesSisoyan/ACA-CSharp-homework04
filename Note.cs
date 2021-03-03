using System;

namespace homework4
{
    struct Note
    {
        public NoteState noteState {get; set;}
        public string name {get; set;}
        public DateTime createdAt {get; set;}
        public Note(NoteState state, string name, DateTime date)
        {
            this.noteState = state;
            this.name = name;
            this.createdAt = date;
        } 
    }
}