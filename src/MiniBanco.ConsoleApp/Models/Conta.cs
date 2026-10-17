using MiniBanco.ConsoleApp.Exceptions;

namespace MiniBanco.ConsoleApp.Models

{
    //criando a classe conta 
    public abstract class Conta
    {
        public string Titular { get; }
        public int Numero { get; }
        public decimal Saldo { get; protected set; }
        public List<Transacao> Extrato { get; }

        public Conta(string titular, int numero, decimal saldo)
        {
            this.Titular = titular;
            this.Numero = numero;
            this.Saldo = saldo;
            this.Extrato = new List<Transacao>();
        }

        public void RegistrarTransacao(string descricao, string tipo, decimal valor)
        {
            Extrato.Add(new Transacao(descricao, tipo, valor));
        }

        //transacao(descricao,tipo,valor)
        public virtual void Sacar(decimal valor)
        {
            if (valor > Saldo)
            {
                throw new SaldoInsuficienteException("Não há saldo suficiente para saque.");
            }

            RegistrarTransacao("Saque", "Saque", valor);
            Saldo = Saldo - valor;

        }

        public void Depositar(decimal valor, string descricao)
        {
            RegistrarTransacao(descricao, "Deposito", valor);
            Saldo = Saldo + valor;

        }


        public virtual void AplicarFechamentoMensal() { }

    }
}
