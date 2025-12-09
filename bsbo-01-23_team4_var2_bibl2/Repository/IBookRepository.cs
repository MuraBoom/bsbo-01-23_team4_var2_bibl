using bsbo_01_23_team4_var2_bibl2.Domain.Components;

namespace bsbo_01_23_team4_var2_bibl2.Repository;

public interface IBookRepository
{
    IEnumerable<Book> GetAllBooks();
    Book? GetBookById(int id);
    void AddBook(Book book);
    void RemoveBook(Book book);
    void UpdateBook(Book book);
}