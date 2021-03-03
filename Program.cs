using System;

namespace homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            NotesStore noteStore = new NotesStore();
            noteStore.AddNote(NoteState.active, "Learn C#");
            noteStore.AddNote(NoteState.completed, "Do homework 4");
            noteStore.AddNote(NoteState.completed, "Do homework 3");
            Console.WriteLine(noteStore);
            System.Console.WriteLine("Completed notes are:");
            noteStore.GetNotes(NoteState.completed).ForEach(item => 
            {
                System.Console.WriteLine(item.name);
            }
            );
            System.Console.WriteLine();
            noteStore.DeleteNote("Do homework 4");
            noteStore.DeleteNote("Do homework 3");
            Console.WriteLine(noteStore);

            int[] res = Matrix.MultMatrix(2, 3, new int[] {1, 2, 3, 4, 5, 6}, 3, 2, new int[] { 7, 8, 9, 10, 11, 12});
            Matrix.ToString(2, 2, res);
        }
    }
}
