using bsbo_01_23_team4_var2_bibl2.Domain;

namespace bsbo_01_23_team4_var2_bibl2.Repository;

public class InMemoryLibraryRepository : ILibraryRepository
{
    private readonly List<Book> _books = new();
    private readonly List<Reader> _readers = new();
    private readonly List<Loan> _loans = new();

    private static readonly Lazy<InMemoryLibraryRepository> _instance =
        new(() => new InMemoryLibraryRepository());

    public static InMemoryLibraryRepository Instance => _instance.Value;

    private InMemoryLibraryRepository() { }

    public IEnumerable<Book> GetAllBooks() => _books;
    public IEnumerable<Reader> GetAllReaders() => _readers;
    public IEnumerable<Loan> GetAllLoans() => _loans;

    public Book? GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);
    public Reader? GetReaderById(int id) => _readers.FirstOrDefault(r => r.Id == id);
    public Loan? GetActiveLoanByBookId(int bookId) => _loans.FirstOrDefault(l => l.BookId == bookId && l.IsActive);

    public void AddBook(Book book) => _books.Add(book);
    public void AddReader(Reader reader) => _readers.Add(reader);
    public void AddLoan(Loan loan) => _loans.Add(loan);

    public void UpdateBook(Book book) { }
    public void UpdateLoan(Loan loan) { }

    public void RemoveBook(Book book) => _books.Remove(book);
}