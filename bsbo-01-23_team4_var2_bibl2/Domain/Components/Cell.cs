namespace bsbo_01_23_team4_var2_bibl2.Domain.Components;

public class Cell : LibraryComponent
{
    public Book? Book { get; private set; }

    public Cell(int id, string name) : base(id, name) { }

    public override void Add(LibraryComponent component)
    {
        if (component is Book book)
        {
            if (Book is not null)
                throw new InvalidOperationException($"Ячейка уже содержит книгу: {Book.Name}");

            Book = book;
        }
        else
            throw new InvalidOperationException("В ячейку можно поместить только книгу.");
    }

    public override void Remove(LibraryComponent component)
    {
        if (component is Book && Book is not null)
            Book = null;
    }

    public override LibraryComponent? GetChild(int id)
        => Book is not null && Book.Id == id ? Book : null;

    public override void PrintInfo()
    {
        Console.WriteLine(Book is null
            ? $"    Ячейка [{Id}] {Name}: пусто"
            : $"    Ячейка [{Id}] {Name}: книга → [{Book.Id}] {Book.Name} ({Book.Author})");
    }
}