namespace bsbo_01_23_team4_var2_bibl2.Domain.Components;

public class Book : LibraryComponent
{
    public string Author { get; }
    public bool IsAvailable { get; private set; } = true;

    public Book(int id, string title, string author)
        : base(id, title)
    {
        Author = author;
    }

    public void MarkAsBorrowed() => IsAvailable = false;
    public void MarkAsReturned() => IsAvailable = true;

    public override void PrintInfo()
        => Console.WriteLine($"      Книга [{Id}] \"{Name}\" — {Author} | {(IsAvailable ? "Доступна" : "Выдана")}");

    public override void Add(LibraryComponent component)
        => throw new InvalidOperationException("Нельзя добавить дочерний элемент в книгу.");
}