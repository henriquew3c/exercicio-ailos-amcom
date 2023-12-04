namespace Questao5.Api.DTO
{
    public class SaldoContaCorrenteResponse
    {
        public SaldoContaCorrenteResponse(Guid identificacaoContaCorrente,
            string nomeTitular,
            double valorSaldoAtual,
            DateTime dataHoraResposta)
        {
            this.IdentificacaoContaCorrente = identificacaoContaCorrente;
            this.NomeTitular = nomeTitular;
            this.DataHoraResposta = dataHoraResposta;
            this.ValorSaldoAtual = valorSaldoAtual;
        }

        public Guid IdentificacaoContaCorrente { get; set; }

        public string NomeTitular { get; set; }

        public DateTime DataHoraResposta { get; set; }

        public double ValorSaldoAtual { get; set; }
    }
}
