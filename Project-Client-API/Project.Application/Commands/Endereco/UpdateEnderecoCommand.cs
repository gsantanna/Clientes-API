namespace Project.Application.Commands.Endereco
{
    public class UpdateEnderecoCommand
    {
        public long Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
