namespace Lab4.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccount(int accountId);
        void UpdateAccount(Account account);
        bool AccountExists(int accountId);
    }

    public class Account
    {
        public int Id { get; set; }
        public string AccountHolder { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
