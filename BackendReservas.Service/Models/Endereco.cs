namespace BackendReservas.Service.Models
{
    public class Endereco
    {
        public Endereco(int enderecoId, string rua, int numero, string bairro, string cidade, string uf, string pais, string cep)
        {
            EnderecoId = enderecoId;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Pais = pais;
            Cep = cep;
        }

        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
    }
}