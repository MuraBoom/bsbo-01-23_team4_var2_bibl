using bsbo_01_23_team4_var2_bibl2.Repository;

namespace bsbo_01_23_team4_var2_bibl2.UseCases;

public class WriteOffBookUseCase
{
    private readonly ILibraryRepository _repository;

    public WriteOffBookUseCase(ILibraryRepository repository)
    {
        _repository = repository;
    }

    public void Execute()
    {
        Console.Write("Введите ID книги для списания: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        var book = _repository.GetBookById(id);
        if (book == null)
        {
            Console.WriteLine("Книга не найдена.");
            return;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine("Нельзя списать книгу, которая сейчас выдана.");
            return;
        }

        _repository.RemoveBook(book);
        Console.WriteLine($"Книга \"{book.Title}\" списана из фонда.");
    }
}