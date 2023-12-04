namespace Questao5.Domain.Entities
{
    public class ContaCorrente : Entity
    {
        public ContaCorrente(int numero, 
            string nome, 
            bool ativo)
        {
            Numero = numero;
            Nome = nome;
            Ativo = ativo;
        }

        public ContaCorrente()
        {
            
        }

        public int Numero { get; private set; }

        public string Nome { get; private set; }

        public bool Ativo { get; private set; }
    }
}
