using bsbo_01_23_team4_var2_bibl2.Domain.Components;

namespace bsbo_01_23_team4_var2_bibl2.Repository;

public class InMemoryBookRepository : IBookRepository
{
    private readonly List<Book> _books = new();
    private static readonly Lazy<InMemoryBookRepository> _instance =
        new(() => new InMemoryBookRepository());

    public static InMemoryBookRepository Instance => _instance.Value;

    private InMemoryBookRepository() { }

    public IEnumerable<Book> GetAllBooks() => _books;

    public Book? GetBookById(int id)
        => _books.FirstOrDefault(b => b.Id == id);

    public void AddBook(Book book) => _books.Add(book);

    public void UpdateBook(Book book)
    {
    }

    public void RemoveBook(Book book) => _books.Remove(book);
}