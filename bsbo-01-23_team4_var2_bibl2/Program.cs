namespace bsbo_01_23_team4_var2_bibl2;

using Repository;
using UseCases;
using Data;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("БИБЛИОТЕКА\n");

        ILibraryRepository repository = InMemoryLibraryRepository.Instance;

        TestDataSeeder.Seed(repository);

        while (true)
        {
            Console.WriteLine("\n1 - Выдать книгу");
            Console.WriteLine("2 - Вернуть книгу");
            Console.WriteLine("3 - Добавить книгу");
            Console.WriteLine("4 - Списать книгу");
            Console.WriteLine("5 - Показать все книги");
            Console.WriteLine("6 - Показать всех читателей");
            Console.WriteLine("0 - Выход из программы");
            Console.Write("Выберите: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BorrowBookUseCase(repository).Execute();
                    break;
                case "2":
                    new ReturnBookUseCase(repository).Execute();
                    break;
                case "3":
                    new AddBookUseCase(repository).Execute();
                    break;
                case "4":
                    new WriteOffBookUseCase(repository).Execute();
                    break;
                case "5":
                    PrintAllBooks(repository);
                    break;
                case "6":
                    PrintAllReaders(repository);
                    break;
                case "0":
                    Console.WriteLine("Пока-пока!");
                    return;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

    static void PrintAllBooks(ILibraryRepository repository)
    {
        Console.WriteLine("\nКаталог книг:");
        foreach (var book in repository.GetAllBooks())
        {
            Console.WriteLine($"[{book.Id}] {book.Title} — {book.Author} | {(book.IsAvailable ? "Доступна" : "Выдана")}");
        }
    }

    static void PrintAllReaders(ILibraryRepository repository)
    {
        Console.WriteLine("\nЧитатели в системе:");
        foreach (var reader in repository.GetAllReaders())
        {
            Console.WriteLine($"[{reader.Id}] - {reader.Name}");
        }
    }
}
