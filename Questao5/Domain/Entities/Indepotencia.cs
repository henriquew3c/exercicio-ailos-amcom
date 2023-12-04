namespace Questao5.Domain.Entities
{
    public class Indepotencia : Entity
    {
        public Indepotencia(string chave, string requisicao, string resultado)
        {
            Chave = chave;
            Requisicao = requisicao;
            Resultado = resultado;
        }

        public Indepotencia()
        {
            
        }

        public string Chave { get; private set; }

        public string Requisicao { get; private set; }

        public string Resultado { get; private set; }
    }
}
