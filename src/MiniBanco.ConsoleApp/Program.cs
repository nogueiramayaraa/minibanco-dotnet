using MiniBanco.ConsoleApp.Exceptions;
using MiniBanco.ConsoleApp.Models;

List<Conta> contas = new List<Conta>();
bool menuAtivo = true;

while (menuAtivo)
{
    Console.WriteLine();
    Console.WriteLine("========== MENU ==========");
    Console.WriteLine("1 - Abrir Nova Conta");
    Console.WriteLine("2 - Registrar Movimentação");
    Console.WriteLine("3 - Aplicar Fechamento Mensal");
    Console.WriteLine("4 - Exibir Relatório das Contas");
    Console.WriteLine("0 - Sair");

    string opcaoescolhida = Console.ReadLine();

    switch (opcaoescolhida)
    {
        case "1":
            Console.WriteLine("Tipo de Conta: 1 - Conta Corrente | 2 - Conta Poupança | 3 - Conta Salário");
            string tipoconta = Console.ReadLine();

            Console.Write("Titular: ");
            string titular = Console.ReadLine();

            Console.Write("Numero: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Saldo inicial: ");
            decimal saldo = decimal.Parse(Console.ReadLine());

            if (tipoconta == "1")
            {
                Console.Write("Limite Cheque Especial: ");
                decimal limiteChequeEspecial = decimal.Parse(Console.ReadLine());

                contas.Add(new ContaCorrente(titular, numero, saldo, limiteChequeEspecial));
                Console.WriteLine("Conta Cadastrada!");
            }

            else if (tipoconta == "2")
            {
                Console.Write("Taxa de Rendimento Mensal (%): ");
                double rendimento = double.Parse(Console.ReadLine());
                Console.Write("Dia do Aniversário: ");
                int diaAniversario = int.Parse(Console.ReadLine());

                contas.Add(new ContaPoupanca(titular, numero, saldo, rendimento, diaAniversario));
                Console.WriteLine("Conta Poupança Cadastrada!");

            }



            else if (tipoconta == "3")
            {
                Console.Write("Empregador: ");
                string empregador = Console.ReadLine();
                Console.Write("Limite de Saques Mensais: ");
                int limiteSaquesMensais = int.Parse(Console.ReadLine());

                contas.Add(new ContaSalario(titular, numero, saldo, empregador, limiteSaquesMensais));
                Console.WriteLine("Conta Salário Cadastrada!");
            }

            else
            {
                Console.WriteLine("Tipo de Conta Inválido. Digite somente as opções apresentadas no Menu");
            }
            break;

        case "2":


            Console.Write("Número da Conta: ");
            int buscanumero = int.Parse(Console.ReadLine());

            Conta encontrada = null;

            foreach (Conta c in contas)
            {
                if (c.Numero == buscanumero)
                {
                    encontrada = c;
                }
            }

            if (encontrada == null)
            {
                Console.WriteLine("Número da Conta não encontrada.");
            }
            else

            {
                Console.WriteLine("Operação: 1 - Depositar | 2 - Sacar ");
                string operacao = Console.ReadLine();

                Console.Write("Valor: ");
                decimal valor = decimal.Parse(Console.ReadLine());

                if (operacao == "1")
                {
                    Console.Write("Descrição do Depósito: ");
                    string descricao = Console.ReadLine();

                    encontrada.Depositar(valor, descricao);
                    Console.WriteLine("Depósito efetuado com sucesso!");
                }

                else if (operacao == "2")
                {
                    encontrada.Sacar(valor);
                    Console.WriteLine("Saque efetuado com sucesso!");

                }

                else
                {
                    Console.WriteLine("Operação Inválida.");
                }
            }



            break;


        case "3":
            Console.WriteLine("Em construção...");
            break;
        case "4":
            Console.WriteLine("Em construção...");
            break;
        case "0":
            menuAtivo = false;
            Console.WriteLine("Encerrando...");
            break;
        default:
            Console.WriteLine("Opção Inválida.");
            break;
    }

}

