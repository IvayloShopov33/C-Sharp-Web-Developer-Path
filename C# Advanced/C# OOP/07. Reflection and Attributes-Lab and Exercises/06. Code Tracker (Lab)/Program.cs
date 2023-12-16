namespace AuthorProblem
{
    public class StartUp
    {
        [Author("Marcus")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}