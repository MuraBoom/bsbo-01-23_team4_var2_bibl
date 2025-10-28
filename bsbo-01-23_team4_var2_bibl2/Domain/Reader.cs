namespace bsbo_01_23_team4_var2_bibl2.Domain;

public class Reader
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Reader(int id, string name)
    {
        Id = id;
        Name = name;
    }
}