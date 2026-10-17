using MiniBanco.ConsoleApp.Exceptions;

namespace MiniBanco.ConsoleApp.Models

{
   
    public class ContaSalario : Conta
    {
        public string Empregador { get; }
        public int LimiteSaquesMensais { get; }

        private int ContadorSaques;  
        public ContaSalario(string titular, int numero, decimal saldo, string empregador, int limiteSaquesMensais)
        : base(titular, numero, saldo)

        {
            this.Empregador = empregador;
            this.LimiteSaquesMensais = limiteSaquesMensais;
        }


        public override void Sacar(decimal valor)
        {
            base.Sacar(valor);
            ContadorSaques = ContadorSaques + 1;
            if (ContadorSaques > LimiteSaquesMensais)
            {
                RegistrarTransacao("Tarifa Excesso de Saques", "Tarifa", 5m);
                Saldo = Saldo - 5m;
            }

        }

        public override void AplicarFechamentoMensal()
        {

            ContadorSaques = 0;
             }


    }

}

