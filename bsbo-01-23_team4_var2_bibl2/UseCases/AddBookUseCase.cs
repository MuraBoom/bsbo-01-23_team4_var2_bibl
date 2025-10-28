using bsbo_01_23_team4_var2_bibl2.Domain;
using bsbo_01_23_team4_var2_bibl2.Repository;

namespace bsbo_01_23_team4_var2_bibl2.UseCases;

public class AddBookUseCase
{
    private readonly ILibraryRepository _repository;

    public AddBookUseCase(ILibraryRepository repository)
    {
        _repository = repository;
    }

    public void Execute()
    {
        Console.Write("Введите название книги: ");
        string? title = Console.ReadLine();
        Console.Write("Введите автора: ");
        string? author = Console.ReadLine();

        int newId = _repository.GetAllBooks().Any() ? _repository.GetAllBooks().Max(b => b.Id) + 1 : 1;

        var book = new Book(newId, title ?? "Без названия", author ?? "Неизвестен");
        _repository.AddBook(book);

        Console.WriteLine($"Книга \"{book.Title}\" успешно добавлена.");
    }
}