using Xunit;
using CSharpBankingApp;


public class AccountTests
    {
        [Fact]
        public void Deposit_IncreasesBalance_WhenPinCorrect()
        {
            var account = new Account("Rele", "1234");
            var ok = account.Deposit(100m, "1234");
            Assert.True(ok);
            Assert.Equal(100m, account.Balance);
        }

        [Fact]
        public void Deposit_Fails_WhenPinWrong()
        {
            var account = new Account("Rele", "1234");
            var ok = account.Deposit(100m, "9999");
            Assert.False(ok);
            Assert.Equal(0m, account.Balance);
        }

        [Fact]
        public void Withdraw_DecreasesBalance_WhenFundsAndPinValid()
        {
            var account = new Account("Rele", "1234");
            account.Deposit(200m, "1234");
            var ok = account.Withdraw(50m, "1234");
            Assert.True(ok);
            Assert.Equal(150m, account.Balance);
        }

        [Fact]
        public void Withdraw_Fails_WhenInsufficientAndNoOverdraft()
        {
            var account = new Account("Rele", "1234", AccountType.Savings); // overdraft = 0
            var ok = account.Withdraw(10m, "1234");
            Assert.False(ok);
            Assert.Equal(0m, account.Balance);
        }

        [Fact]
        public void MonthlyInterest_IncreasesBalance()
        {
            var account = new Account("Rele", "1234", AccountType.Savings);
            account.Deposit(1200m, "1234"); // >0 so interest will apply
            var applied = account.ApplyMonthlyInterest("1234");
            Assert.True(applied);
            Assert.True(account.Balance > 1200m);
        }
    }
