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

    }
}