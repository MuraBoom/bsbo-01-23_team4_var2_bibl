using System.Collections.Generic;

namespace bsbo_01_23_team4_var2_bibl2.Domain.Components;

public class Catalog : LibraryComponent
{
    private readonly List<LibraryComponent> _shelves = new();

    public Catalog(int id, string name) : base(id, name) { }

    public override void Add(LibraryComponent component)
    {
        if (component is Shelf)
            _shelves.Add(component);
        else
            throw new InvalidOperationException("В каталог можно добавлять только шкафы.");
    }

    public override void Remove(LibraryComponent component) => _shelves.Remove(component);

    public override LibraryComponent? GetChild(int id)
        => _shelves.FirstOrDefault(x => x.Id == id);

    public override void PrintInfo()
    {
        Console.WriteLine($"Каталог [{Id}]: {Name}");
        foreach (var shelf in _shelves)
            shelf.PrintInfo();
    }
}