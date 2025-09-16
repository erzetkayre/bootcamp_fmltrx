using System.Text;

class Program
{
    static void Main()
    {
        int num = int.Parse("1231");

        if (int.TryParse("1213", out int nums))
        {
            Console.WriteLine($"Parse successfull {nums}");
        }

        if (!int.TryParse("121s3", out int nums2))
        {
            Console.WriteLine($"Parse unsuccessful");
        }

        Note note = new Note(10);
        Note newNote = note + 2;

        // Console.Write($"{note} + 2 = {newNote}");

    }
    public struct Note
    {
        int value;
        public Note(int seminotesA) { value = seminotesA; }

        public static Note operator +(Note x, int seminotes)
        {
            return new Note(x.value + seminotes);
        }    
    }
}