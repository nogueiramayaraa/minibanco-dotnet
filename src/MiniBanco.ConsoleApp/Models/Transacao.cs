namespace MiniBanco.ConsoleApp.Models
{

    public class Transacao
    {
        public string Descricao { get; }
        public string Tipo { get; }
        public decimal Valor { get; }

        public Transacao(string Descricao, string Tipo, decimal Valor)
        {
            if (Tipo != "Saque" && Tipo != "Deposito" && Tipo != "Tarifa")
                throw new ArgumentException("Tipo de transação inválida.");
            if (Valor <= 0)
                throw new ArgumentException("Valor precisa ser maior que 0.");

            this.Tipo = Tipo;
            this.Valor = Valor;
            this.Descricao = Descricao;
        }
    }

}


