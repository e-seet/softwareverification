using Lab4.Interfaces;
using Lab4.Services;
using Moq;
using Xunit;

namespace Lab4.Tests
{
    public class BankingServiceTests
    {
        private readonly Mock<IAccountRepository> _mockAccountRepository;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly Mock<ILogger> _mockLogger;
        private readonly BankingService _bankingService;

        public BankingServiceTests()
        {
            _mockAccountRepository = new Mock<IAccountRepository>();
            _mockEmailService = new Mock<IEmailService>();
            _mockLogger = new Mock<ILogger>();
            _bankingService = new BankingService(
                _mockAccountRepository.Object,
                _mockEmailService.Object,
                _mockLogger.Object);
        }

        [Fact]
        public void TransferMoney_SuccessfulTransfer_ReturnsTrue()
        {
            // Arrange
            var fromAccountId = 1;
            var toAccountId = 2;
            var amount = 100m;

            var fromAccount = new Account
            {
                Id = fromAccountId,
                AccountHolder = "John Doe",
                Balance = 500m,
                Email = "john@example.com"
            };

            var toAccount = new Account
            {
                Id = toAccountId,
                AccountHolder = "Jane Smith",
                Balance = 200m,
                Email = "jane@example.com"
            };

            _mockAccountRepository.Setup(x => x.AccountExists(fromAccountId)).Returns(true);
            _mockAccountRepository.Setup(x => x.AccountExists(toAccountId)).Returns(true);
            _mockAccountRepository.Setup(x => x.GetAccount(fromAccountId)).Returns(fromAccount);
            _mockAccountRepository.Setup(x => x.GetAccount(toAccountId)).Returns(toAccount);
            _mockEmailService.Setup(x => x.IsEmailServiceAvailable()).Returns(true);
            _mockEmailService.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Act
            var result = _bankingService.TransferMoney(fromAccountId, toAccountId, amount);

            // Assert
            Assert.True(result);
            Assert.Equal(400m, fromAccount.Balance);
            Assert.Equal(300m, toAccount.Balance);

            // Verify repository methods were called
            _mockAccountRepository.Verify(x => x.UpdateAccount(fromAccount), Times.Once);
            _mockAccountRepository.Verify(x => x.UpdateAccount(toAccount), Times.Once);

            // Verify email notifications were sent
            _mockEmailService.Verify(x => x.SendEmail(
                "john@example.com",
                "Money Transfer Notification",
                It.IsAny<string>()), Times.Once);

            _mockEmailService.Verify(x => x.SendEmail(
                "jane@example.com",
                "Money Received Notification",
                It.IsAny<string>()), Times.Once);

            // Verify logging
            _mockLogger.Verify(x => x.Log(It.Is<string>(s => s.Contains("Starting money transfer"))), Times.Once);
            _mockLogger.Verify(x => x.Log(It.Is<string>(s => s.Contains("Transfer completed successfully"))), Times.Once);
        }

        [Fact]
        public void TransferMoney_InsufficientFunds_ReturnsFalse()
        {
            // Arrange
            var fromAccountId = 1;
            var toAccountId = 2;
            var amount = 1000m; // More than available balance

            var fromAccount = new Account
            {
                Id = fromAccountId,
                Balance = 500m,
                Email = "john@example.com"
            };

            _mockAccountRepository.Setup(x => x.AccountExists(fromAccountId)).Returns(true);
            _mockAccountRepository.Setup(x => x.AccountExists(toAccountId)).Returns(true);
            _mockAccountRepository.Setup(x => x.GetAccount(fromAccountId)).Returns(fromAccount);

            // Act
            var result = _bankingService.TransferMoney(fromAccountId, toAccountId, amount);

            // Assert
            Assert.False(result);
            Assert.Equal(500m, fromAccount.Balance); // Balance should remain unchanged

            // Verify no updates were made
            _mockAccountRepository.Verify(x => x.UpdateAccount(It.IsAny<Account>()), Times.Never);

            // Verify warning was logged
            _mockLogger.Verify(x => x.LogWarning(It.Is<string>(s => s.Contains("Insufficient funds"))), Times.Once);
        }

        [Fact]
        public void TransferMoney_SourceAccountDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var fromAccountId = 999; // Non-existent account
            var toAccountId = 2;
            var amount = 100m;

            _mockAccountRepository.Setup(x => x.AccountExists(fromAccountId)).Returns(false);

            // Act
            var result = _bankingService.TransferMoney(fromAccountId, toAccountId, amount);

            // Assert
            Assert.False(result);

            // Verify error was logged
            _mockLogger.Verify(x => x.LogError(It.Is<string>(s => s.Contains("does not exist"))), Times.Once);
        }

