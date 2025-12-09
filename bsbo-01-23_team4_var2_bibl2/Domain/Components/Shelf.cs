using System.Collections.Generic;

namespace bsbo_01_23_team4_var2_bibl2.Domain.Components;

public class Shelf : LibraryComponent
{
    private readonly List<LibraryComponent> _cells = new();

    public Shelf(int id, string name) : base(id, name) { }

    public override void Add(LibraryComponent component)
    {
        if (component is Cell)
            _cells.Add(component);
        else
            throw new InvalidOperationException("В шкаф можно добавлять только ячейки.");
    }

    public override void Remove(LibraryComponent component) => _cells.Remove(component);

    public override LibraryComponent? GetChild(int id)
        => _cells.FirstOrDefault(x => x.Id == id);

    public override void PrintInfo()
    {
        Console.WriteLine($"  Шкаф [{Id}]: {Name}");
        foreach (var cell in _cells)
            cell.PrintInfo();
    }
}