namespace bsbo_01_23_team4_var2_bibl2.Domain.Components;

public abstract class LibraryComponent
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }

    protected LibraryComponent(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public virtual void Add(LibraryComponent component)
        => throw new InvalidOperationException($"{GetType().Name} не поддерживает добавление дочерних элементов.");

    public virtual void Remove(LibraryComponent component)
        => throw new InvalidOperationException($"{GetType().Name} не поддерживает удаление дочерних элементов.");

    public virtual LibraryComponent? GetChild(int id) => null;

    public abstract void PrintInfo();
}