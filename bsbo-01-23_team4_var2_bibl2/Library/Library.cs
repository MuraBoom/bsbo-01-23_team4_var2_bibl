using System.Reflection;
using bsbo_01_23_team4_var2_bibl2.Domain;
using bsbo_01_23_team4_var2_bibl2.Domain.Components;
using bsbo_01_23_team4_var2_bibl2.Repository;

namespace bsbo_01_23_team4_var2_bibl2.Library;

public class Library
{
    private readonly IBookRepository _bookRepo;
    private readonly ILoanRepository _loanRepo;
    private readonly IReaderRepository _readerRepo;

    private int _nextBookId = 1;

    public Library(IBookRepository bookRepo, IReaderRepository readerRepo, ILoanRepository loanRepo)
    {
        _bookRepo = bookRepo;
        _readerRepo = readerRepo;
        _loanRepo = loanRepo;

        Catalog = new Catalog(1, "Основной каталог");
    }

    public Catalog Catalog { get; }

    public void AddShelf(int id, string name)
        => Catalog.Add(new Shelf(id, name));

    public void AddCellToShelf(int shelfId, int cellId, string name)
    {
        if (Catalog.GetChild(shelfId) is not Shelf shelf)
            throw new Exception("Шкаф не найден");

        shelf.Add(new Cell(cellId, name));
    }

    public void AddBookToCell(int cellId, string title, string author)
    {
        var id = GenerateBookId();
        var book = new Book(id, title, author);

        _bookRepo.AddBook(book);

        var cell = FindCellById(cellId);
        cell.Add(book);
    }

    public void IssueBook(int bookId, int readerId)
    {
        var book = _bookRepo.GetBookById(bookId)
                   ?? throw new Exception("Книга не найдена");

        if (!book.IsAvailable)
            throw new Exception("Книга уже выдана");

        var reader = _readerRepo.GetReaderById(readerId)
                     ?? throw new Exception("Читатель не найден");

        book.MarkAsBorrowed();
        _bookRepo.UpdateBook(book);

        var loan = new Loan(bookId, readerId);
        _loanRepo.AddLoan(loan);

        Console.WriteLine($"Книга \"{book.Name}\" выдана читателю {reader.Name}.");
    }

    public void ReturnBook(int bookId)
    {
        var loan = _loanRepo.GetActiveLoanByBookId(bookId)
                   ?? throw new Exception("Книга не числится выданной");

        loan.MarkAsReturned();
        _loanRepo.UpdateLoan(loan);

        var book = _bookRepo.GetBookById(bookId)!;
        book.MarkAsReturned();
        _bookRepo.UpdateBook(book);

        Console.WriteLine($"Книга \"{book.Name}\" успешно возвращена.");
    }

    public void WriteOffBook(int bookId)
    {
        var book = _bookRepo.GetBookById(bookId)
                   ?? throw new Exception("Книга не найдена");

        if (!book.IsAvailable)
            throw new Exception("Нельзя списать книгу, пока она выдана");

        RemoveBookFromComposite(bookId);
        _bookRepo.RemoveBook(book);

        Console.WriteLine($"Книга \"{book.Name}\" списана из фонда.");
    }

    public void PrintCatalog()
        => Catalog.PrintInfo();

    public void AddReader(int id, string name)
        => _readerRepo.AddReader(new Reader(id, name));

    private int GenerateBookId() => _nextBookId++;

    private Cell FindCellById(int cellId)
    {
        foreach (var shelfComp in Catalog.GetType()
                     .GetField("_shelves", BindingFlags.NonPublic | BindingFlags.Instance)
                     ?.GetValue(Catalog) as IEnumerable<LibraryComponent> ?? Enumerable.Empty<LibraryComponent>())
        {
            if (shelfComp is Shelf shelf)
            {
                var cell = shelf.GetChild(cellId) as Cell;
                if (cell != null) return cell;
            }
        }

        throw new Exception("Ячейка не найдена");
    }

    private void RemoveBookFromComposite(int bookId)
    {
        foreach (var shelfComp in Catalog.GetType()
                     .GetField("_shelves", BindingFlags.NonPublic | BindingFlags.Instance)
                     ?.GetValue(Catalog) as IEnumerable<LibraryComponent> ?? Enumerable.Empty<LibraryComponent>())
        {
            if (shelfComp is Shelf shelf)
            {
                foreach (var cellComp in shelf.GetType()
                             .GetField("_cells", BindingFlags.NonPublic | BindingFlags.Instance)
                             ?.GetValue(shelf) as IEnumerable<LibraryComponent> ?? Enumerable.Empty<LibraryComponent>())
                {
                    if (cellComp is Cell cell && cell.Book?.Id == bookId)
                    {
                        cell.Remove(cell.Book);
                        return;
                    }
                }
            }
        }
    }

    public void PrintReaders()
    {
        var readers = _readerRepo.GetAllReaders();
        Console.WriteLine("\nЧитатели в системе:");
        foreach (var r in readers)
            Console.WriteLine($"[{r.Id}] {r.Name}");
    }
}