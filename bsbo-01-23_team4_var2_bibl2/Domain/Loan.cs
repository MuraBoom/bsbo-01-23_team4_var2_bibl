namespace bsbo_01_23_team4_var2_bibl2.Domain;

public class Loan
{
    public int BookId { get; }
    public int ReaderId { get; }
    public DateTime BorrowedAt { get; } = DateTime.Now;
    public DateTime? ReturnedAt { get; private set; }

    public Loan(int bookId, int readerId)
    {
        BookId = bookId;
        ReaderId = readerId;
    }

    public void MarkAsReturned() => ReturnedAt = DateTime.Now;
    public bool IsActive => ReturnedAt is null;
}