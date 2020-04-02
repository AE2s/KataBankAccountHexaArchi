using System;
using NFluent;
using BankAccount.Application;
using BankAccount.Domain;
using BankAccount.Domain.Model;
using BankAccount.Infrastructure;
using NSubstitute;
using Xunit;

namespace BankAccount.Tests
{
    public class BankAccountTest
    {
        private readonly IDate date;
        private readonly DateTime dateToUse;
        public BankAccountTest()
        {
            dateToUse=new DateTime(2020,04,02);
            date = Substitute.For<IDate>();
            date.CurrentDate().Returns(dateToUse);
        }
        
        [Fact]
        public void Given_an_account_with_deposit_ten_should_return_ten_in_the_balance()
        {
            var accountRepository = Substitute.For<IAccountPort>();
            var depositValue = Money.ValueOf(10);
            accountRepository.Balance().Returns(depositValue);
            IAccount account = new Account(accountRepository);
            
            account.Deposit(depositValue);

            Check.That(account.Balance()).IsEqualTo(depositValue);
        }

        [Fact]
        public void Given_an_account_with_two_deposits__should_return_sum_in_the_balance()
        {
            var depositValue = Money.ValueOf(10);
            var expectedBalance = Money.ValueOf(20);
            var accountAdapter = new AccountAdapter(date);
            IAccount account = new Account(accountAdapter);
            var consoleAdapter=new ConsoleAdapter(account);

            consoleAdapter.Deposit(depositValue);
            consoleAdapter.Deposit(depositValue);

            Check.That(consoleAdapter.Balance()).IsEqualTo(expectedBalance);
        }

        [Fact]
        
        public void Given_an_account_with_negative_deposits__should_not_add_to_the_balance()
        {
            Assert.Throws<ArgumentException>(() => Money.ValueOf(-10));
        }

        [Fact]
        public void Given_an_account_with_ten_deposit_and_ten_withdrawal_should_return_zero()
        {
            var depositValue = Money.ValueOf(10);
            var expectedBalance = Money.ValueOf(0);
            var accountAdapter = new AccountAdapter(date);
            IAccount account = new Account(accountAdapter);
            var consoleAdapter = new ConsoleAdapter(account);

            consoleAdapter.Deposit(depositValue);
            consoleAdapter.Withdrawal(depositValue);

            Check.That(consoleAdapter.Balance()).IsEqualTo(expectedBalance);
        }

        [Fact]
        public void Given_an_account_with_one_deposit_should_return_historic_containing_one_operation()
        {
            var ten = Money.ValueOf(10);
            var expectedHistory = $"operation | date | amount | balance\nDeposit | {dateToUse} | {ten} | {ten}";
            var accountAdapter = new AccountAdapter(date);
            IAccount account = new Account(accountAdapter);
            var consoleAdapter = new ConsoleAdapter(account);

            consoleAdapter.Deposit(ten);

            Check.That(consoleAdapter.OperationsHistory()).IsEqualTo(expectedHistory);
        }

        [Fact]
        public void Given_an_account_with_one_deposit_and_one_withdraw_should_return_historic_containing_two_operations()
        {
            var ten = Money.ValueOf(10);
            var twenty = Money.ValueOf(20);
            var expectedHistory = $"operation | date | amount | balance\nDeposit | {dateToUse} | {twenty} | {twenty}\nWithdraw | {dateToUse} | {ten} | {ten}";
            var accountAdapter = new AccountAdapter(date);
            IAccount account = new Account(accountAdapter);
            var consoleAdapter = new ConsoleAdapter(account);

            consoleAdapter.Deposit(twenty);
            consoleAdapter.Withdrawal(ten);

            Check.That(consoleAdapter.OperationsHistory()).IsEqualTo(expectedHistory);
        }
    }
}
