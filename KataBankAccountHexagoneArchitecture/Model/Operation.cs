using System;

namespace BankAccount.Domain.Model
{
    public class Operation
    {
        private readonly OperationType _operationType;
        private readonly DateTime _date;
        private readonly Money _amount;
        private readonly Money _balance;

        public Operation(OperationType operationType, DateTime date, Money amount, Money balance)
        {
            _operationType = operationType;
            _date = date;
            _amount = amount;
            _balance = balance;
        }

        public override string ToString()
        {
            return $"{_operationType} | {_date} | {_amount} | {_balance}";
        }
    }

}
