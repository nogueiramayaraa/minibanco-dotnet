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


    }
}