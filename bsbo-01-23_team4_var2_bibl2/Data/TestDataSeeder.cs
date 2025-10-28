using bsbo_01_23_team4_var2_bibl2.Domain;
using bsbo_01_23_team4_var2_bibl2.Repository;

namespace bsbo_01_23_team4_var2_bibl2.Data;

public static class TestDataSeeder
{
    public static void Seed(ILibraryRepository repository)
    {
        if (!repository.GetAllBooks().Any())
        {
            repository.AddBook(new Book(1, "Война и мир", "Л. Толстой"));
            repository.AddBook(new Book(2, "Преступление и наказание", "Ф. Достоевский"));
            repository.AddBook(new Book(3, "Мастер и Маргарита", "М. Булгаков"));
        }

        if (!repository.GetAllReaders().Any())
        {
            repository.AddReader(new Reader(1, "Иван Иванов"));
            repository.AddReader(new Reader(2, "Петр Петров"));
            repository.AddReader(new Reader(3, "Мария Смирнова"));
        }
    }
}