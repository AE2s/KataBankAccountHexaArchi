using BankAccount.Domain;
using BankAccount.Domain.Model;

namespace BankAccount.Application
{
    public class ConsoleAdapter
    {
        private readonly IAccount _account;

        public ConsoleAdapter(IAccount account)
        {
            _account = account;
        }

        public Money Balance()
        {
            return _account.Balance();
        }

        public void Deposit(Money money)
        {
            _account.Deposit(money);
        }

        public void Withdrawal(Money money)
        {
            _account.Withdrawal(money);
        }

        public string OperationsHistory()
        {
            return _account.OperationsHistory();
        }
    }
}
