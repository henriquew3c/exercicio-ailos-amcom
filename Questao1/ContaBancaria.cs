using System.Globalization;
using System;

namespace Questao1
{
    public class ContaBancaria {

        public ContaBancaria(int numero, string nomeTitular, double valorDepositoInicial = 0)
        {
            this.NumeroConta = numero;
            this.NomeTitular = nomeTitular;

            if (valorDepositoInicial > 0)
                Depositar(valorDepositoInicial);
        }

        public void AlterarNomeTitular(string nomeTitular)
        {
            if (string.IsNullOrEmpty(nomeTitular))
                throw new ArgumentException("O campo Nome do Titular é inválido.");

            this.NomeTitular = nomeTitular;
        }

        public void Depositar(double valor)
        {
            if (valor < 0) 
                return;

            this.Saldo += valor;
        }

        public void Sacar(double valor)
        {
            if (valor < 0)
                return;

            this.Saldo -= valor;
            this.Saldo -= Taxa.Saque;
        }

        public string ImprimeExtrato()
        {
            return $"Conta: {this.NumeroConta}, Titular: {this.NomeTitular}, Saldo: $ {this.Saldo.ToString("N2", NumberFormatInfo.InvariantInfo)}";
        }

        public int NumeroConta { get; private set; }

        public string NomeTitular { get; private set; }

        public double Saldo { get; private set; }
    }
}
