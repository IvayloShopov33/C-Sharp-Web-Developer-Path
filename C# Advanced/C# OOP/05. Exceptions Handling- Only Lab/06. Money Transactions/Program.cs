namespace MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> bankAccounts = new();
            string[] bankAccountsDetails = Console.ReadLine().Split(",");

            for (int i = 0; i < bankAccountsDetails.Length; i++)
            {
                string[] bankAccount = bankAccountsDetails[i].Split("-");
                int accountNumber = int.Parse(bankAccount[0]);
                double accountBalance = double.Parse(bankAccount[1]);

                bankAccounts.Add(accountNumber, accountBalance);
            }

            string[] commands;
            while (true)
            {
                commands = Console.ReadLine().Split(" ");
                string command = commands[0];

                if (command == "End")
                {
                    break;
                }

                try
                {
                    if (command != "Deposit" && command != "Withdraw")
                    {
                        throw new InvalidOperationException("Invalid command!");
                    }

                    int numberOfAccount = int.Parse(commands[1]);
                    if (!bankAccounts.ContainsKey(numberOfAccount))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    if (command == "Deposit")
                    {
                        double moneyToDeposit = double.Parse(commands[2]);
                        bankAccounts[numberOfAccount] += moneyToDeposit;
                    }
                    else if (command == "Withdraw")
                    {
                        double moneyToWithdraw = double.Parse(commands[2]);

                        if (bankAccounts[numberOfAccount] - moneyToWithdraw < 0)
                        {
                            throw new InvalidOperationException("Insufficient balance!");
                        }

                        bankAccounts[numberOfAccount] -= moneyToWithdraw;
                    }

                    Console.WriteLine($"Account {numberOfAccount} has new balance: {bankAccounts[numberOfAccount]:F2}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}