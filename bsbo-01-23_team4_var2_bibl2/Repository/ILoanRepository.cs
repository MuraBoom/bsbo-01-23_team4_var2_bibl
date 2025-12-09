using bsbo_01_23_team4_var2_bibl2.Domain;

namespace bsbo_01_23_team4_var2_bibl2.Repository;

public interface ILoanRepository
{
    void AddLoan(Loan loan);
    Loan? GetActiveLoanByBookId(int bookId);
    void UpdateLoan(Loan loan);
}