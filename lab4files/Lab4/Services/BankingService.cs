using Lab4.Interfaces;

namespace Lab4.Services
{
    public class BankingService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;

        public BankingService(
            IAccountRepository accountRepository,
            IEmailService emailService,
            ILogger logger)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool TransferMoney(int fromAccountId, int toAccountId, decimal amount)
        {
            try
            {
                _logger.Log($"Starting money transfer: {amount} from account {fromAccountId} to account {toAccountId}");

                // Validate accounts exist
                if (!_accountRepository.AccountExists(fromAccountId))
                {
                    _logger.LogError($"Source account {fromAccountId} does not exist");
                    return false;
                }

                if (!_accountRepository.AccountExists(toAccountId))
                {
                    _logger.LogError($"Destination account {toAccountId} does not exist");
                    return false;
                }

                // Get accounts
                var fromAccount = _accountRepository.GetAccount(fromAccountId);
                var toAccount = _accountRepository.GetAccount(toAccountId);

                // Validate sufficient funds
                if (fromAccount.Balance < amount)
                {
                    _logger.LogWarning($"Insufficient funds in account {fromAccountId}. Balance: {fromAccount.Balance}, Requested: {amount}");
                    return false;
                }

                // Validate amount
                if (amount <= 0)
                {
                    _logger.LogError($"Invalid transfer amount: {amount}");
                    return false;
                }

                // Perform transfer
                fromAccount.Balance -= amount;
                toAccount.Balance += amount;

                _accountRepository.UpdateAccount(fromAccount);
                _accountRepository.UpdateAccount(toAccount);

                _logger.Log($"Transfer completed successfully. New balance for account {fromAccountId}: {fromAccount.Balance}");

                // Send notification emails
                if (_emailService.IsEmailServiceAvailable())
                {
                    var fromEmailSent = _emailService.SendEmail(
                        fromAccount.Email,
                        "Money Transfer Notification",
                        $"You have transferred ${amount} to account {toAccountId}. Your new balance is ${fromAccount.Balance}");

                    var toEmailSent = _emailService.SendEmail(
                        toAccount.Email,
                        "Money Received Notification",
                        $"You have received ${amount} from account {fromAccountId}. Your new balance is ${toAccount.Balance}");

                    if (!fromEmailSent || !toEmailSent)
                    {
                        _logger.LogWarning("Failed to send one or more notification emails");
                    }
                }
                else
                {
                    _logger.LogWarning("Email service is not available, skipping notifications");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Transfer failed with exception: {ex.Message}");
                return false;
            }
        }

        public decimal GetAccountBalance(int accountId)
        {
            _logger.Log($"Retrieving balance for account {accountId}");

            if (!_accountRepository.AccountExists(accountId))
            {
                _logger.LogError($"Account {accountId} does not exist");
                throw new ArgumentException($"Account {accountId} does not exist");
            }

            var account = _accountRepository.GetAccount(accountId);
            _logger.Log($"Account {accountId} balance: {account.Balance}");
            return account.Balance;
        }

        public bool DepositMoney(int accountId, decimal amount)
        {
            try
            {
                _logger.Log($"Depositing {amount} to account {accountId}");

                if (!_accountRepository.AccountExists(accountId))
                {
                    _logger.LogError($"Account {accountId} does not exist");
                    return false;
                }

                if (amount <= 0)
                {
                    _logger.LogError($"Invalid deposit amount: {amount}");
                    return false;
                }

                var account = _accountRepository.GetAccount(accountId);
                account.Balance += amount;
                _accountRepository.UpdateAccount(account);

                _logger.Log($"Deposit completed. New balance: {account.Balance}");

                // Send notification
                if (_emailService.IsEmailServiceAvailable())
                {
                    var emailSent = _emailService.SendEmail(
                        account.Email,
                        "Deposit Notification",
                        $"You have deposited ${amount}. Your new balance is ${account.Balance}");

                    if (!emailSent)
                    {
                        _logger.LogWarning("Failed to send deposit notification email");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Deposit failed with exception: {ex.Message}");
                return false;
            }
        }
    }
}
