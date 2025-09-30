using Lab4.Interfaces;
using Lab4.Services;
using Moq;
using Xunit;

namespace Lab4.Tests
{
    /// <summary>
    /// This class demonstrates different types of test doubles:
    /// 1. Stub - provides predefined responses to method calls
    /// 2. Mock - verifies interactions and behavior
    /// 3. Fake - provides a working implementation for testing
    /// </summary>
    public class TestDoublesDemo
    {
        [Fact]
        public void StubExample_ProvidesPredefinedResponses()
        {
            // Arrange - Creating a STUB
            // A stub provides predefined responses to method calls
            var stubLogger = new Mock<ILogger>();
            var stubEmailService = new Mock<IEmailService>();
            var stubRepository = new Mock<IAccountRepository>();

            // Configure stub responses
            stubRepository.Setup(x => x.AccountExists(1)).Returns(true);
            stubRepository.Setup(x => x.GetAccount(1)).Returns(new Account
            {
                Id = 1,
                Balance = 1000m,
                Email = "test@example.com"
            });

            var bankingService = new BankingService(
                stubRepository.Object,
                stubEmailService.Object,
                stubLogger.Object);

            // Act
            var balance = bankingService.GetAccountBalance(1);

            // Assert
            Assert.Equal(1000m, balance);

            // Note: We're not verifying interactions here - this is a stub
            // We only care about the return value, not how it was obtained
        }

        [Fact]
        public void MockExample_VerifiesInteractions()
        {
            // Arrange - Creating a MOCK
            // A mock verifies interactions and behavior
            var mockLogger = new Mock<ILogger>();
            var mockEmailService = new Mock<IEmailService>();
            var mockRepository = new Mock<IAccountRepository>();

            // Configure mock responses
            mockRepository.Setup(x => x.AccountExists(1)).Returns(true);
            mockRepository.Setup(x => x.GetAccount(1)).Returns(new Account
            {
                Id = 1,
                Balance = 1000m,
                Email = "test@example.com"
            });

            var bankingService = new BankingService(
                mockRepository.Object,
                mockEmailService.Object,
                mockLogger.Object);

            // Act
            var balance = bankingService.GetAccountBalance(1);

            // Assert
            Assert.Equal(1000m, balance);

            // Verify interactions - this is what makes it a MOCK
            mockRepository.Verify(x => x.AccountExists(1), Times.Once);
            mockRepository.Verify(x => x.GetAccount(1), Times.Once);
            mockLogger.Verify(x => x.Log(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [Fact]
        public void FakeExample_WorkingImplementation()
        {
            // Arrange - Creating a FAKE
            // A fake provides a working implementation for testing
            var fakeLogger = new FakeLogger();
            var fakeEmailService = new FakeEmailService();
            var fakeRepository = new FakeAccountRepository();

            // Set up test data in the fake
            fakeRepository.AddAccount(new Account
            {
                Id = 1,
                Balance = 1000m,
                Email = "test@example.com"
            });

            var bankingService = new BankingService(
                fakeRepository,
                fakeEmailService,
                fakeLogger);

            // Act
            var balance = bankingService.GetAccountBalance(1);

            // Assert
            Assert.Equal(1000m, balance);
            Assert.True(fakeLogger.LogMessages.Count > 0);
            Assert.Contains("Retrieving balance", fakeLogger.LogMessages.First());
        }

        [Fact]
        public void SpyExample_RecordsInteractions()
        {
            // Arrange - Creating a SPY (using Mock as a spy)
            // A spy records interactions for later verification
            var spyLogger = new Mock<ILogger>();
            var spyEmailService = new Mock<IEmailService>();
            var spyRepository = new Mock<IAccountRepository>();

            // Configure responses
            spyRepository.Setup(x => x.AccountExists(1)).Returns(true);
            spyRepository.Setup(x => x.GetAccount(1)).Returns(new Account
            {
                Id = 1,
                Balance = 1000m,
                Email = "test@example.com"
            });

            var bankingService = new BankingService(
                spyRepository.Object,
                spyEmailService.Object,
                spyLogger.Object);

            // Act
            var balance = bankingService.GetAccountBalance(1);

            // Assert
            Assert.Equal(1000m, balance);

            // Spy verification - check what was recorded
            var logCalls = spyLogger.Invocations.Where(i => i.Method.Name == "Log").ToList();
            Assert.True(logCalls.Count >= 2); // At least "Retrieving balance" and "balance: 1000"

            // Verify specific log messages were recorded
            var logMessages = logCalls.Select(i => i.Arguments[0].ToString()).ToList();
            Assert.Contains(logMessages, msg => msg.Contains("Retrieving balance"));
            Assert.Contains(logMessages, msg => msg.Contains("balance: 1000"));
        }
    }

    // FAKE IMPLEMENTATIONS for demonstration
    public class FakeLogger : ILogger
    {
        public List<string> LogMessages { get; } = new List<string>();
        public List<string> ErrorMessages { get; } = new List<string>();
        public List<string> WarningMessages { get; } = new List<string>();

        public void Log(string message)
        {
            LogMessages.Add(message);
        }

        public void LogError(string message)
        {
            ErrorMessages.Add(message);
        }

        public void LogWarning(string message)
        {
            WarningMessages.Add(message);
        }
    }

    public class FakeEmailService : IEmailService
    {
        public List<(string to, string subject, string body)> SentEmails { get; } = new List<(string, string, string)>();
        public bool IsAvailable { get; set; } = true;

        public bool SendEmail(string to, string subject, string body)
        {
            if (!IsAvailable) return false;
            
            SentEmails.Add((to, subject, body));
            return true;
        }

        public bool IsEmailServiceAvailable()
        {
            return IsAvailable;
        }
    }

    public class FakeAccountRepository : IAccountRepository
    {
        private readonly Dictionary<int, Account> _accounts = new Dictionary<int, Account>();

        public void AddAccount(Account account)
        {
            _accounts[account.Id] = account;
        }

        public Account GetAccount(int accountId)
        {
            return _accounts.TryGetValue(accountId, out var account) ? account : null;
        }

        public void UpdateAccount(Account account)
        {
            if (_accounts.ContainsKey(account.Id))
            {
                _accounts[account.Id] = account;
            }
        }

        public bool AccountExists(int accountId)
        {
            return _accounts.ContainsKey(accountId);
        }
    }
}
