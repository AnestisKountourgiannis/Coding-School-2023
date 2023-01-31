namespace ClassLibrary1
{
    public class Todo
    {
        public Todo(string title)
        {
            Title = title;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Finished { get; set; }
    }
}