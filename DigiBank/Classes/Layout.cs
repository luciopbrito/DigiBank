using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Layout
    {
        public static void ScreenMain()
        {
            int option = 0;
            bool confirm = false;
            while(confirm == false)
            {
                Console.Clear();
                Console.WriteLine("========      DigiBank      ========");
                Console.WriteLine("====== O Banco mais acessível ======");
                Console.WriteLine();
                Console.WriteLine("        Digite a opção deseja       ");
                Console.WriteLine("====================================");
                Console.WriteLine("   1 - Criar uma conta              ");
                Console.WriteLine("====================================");
                Console.WriteLine("   2 - Entrar com CPF               ");
                Console.WriteLine("====================================");
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("           OPÇÃO INVALIDA           ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);
                    ScreenMain();
                }

                switch (option)
                {
                    case 1:
                        ScreenCreateAccount();
                        confirm = true;
                        break;
                    case 2:
                        ScreenLoginInCPF();
                        confirm = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("====================================");
                        Console.WriteLine("           OPÇÃO INVALIDA           ");
                        Console.WriteLine("====================================");
                        Thread.Sleep(1000);                   
                        break;
                }
            }          
        }

        public static void ScreenCreateAccount()
        {
            string confPassword = "";
            string password = "";
            string name = "";
            string cpf = "";
            bool confirm = false;
            bool testList = true;
            bool PasswordEmpty = true;
            int optionConta = 0;

            // verificar nome
            while (confirm == false)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("         Digite o seu nome :         ");
                name = Console.ReadLine();
                
                if (String.IsNullOrWhiteSpace(name) == true)
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("          NOME INVALIDO             ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);
                }
                else
                {
                    confirm = true;
                }
            }

            confirm = false;
            
            // verificar cpf           
            while (confirm == false)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("         Digite o seu CPF :          ");
                cpf = Console.ReadLine();             

                if (cpf.Length <= 10 || cpf.Length > 11)
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("           CPF INVALIDO             ");
                    Console.WriteLine("       CPF possui 11 digitos        ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);                   
                }        
                else
                {
                    foreach (Client cli in Client.Clients)
                    {
                        if (cli.CPF == double.Parse(cpf))
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("====================================");
                            Console.WriteLine("    Este CPF já foi cadastrado      ");
                            Console.WriteLine("====================================");
                            Thread.Sleep(1000);
                            int test = ScreenMainOrLoginInCpf();
                            if (test == 1)
                            {
                                confirm = true;
                                ScreenLoginInCPF();
                            }
                            else if (test == 2)
                            {                              
                                ScreenMain();
                            }
                        }
                    }
                    confirm = true;
                }                               
            }
            
            confirm = false;

            while (confirm == false)
            {
                while (PasswordEmpty == true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("          Digite sua senha          ");
                    password = Console.ReadLine();

                    if (String.IsNullOrWhiteSpace(password) == true)
                    {
                        Console.Clear();
                        Console.WriteLine("========================================");
                        Console.WriteLine("            Senha Incorreta             ");
                        Console.WriteLine("   deve conter caracteres ou numeros    ");
                        Console.WriteLine("========================================");
                    }
                    else
                    {
                        PasswordEmpty = false;
                    }
                }
               
                Console.WriteLine("====================================");
                Console.WriteLine("      Digite sua senha novamente    ");
                confPassword = Console.ReadLine();

                if (password != confPassword)
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("      Senha não correspondentes     ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);
                    PasswordEmpty = true;
                }      
                else
                {               
                    confirm = true;
                }
            }

            confirm = false;

            while (confirm == false)
            {
                optionConta = ScreenChooseAccount();
                if (optionConta == 1)
                {
                    // create account checking
                    CheckingAccount checkingAccount = new CheckingAccount();
                    Client client = new Client(checkingAccount);                    
                    client.AddName(name);
                    client.AddCPF(cpf);
                    client.AddPassword(password);
                    confirm = true;
                    Client.Clients.Add(client);
                    client.AddTypeExtract("CheckingAccount");
                    ScreenCompleteRegistration();
                    ScreenLoginInAccount(client);
                }
                else if (optionConta == 2)
                {
                    // create account savings
                    SavingsAccount savingsAccount = new SavingsAccount();
                    Client client = new Client(savingsAccount);                   
                    client.AddName(name);
                    client.AddCPF(cpf);
                    client.AddPassword(password);
                    confirm = true;
                    Client.Clients.Add(client);
                    client.AddTypeExtract("SavingAccount");
                    ScreenCompleteRegistration();
                    ScreenLoginInAccount(client);
                }
                else if (optionConta == -1)
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("          OPÇÃO INVALIDA            ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);
                }
            }                   
        }

        public static void ScreenLoginInAccount(Client client)
        {
            int option = 0;
            bool confirm = false;
            bool showError = true;
            while (confirm == false)
            {
                showError = true;
                Console.Clear();
                ScreenPanelUser(client);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("        Digite a opção deseja       ");
                Console.WriteLine("====================================");
                Console.WriteLine("   1 - Depositar                    ");
                Console.WriteLine("====================================");
                Console.WriteLine("   2 - Saque                        ");
                Console.WriteLine("====================================");
                Console.WriteLine("   3 - Consultar Saldo              ");
                Console.WriteLine("====================================");
                Console.WriteLine("   4 - Extrato                      ");
                Console.WriteLine("====================================");
                Console.WriteLine("   5 - Sair                         ");
                Console.WriteLine("====================================");
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("          OPÇÃO INVALIDA            ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);
                    showError = false;
                }
                switch (option)
                {
                    case 1:
                        // Depositar
                        ScreenDeposit(client);
                        confirm = true;
                        break;
                    case 2:
                        // Saque
                        ScreenCashOut(client);
                        confirm = true;
                        break;
                    case 3:
                        // Consultar Saldo
                        ScreenConsultBalance(client);
                        confirm = true;
                        break;
                    case 4:
                        // Extrato
                        Console.Clear();
                        ScreenPanelUser(client);
                        Console.WriteLine();
                        Console.WriteLine();
                        client.Extract.Moviments();
                        ScreenContinueOrNot(client);
                        confirm = true;
                        break;
                    case 5:
                        // Voltar a tela principal
                        ScreenMain();
                        confirm = true;
                        break;
                    default:
                        if (showError == true)
                        {
                            Console.Clear();
                            Console.WriteLine("====================================");
                            Console.WriteLine("          OPÇÃO INVALIDA            ");
                            Console.WriteLine("====================================");
                            Thread.Sleep(1000);
                        }                       
                        break;
                }       
            }
        }

        public static void ScreenDeposit(Client client)
        {
            double balance = 0;
            bool confirm = false;

            while (confirm == false)
            {
                Console.Clear();
                ScreenPanelUser(client);
                Console.WriteLine();
                Console.WriteLine("       Digite o valor do Deposito      ");
                try
                {
                    balance = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("           OPÇÃO INVALIDA           ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);
                    Console.Clear();
                    ScreenContinueOrNot(client);
                }

                if (balance <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("        Deposito Incorreto          ");
                    Console.WriteLine("    O valor deve ser maior que 0    ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);
                    ScreenContinueOrNot(client);
                }
                else if (balance > 0)
                {
                    client.Account.Deposit(balance);
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("         Deposito realizado         ");
                    Console.WriteLine("====================================");
                    client.Extract.AddExtract("Deposito", balance);
                    Thread.Sleep(1000);
                    confirm = true;
                    Console.Clear();
                    ScreenContinueOrNot(client);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("        Deposito Incorreto!         ");
                    Console.WriteLine("====================================");        
                    ScreenContinueOrNot(client);
                }                
            }          
        }

        public static void ScreenCashOut(Client client)
        {
            bool confirm = false;       
            bool testCashOut = false;
            bool testValueNegative = false;
            double value = 0;

            while (confirm == false)
            {
                testCashOut = true;
                testValueNegative = true;
                Console.Clear();
                ScreenPanelUser(client);
                Console.WriteLine();
                Console.WriteLine("       Digite o valor do Saque      ");
                try
                {
                    value = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("           OPÇÃO INVALIDO           ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);                 
                    testValueNegative = false;
                    testCashOut = false;
                }

                if (testValueNegative == true)
                {
                    if (value <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("==========================================================");
                        Console.WriteLine("                     SAQUE INVALIDO                       ");
                        Console.WriteLine("    Não é possível efetuar saque baixo ou igual a zero    ");
                        Console.WriteLine("==========================================================");
                        Thread.Sleep(1000);
                        testCashOut = false;
                    }
                }
                
                if (testCashOut == true)
                {
                    bool test = client.Account.CashOut(value);

                    if (test == true)
                    {
                        Console.Clear();
                        Console.WriteLine("====================================");
                        Console.WriteLine("         Saque Realizado            ");
                        Console.WriteLine("====================================");
                        client.Extract.AddExtract("Saque", value);
                        Thread.Sleep(1000);
                        Console.Clear();
                        confirm = true;
                        ScreenContinueOrNot(client);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("====================================");
                        Console.WriteLine("        Saldo insuficiente          ");
                        Console.WriteLine("====================================");
                        Thread.Sleep(1000);
                        Console.Clear();
                        confirm = true;
                        ScreenContinueOrNot(client);
                    }
                }              
            }            
        }

        public static void ScreenConsultBalance(Client client)
        {
            Console.Clear();
            ScreenPanelUser(client);
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine($"    Seu Saldo é : {client.Account.ConsultBalance()}  ");
            Console.WriteLine("====================================");
            ScreenContinueOrNot(client);
        }

        public static void ScreenContinueOrNot(Client client)
        {
            int option = 0;
            int optionReturn = 0;
            bool confirm = false;
            while (confirm == false)
            {         
                Console.WriteLine();
                Console.WriteLine("        Digite a opção deseja       ");
                Console.WriteLine("====================================");
                Console.WriteLine("   1 - Voltar para minha Conta      ");
                Console.WriteLine("====================================");
                Console.WriteLine("   2 - Sair                         ");
                Console.WriteLine("====================================");
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("         OPÇÃO INVALIDA             ");
                    Console.WriteLine("====================================");            
                }
                if (option == 1)
                {
                    ScreenLoginInAccount(client);
                    confirm = true;
                }
                else if (option == 2)
                {
                    ScreenMain();
                    confirm = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("         OPÇÃO INVALIDA             ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);
                }
            }            
        }

        public static void ScreenPanelUser(Client client)
        {
            string apresent = $"Seja Bem vindo(a), {client.Name} | Banco : {client.Account.GetCodeBank()} " +
                $"| Agencia : {client.Account.GetCodeAgency()} | Conta : {client.Account.GetCodeAccount()}";
            
            Console.WriteLine(apresent);
        }

        public static void ScreenLoginInCPF()
        {
            double cpf = 0;
            string password = "";
            bool confirm = false;
            bool continueCpf = true;

            while (confirm == false)
            {
                Console.Clear();
                continueCpf = true;
                Console.WriteLine();
                Console.WriteLine("        Digite o seu CPF :         ");

                try
                {
                    cpf = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("            CPF INVALIDO            ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);
                    continueCpf = false;
                }
                if (continueCpf == true)
                {
                    Console.WriteLine("====================================");
                    Console.WriteLine("        Digite sua senha :          ");

                    password = Console.ReadLine();

                    int testClient = Client.CheckClient(cpf, password);

                    switch (testClient)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("====================================");
                            Console.WriteLine("          Senha Incorreta           ");
                            Console.WriteLine("====================================");
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("====================================");
                            Console.WriteLine("        Usuário Inexistente         ");
                            Console.WriteLine("====================================");
                            Thread.Sleep(1000);
                            ScreenMain();
                            confirm = true;
                            break;
                        default:
                            confirm = true;
                            break;
                    }
                }               
            }
        }

        public static int ScreenMainOrLoginInCpf()
        {
            int option = 0;
            bool confirm = false;
            int optionReturn = 0;
            while(confirm == false)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("        Digite a opção deseja       ");
                Console.WriteLine("====================================");
                Console.WriteLine("   1 - Entra com esse CPF           ");
                Console.WriteLine("====================================");
                Console.WriteLine("   2 - Voltar a tela principal      ");
                Console.WriteLine("====================================");
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("          OPÇÃO INVALIDA            ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);
                    ScreenMainOrLoginInCpf();                   
                }
                if (option == 1)
                {
                    optionReturn = 1;
                    confirm = true;
                }
                else if (option == 2)
                {
                    optionReturn = 2;
                    confirm = true;
                }
                else
                {
                    optionReturn = -1;
                    confirm = true;
                }                
            }
            return optionReturn;
        }

        public static int ScreenChooseAccount()
        {
            int option = 0;
            int optionReturn = 0;
            bool confirm = false;
            while (confirm == false)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("        Digite a opção deseja       ");
                Console.WriteLine("====================================");
                Console.WriteLine("   1 - Corrente                     ");
                Console.WriteLine("====================================");
                Console.WriteLine("   2 - Poupança                     ");
                Console.WriteLine("====================================");
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("          OPÇÃO INVALIDA            ");
                    Console.WriteLine("====================================");
                    Thread.Sleep(1000);
                    ScreenMainOrLoginInCpf();
                }
                if (option == 1)
                {
                    optionReturn = 1;
                    confirm = true;
                }
                else if (option == 2)
                {
                    optionReturn = 2;
                    confirm = true;
                }
                else
                {
                    optionReturn = -1;
                    confirm = true;
                }
            }
            return optionReturn;
        }

        public static void ScreenCompleteRegistration()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("    Conta cadastrada com sucesso    ");
            Console.WriteLine("====================================");
            Thread.Sleep(1000);
        }
    }
}
