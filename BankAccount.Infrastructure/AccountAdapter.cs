using System;
using System.Collections.Generic;
using BankAccount.Domain;
using BankAccount.Domain.Model;

namespace BankAccount.Infrastructure
{
    public class AccountAdapter : IAccountPort
    {
        private readonly IDate _date;
        private Money _balance;
        private const string HEADER_HISTORIC_OPERATIONS = "operation | date | amount | balance";
        private List<Operation> operations;

        public AccountAdapter(IDate date)
        {
            _date = date;
            _balance = Money.ValueOf(0);
            operations=new List<Operation>();
        }
        public Money Balance()
        {
            return _balance;
        }

        public void Deposit(Money money)
        {
            _balance = _balance.Add(money);
            operations.Add(new Operation(OperationType.Deposit, _date.CurrentDate(), money, _balance));
        }

        public void Withdrawal(Money money)
        {
            _balance = _balance.Substract(money);
            operations.Add(new Operation(OperationType.Withdraw, _date.CurrentDate(), money, _balance));
        }

        public string OperationsHistory()
        {
            return $"{HEADER_HISTORIC_OPERATIONS}\n{string.Join("\n",operations)}";
        }
    }
}
