using bsbo_01_23_team4_var2_bibl2.Domain;

namespace bsbo_01_23_team4_var2_bibl2.Repository;

public interface IReaderRepository
{
    IEnumerable<Reader> GetAllReaders();
    Reader? GetReaderById(int id);
    void AddReader(Reader reader);
}