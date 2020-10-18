namespace Project.Domain.Entities
{
    public class Endereco
    {
        public long Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Endereco()
        {

        }

        public Endereco(long id, string logradouro, string bairro, string cidade, string estado)
        {
            Id = id;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
