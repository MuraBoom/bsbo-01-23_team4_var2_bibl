using bsbo_01_23_team4_var2_bibl2.Domain;

namespace bsbo_01_23_team4_var2_bibl2.Repository;

public class InMemoryReaderRepository : IReaderRepository
{
    private readonly List<Reader> _readers = new();
    private static readonly Lazy<InMemoryReaderRepository> _instance =
        new(() => new InMemoryReaderRepository());

    public static InMemoryReaderRepository Instance => _instance.Value;

    private InMemoryReaderRepository() { }

    public IEnumerable<Reader> GetAllReaders() => _readers;

    public Reader? GetReaderById(int id)
        => _readers.FirstOrDefault(r => r.Id == id);

    public void AddReader(Reader reader) => _readers.Add(reader);
}