        [Fact]
        public void TransferMoney_EmailServiceUnavailable_StillCompletesTransfer()
        {
            // Arrange
            var fromAccountId = 1;
            var toAccountId = 2;
            var amount = 100m;

            var fromAccount = new Account
            {
                Id = fromAccountId,
                Balance = 500m,
                Email = "john@example.com"
            };

            var toAccount = new Account
            {
                Id = toAccountId,
                Balance = 200m,
                Email = "jane@example.com"
            };

            _mockAccountRepository.Setup(x => x.AccountExists(It.IsAny<int>())).Returns(true);
            _mockAccountRepository.Setup(x => x.GetAccount(fromAccountId)).Returns(fromAccount);
            _mockAccountRepository.Setup(x => x.GetAccount(toAccountId)).Returns(toAccount);
            _mockEmailService.Setup(x => x.IsEmailServiceAvailable()).Returns(false);

            // Act
            var result = _bankingService.TransferMoney(fromAccountId, toAccountId, amount);

            // Assert
            Assert.True(result);
            Assert.Equal(400m, fromAccount.Balance);
            Assert.Equal(300m, toAccount.Balance);

            // Verify transfer still completed
            _mockAccountRepository.Verify(x => x.UpdateAccount(It.IsAny<Account>()), Times.Exactly(2));

            // Verify warning about email service was logged
            _mockLogger.Verify(x => x.LogWarning(It.Is<string>(s => s.Contains("Email service is not available"))), Times.Once);

            // Verify no emails were sent
            _mockEmailService.Verify(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void GetAccountBalance_ValidAccount_ReturnsBalance()
        {
            // Arrange
            var accountId = 1;
            var expectedBalance = 1000m;

            var account = new Account
            {
                Id = accountId,
                Balance = expectedBalance
            };

            _mockAccountRepository.Setup(x => x.AccountExists(accountId)).Returns(true);
            _mockAccountRepository.Setup(x => x.GetAccount(accountId)).Returns(account);

            // Act
            var result = _bankingService.GetAccountBalance(accountId);

            // Assert
            Assert.Equal(expectedBalance, result);
            _mockLogger.Verify(x => x.Log(It.Is<string>(s => s.Contains("Retrieving balance"))), Times.Once);
        }

        [Fact]
        public void GetAccountBalance_AccountDoesNotExist_ThrowsException()
        {
            // Arrange
            var accountId = 999;
            _mockAccountRepository.Setup(x => x.AccountExists(accountId)).Returns(false);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _bankingService.GetAccountBalance(accountId));
            Assert.Contains("does not exist", exception.Message);
        }

        [Fact]
        public void DepositMoney_SuccessfulDeposit_ReturnsTrue()
        {
            // Arrange
            var accountId = 1;
            var depositAmount = 200m;

            var account = new Account
            {
                Id = accountId,
                Balance = 500m,
                Email = "john@example.com"
            };

            _mockAccountRepository.Setup(x => x.AccountExists(accountId)).Returns(true);
            _mockAccountRepository.Setup(x => x.GetAccount(accountId)).Returns(account);
            _mockEmailService.Setup(x => x.IsEmailServiceAvailable()).Returns(true);
            _mockEmailService.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Act
            var result = _bankingService.DepositMoney(accountId, depositAmount);

            // Assert
            Assert.True(result);
            Assert.Equal(700m, account.Balance);

            // Verify account was updated
            _mockAccountRepository.Verify(x => x.UpdateAccount(account), Times.Once);

            // Verify email notification was sent
            _mockEmailService.Verify(x => x.SendEmail(
                "john@example.com",
                "Deposit Notification",
                It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void DepositMoney_InvalidAmount_ReturnsFalse()
        {
            // Arrange
            var accountId = 1;
            var invalidAmount = -100m; // Negative amount

            _mockAccountRepository.Setup(x => x.AccountExists(accountId)).Returns(true);

            // Act
            var result = _bankingService.DepositMoney(accountId, invalidAmount);

            // Assert
            Assert.False(result);

            // Verify error was logged
            _mockLogger.Verify(x => x.LogError(It.Is<string>(s => s.Contains("Invalid deposit amount"))), Times.Once);
        }

        [Fact]
        public void BankingService_Constructor_NullDependencies_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BankingService(null, _mockEmailService.Object, _mockLogger.Object));
            Assert.Throws<ArgumentNullException>(() => new BankingService(_mockAccountRepository.Object, null, _mockLogger.Object));
            Assert.Throws<ArgumentNullException>(() => new BankingService(_mockAccountRepository.Object, _mockEmailService.Object, null));
        }
    }
}
