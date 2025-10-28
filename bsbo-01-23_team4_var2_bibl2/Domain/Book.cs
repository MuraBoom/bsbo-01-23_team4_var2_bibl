namespace bsbo_01_23_team4_var2_bibl2.Domain;

public class Book
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public bool IsAvailable { get; private set; } = true;

    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }

    public void MarkAsBorrowed() => IsAvailable = false;
    public void MarkAsReturned() => IsAvailable = true;
}
