using MiniBanco.ConsoleApp.Exceptions;

namespace MiniBanco.ConsoleApp.Models

{
    //herdando a classe Conta
    public class ContaPoupanca : Conta
    {
        public double TaxaRendimentoMensal { get; }
        public int DiaAniversario { get; }
        public ContaPoupanca(string titular, int numero, decimal saldo, double taxaRendimentoMensal, int diaAniversario)
        : base(titular, numero, saldo)

        {
            this.TaxaRendimentoMensal = taxaRendimentoMensal;
            this.DiaAniversario = diaAniversario;
        }


        public override void AplicarFechamentoMensal()
        {
            decimal rendimento = Saldo * (decimal)TaxaRendimentoMensal / 100;
            if(rendimento > 0)
            {
               Depositar(rendimento, "Rendimento mensal"); 
            }
            
        }

    }
}
