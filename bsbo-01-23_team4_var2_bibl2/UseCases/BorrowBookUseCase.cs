using bsbo_01_23_team4_var2_bibl2.Domain;
using bsbo_01_23_team4_var2_bibl2.Repository;

namespace bsbo_01_23_team4_var2_bibl2.UseCases;

public class BorrowBookUseCase
{
    private readonly ILibraryRepository _repository;

    public BorrowBookUseCase(ILibraryRepository repository)
    {
        _repository = repository;
    }

    public void Execute()
    {
        Console.Write("Введите ID книги: ");
        if (!int.TryParse(Console.ReadLine(), out int bookId)) return;

        var book = _repository.GetBookById(bookId);
        if (book == null)
        {
            Console.WriteLine("Книга не найдена.");
            return;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine("Книга уже выдана.");
            return;
        }

        Console.Write("Введите ID читателя: ");
        if (!int.TryParse(Console.ReadLine(), out int readerId)) return;

        var reader = _repository.GetReaderById(readerId);
        if (reader == null)
        {
            Console.WriteLine("Читатель не найден.");
            return;
        }

        book.MarkAsBorrowed();
        _repository.UpdateBook(book);

        var loan = new Loan(book.Id, reader.Id);
        _repository.AddLoan(loan);

        Console.WriteLine($"Книга \"{book.Title}\" выдана читателю {reader.Name}.");
    }
}