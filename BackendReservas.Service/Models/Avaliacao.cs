using System.Text.Json.Serialization;

namespace BackendReservas.Service.Models
{
    public class Avaliacao
    {

        public Avaliacao(int avaliacaoId, int avaliacaoAtendimento, string descricao, int clienteId, int establelecimentoId)
        {
            AvaliacaoId = avaliacaoId;
            AvaliacaoAtendimento = avaliacaoAtendimento;
            Descricao = descricao;
            ClienteId = clienteId;
            EstablelecimentoId = establelecimentoId;
        }

        public int AvaliacaoId { get; set; }
        public int AvaliacaoAtendimento { get; set; }
        public string Descricao { get; set; }

        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }
        public int EstablelecimentoId { get; set; }
        [JsonIgnore]
        public Estabelecimento Estabelelecimento { get; set; }
    }
}