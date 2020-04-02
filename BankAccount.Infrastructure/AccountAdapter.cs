using System;
using System.Collections.Generic;
using System.Text;
using BankAccount.Domain;
using BankAccount.Domain.Model;

namespace BankAccount.Infrastructure
{
    public class AccountAdapter : IAccountPort
    {
        private Money _balance;

        public AccountAdapter()
        {
            _balance = Money.ValueOf(0);
        }
        public Money Balance()
        {
            return _balance;
        }

        public void Deposit(Money money)
        {
            _balance = _balance.Add(money);
        }

        public void Withdrawal(Money money)
        {
            _balance = _balance.Substract(money);
        }
    }
}
