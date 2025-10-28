using bsbo_01_23_team4_var2_bibl2.Repository;

namespace bsbo_01_23_team4_var2_bibl2.UseCases;

public class ReturnBookUseCase
{
    private readonly ILibraryRepository _repository;

    public ReturnBookUseCase(ILibraryRepository repository)
    {
        _repository = repository;
    }

    public void Execute()
    {
        Console.Write("Введите ID книги: ");
        if (!int.TryParse(Console.ReadLine(), out int bookId)) return;

        var loan = _repository.GetActiveLoanByBookId(bookId);
        if (loan == null)
        {
            Console.WriteLine("Эта книга не числится выданной.");
            return;
        }

        loan.MarkAsReturned();
        _repository.UpdateLoan(loan);

        var book = _repository.GetBookById(bookId);
        if (book != null)
        {
            book.MarkAsReturned();
            _repository.UpdateBook(book);
        }

        Console.WriteLine("Книга успешно возвращена.");
    }
}