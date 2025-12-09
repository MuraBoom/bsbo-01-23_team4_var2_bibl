using bsbo_01_23_team4_var2_bibl2.Repository;
using bsbo_01_23_team4_var2_bibl2.Data;

namespace bsbo_01_23_team4_var2_bibl2;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== ИНФОРМАЦИОННАЯ СИСТЕМА БИБЛИОТЕКИ ===\n");

        var library = new Library.Library(
            InMemoryBookRepository.Instance,
            InMemoryReaderRepository.Instance,
            InMemoryLoanRepository.Instance
        );

        TestDataSeeder.Seed(library);

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1 - Выдать книгу");
            Console.WriteLine("2 - Вернуть книгу");
            Console.WriteLine("3 - Добавить книгу в ячейку");
            Console.WriteLine("4 - Списать книгу");
            Console.WriteLine("5 - Показать каталог");
            Console.WriteLine("6 - Показать читателей");
            Console.WriteLine("0 - Выход");
            Console.Write("Выберите: ");

            switch (Console.ReadLine())
            {
                case "1":
                    IssueBook(library);
                    break;
                case "2":
                    ReturnBook(library);
                    break;
                case "3":
                    AddBook(library);
                    break;
                case "4":
                    WriteOffBook(library);
                    break;
                case "5":
                    library.PrintCatalog();
                    break;
                case "6":
                    library.PrintReaders();
                    break;
                case "0":
                    Console.WriteLine("До свидания!");
                    return;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

    private static void IssueBook(Library.Library library)
    {
        Console.Write("Введите ID книги: ");
        if (!int.TryParse(Console.ReadLine(), out var bookId)) return;

        Console.Write("Введите ID читателя: ");
        if (!int.TryParse(Console.ReadLine(), out var readerId)) return;

        try
        {
            library.IssueBook(bookId, readerId);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    private static void ReturnBook(Library.Library library)
    {
        Console.Write("Введите ID книги: ");
        if (!int.TryParse(Console.ReadLine(), out var bookId)) return;

        try
        {
            library.ReturnBook(bookId);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    private static void AddBook(Library.Library library)
    {
        Console.Write("Введите ID ячейки: ");
        if (!int.TryParse(Console.ReadLine(), out var cellId)) return;

        Console.Write("Введите название книги: ");
        var title = Console.ReadLine();

        Console.Write("Введите автора книги: ");
        var author = Console.ReadLine();

        try
        {
            library.AddBookToCell(cellId, title ?? "Без названия", author ?? "Неизвестен");
            Console.WriteLine("Книга успешно добавлена.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    private static void WriteOffBook(Library.Library library)
    {
        Console.Write("Введите ID книги: ");
        if (!int.TryParse(Console.ReadLine(), out var bookId)) return;

        try
        {
            library.WriteOffBook(bookId);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}
