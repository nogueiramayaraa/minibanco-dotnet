using MiniBanco.ConsoleApp.Models;

namespace MiniBanco.ConsoleApp.Services

{
    public class MotorAnalise
    {
        public int AnalisarExtrato(Conta conta)
        {
            int pontos = 0;

            foreach (Transacao t in conta.Extrato)
            {
                if (t.Tipo == "Deposito")
                {
                    pontos = pontos + 10;
                }
                else if (t.Tipo == "Saque")
                {
                    pontos = pontos + 5;
                }

            }



            return pontos;
        }

        public double CalcularIndiceSaude(Conta conta)
        {
            int maximo = conta.Extrato.Count * 10;

            if (maximo == 0)
            {
                return 0;
            }
            int obtidos = AnalisarExtrato(conta);
            return (double)obtidos / maximo * 100;
        }


        public string ClassificarConta(double percentual)
        {
            if (percentual >= 90)
            {
                return "Conta Saudável";
            }
            else if (percentual >= 60)
            {
                return "Conta em Atenção";
            }
            else
            {
                return "Conta em Risco";
            }

        }

        public void ExibirRelatorio(Conta conta)
        {//dados da conta
            Console.WriteLine("> DADOS DA CONTA:");

            if (conta is ContaCorrente cc)
            {
                Console.WriteLine(" - Tipo: Conta Corrente");
                Console.WriteLine(" - Atributo: Limite Cheque Especial: " + "R$ " + cc.LimiteChequeEspecial.ToString("F2"));
            }
            else if (conta is ContaPoupanca cp)
            {
                Console.WriteLine(" - Tipo: Conta Poupança");
                Console.WriteLine(" - Atributo: Rendimento: " + cp.TaxaRendimentoMensal + "% ao mês" + " | " + "Aniversário: dia " + cp.DiaAniversario);
            }

            else if (conta is ContaSalario cs)
            {
                Console.WriteLine(" - Tipo: Conta Salário");
                Console.WriteLine(" - Atributo: Empregador: " + cs.Empregador + " | Limite de Saques Mensais: " + cs.LimiteSaquesMensais);
            }

            Console.WriteLine(" - Titular: " + conta.Titular + " | " + "Conta: " + conta.Numero);
            Console.WriteLine(" - Saldo Atual: R$ " + conta.Saldo.ToString("F2"));

            //dados de movimentações

            Console.WriteLine();
            Console.WriteLine("> MOVIMENTAÇÕES REGISTRADAS (" + conta.Extrato.Count + " TRANSAÇÕES):");

            foreach (Transacao t in conta.Extrato)
            {
                string status = "";
                int pontos = 0;

                if (t.Tipo == "Deposito")
                {
                    status = "[OK]";
                    pontos = 10;
                }
                else if (t.Tipo == "Saque")
                {
                    status = "[ ! ]";
                    pontos = 5;
                }

                else if (t.Tipo == "Tarifa")
                {
                    status = "[ X ]";
                    pontos = 0;
                }
                Console.WriteLine(" " + status + " " + t.Descricao.PadRight(30, '-') + " " + t.Tipo + ": R$ " + t.Valor.ToString("F2") + " (" + pontos + " pts)");


            }



            Console.WriteLine();
            Console.WriteLine("> RESUMO DA PONTUAÇÃO:");

            int pontosobtidos = AnalisarExtrato(conta);
            int pontuacaomaxima = conta.Extrato.Count * 10;
            double saudedaconta = CalcularIndiceSaude(conta);
            string classificacao = ClassificarConta(saudedaconta);

            Console.WriteLine("  - Pontuação Atingida: " + pontosobtidos + " de " + pontuacaomaxima + " pontos possíveis");
            Console.WriteLine("  - Índice de Saúde: " + saudedaconta.ToString("F1") + "%");
            Console.WriteLine("  - Classificação Final: [ " + classificacao.ToUpper() + " ]");



        }


    }
}