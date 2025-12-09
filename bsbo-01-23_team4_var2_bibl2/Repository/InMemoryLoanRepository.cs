using bsbo_01_23_team4_var2_bibl2.Domain;

namespace bsbo_01_23_team4_var2_bibl2.Repository;

public class InMemoryLoanRepository : ILoanRepository
{
    private readonly List<Loan> _loans = new();
    private static readonly Lazy<InMemoryLoanRepository> _instance =
        new(() => new InMemoryLoanRepository());

    public static InMemoryLoanRepository Instance => _instance.Value;

    private InMemoryLoanRepository() { }

    public void AddLoan(Loan loan) => _loans.Add(loan);

    public Loan? GetActiveLoanByBookId(int bookId)
        => _loans.FirstOrDefault(l => l.BookId == bookId && l.IsActive);

    public void UpdateLoan(Loan loan)
    {
    }
}
