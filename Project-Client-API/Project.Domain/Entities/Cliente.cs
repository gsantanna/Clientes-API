using System;

namespace Project.Domain.Entities
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }

        public Cliente() { }

        public Cliente(long id, string nome, string cpf, int idade, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
            DataNascimento = dataNascimento;
        }
    }
}
