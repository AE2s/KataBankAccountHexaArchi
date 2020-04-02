using BankAccount.Domain.Model;

namespace BankAccount.Domain
{
    public interface IAccount
    {
        Money Balance();
        void Deposit(Money money);
        void Withdrawal(Money money);
    }
}