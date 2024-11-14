using System.Security.Principal;

namespace Tumakov_laba_Boronin_09_421
{
    /// <summary>
    /// Перечисление содержит 2 разных типов счетов 1 = текущий, 2 = сберегательный
    /// </summary>
    enum Account_bank
    {
        current = 1,
        savings = 2

    }
    /// <summary>
    /// Перечисление содержит 3 разных университета под 1 = KGU, 2 = KHTI, 3 = KAI
    /// </summary>
    enum University
    {
        KGU = 1,
        KHTI = 2,
        KAI = 3
    }
    /// <summary>
    /// Структура работника, содержит такие поля как: Имя работника и Университет.
    /// </summary>
    struct Worker
    {
        public string name;
        public University university;

        public Worker(string name, University university)
        {
            this.name = name;
            this.university = university;
        }
    }
    /// <summary>
    /// Структура чтобы узнать ифнормацию о счете в банке, его тип (реализуется с помощтю enum Account_bank), его баланс, его id
    /// </summary>
    struct Information_account_bank
    {
        public Account_bank account_bank; 
        public int bank_balance;
        public int id;

        
        public Information_account_bank(Account_bank account_bank, int bank_balance, int id)
        {
            this.account_bank = account_bank;
            this.bank_balance = bank_balance;
            this.id = id;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nУпражнение 3.1\n");

            Account_bank bank_account_current = Account_bank.current;
            Account_bank bank_account_savings = Account_bank.savings;

            Console.WriteLine($"Текущий счет: {bank_account_current}");
            Console.WriteLine($"Текущий счет(в виде цифры): {(int)bank_account_current}");
            Console.WriteLine($"Сберегательный счет: {bank_account_savings}");
            Console.WriteLine($"Сберегательный счет(в виде цифры): {(int)bank_account_savings}");

            Console.WriteLine("\nУпражнение 3.2\n");
            
            Information_account_bank account = new Information_account_bank(Account_bank.current, 100, 1324);
            Console.WriteLine($"Тип счета: {account.account_bank}\nБаланс: {account.bank_balance}\nId: {account.id}");

            Console.WriteLine("\nДомашнее задание 3.1\n");
            Worker worker = new Worker("Иван", University.KGU);
            Console.WriteLine($"Имя работника: {worker.name}\nВУЗ: {worker.university}");


        }
    }
}
