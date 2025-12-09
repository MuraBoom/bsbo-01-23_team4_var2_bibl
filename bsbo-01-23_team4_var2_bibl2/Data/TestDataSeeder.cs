using bsbo_01_23_team4_var2_bibl2.Library;
using bsbo_01_23_team4_var2_bibl2.Domain.Components;
using bsbo_01_23_team4_var2_bibl2.Domain;

namespace bsbo_01_23_team4_var2_bibl2.Data;

public static class TestDataSeeder
{
    public static void Seed(Library.Library library)
    {
        Console.WriteLine("Инициализация тестовых данных...\n");
        
        library.AddShelf(100, "Шкаф A");
        library.AddShelf(200, "Шкаф B");

        library.AddCellToShelf(100, 101, "Ячейка A1");
        library.AddCellToShelf(100, 102, "Ячейка A2");
        library.AddCellToShelf(100, 103, "Ячейка A2");
        library.AddCellToShelf(200, 201, "Ячейка B1");
        library.AddCellToShelf(200, 202, "Ячейка B2");

        library.AddBookToCell(101, "Война и мир", "Лев Толстой");
        library.AddBookToCell(102, "Преступление и наказание", "Фёдор Достоевский");
        library.AddBookToCell(201, "Мастер и Маргарита", "Михаил Булгаков");
        library.AddBookToCell(202, "12 стульев", "Ильф и Петров");

        library.AddReader(1, "Иван Иванов");
        library.AddReader(2, "Пётр Петров");
        library.AddReader(3, "Анна Смирнова");

        Console.WriteLine("Тестовые данные успешно загружены!\n");
    }
}