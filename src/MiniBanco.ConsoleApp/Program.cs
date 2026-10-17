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
            Console.WriteLine("Em construção...");
            break;
        case "2":
            Console.WriteLine("Em construção...");
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

