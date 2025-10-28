namespace bsbo_01_23_team4_var2_bibl2.Domain;

public class Loan
{
    public int BookId { get; private set; }
    public int ReaderId { get; private set; }
    public DateTime BorrowedAt { get; private set; }
    public DateTime? ReturnedAt { get; private set; }

    public Loan(int bookId, int readerId)
    {
        BookId = bookId;
        ReaderId = readerId;
        BorrowedAt = DateTime.Now;
    }

    public void MarkAsReturned() => ReturnedAt = DateTime.Now;

    public bool IsActive => ReturnedAt == null;
}