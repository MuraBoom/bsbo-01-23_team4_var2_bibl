using bsbo_01_23_team4_var2_bibl2.Domain;
    
namespace bsbo_01_23_team4_var2_bibl2.Repository;

public interface ILibraryRepository
{
    IEnumerable<Book> GetAllBooks();
    IEnumerable<Reader> GetAllReaders();
    IEnumerable<Loan> GetAllLoans();

    Book? GetBookById(int id);
    Reader? GetReaderById(int id);
    Loan? GetActiveLoanByBookId(int bookId);

    void AddBook(Book book);
    void AddReader(Reader reader);
    void AddLoan(Loan loan);
    void UpdateBook(Book book);
    void UpdateLoan(Loan loan);
    void RemoveBook(Book book);
}
