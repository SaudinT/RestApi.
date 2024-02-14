public class ToDoItem
{
    public int Id { get; set; } // Primarni ključ
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public bool Completed { get; set; }
    public bool Deleted { get; set; }
}
