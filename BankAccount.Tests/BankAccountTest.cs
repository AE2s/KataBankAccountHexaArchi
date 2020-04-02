using NFluent;
using System;
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
            var accountAdapter = new AccountAdapter();
            IAccount account = new Account(accountAdapter);
            var consoleAdapter=new ConsoleAdapter(account);

            consoleAdapter.Deposit(depositValue);
            consoleAdapter.Deposit(depositValue);

            Check.That(consoleAdapter.Balance()).IsEqualTo(expectedBalance);
        }
    }
}
