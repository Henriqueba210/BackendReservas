using System.Text.Json.Serialization;

namespace BackendReservas.Service.Models
{
    public class Fidelidade
    {
        public Fidelidade(int fidelidadeId, int quantidadeReservas, int quantidadeCancelamentos, int clienteId, int establelecimentoId)
        {
            FidelidadeId = fidelidadeId;
            this.quantidadeReservas = quantidadeReservas;
            this.quantidadeCancelamentos = quantidadeCancelamentos;
            ClienteId = clienteId;
            EstablelecimentoId = establelecimentoId;
        }

        public int FidelidadeId { get; set; }
        public int quantidadeReservas { get; set; }
        public int quantidadeCancelamentos { get; set; }

        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }
        public int EstablelecimentoId { get; set; }
        [JsonIgnore]
        public Estabelecimento Estabelelecimento { get; set; }
    }
}