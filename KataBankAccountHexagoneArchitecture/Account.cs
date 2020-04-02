using System;
using BankAccount.Domain.Model;

namespace BankAccount.Domain
{
    public class Account : IAccount
    {
        private readonly IAccountPort _accountPort;

        public Account(IAccountPort accountPort)
        {
            _accountPort = accountPort;
        }

        public Money Balance()
        {
            return _accountPort.Balance();
        }

        public void Deposit(Money money)
        {
            _accountPort.Deposit(money);
        }

        public void Withdrawal(Money money)
        {
            _accountPort.Withdrawal(money);
        }
    }
}