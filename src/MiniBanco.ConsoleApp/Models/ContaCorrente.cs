using MiniBanco.ConsoleApp.Exceptions;

namespace MiniBanco.ConsoleApp.Models

{
    //herdando a classe Conta
    public class ContaCorrente : Conta
    {
        public decimal LimiteChequeEspecial { get; }
        public ContaCorrente(string titular, int numero, decimal saldo, decimal limiteChequeEspecial)
        : base(titular, numero, saldo)

        {
            this.LimiteChequeEspecial = limiteChequeEspecial;
        }


        public override void Sacar(decimal valor)
        {
            if (valor > Saldo + LimiteChequeEspecial)
            {
                throw new SaldoInsuficienteException("Valor insuficiente para saque, considerando também o Limite de Cheque Especial");
            }

            RegistrarTransacao("Saque", "Saque", valor);
            Saldo = Saldo - valor;
        }


        public override void AplicarFechamentoMensal()
        {

            RegistrarTransacao("Tarifa de manutenção", "Tarifa", 10m);
            Saldo = Saldo - 10m;
        }

    }
}
