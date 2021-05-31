using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackendReservas.Service.Models
{
    public class Cliente
    {

        public Cliente(int clienteId, string nome, string email, string senha, string telefone, int enderecoId)
        {
            ClienteId = clienteId;
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            EnderecoId = enderecoId;
        }

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }
        public string Telefone { get; set; }

        public int EnderecoId { get; set; }
        
        [JsonIgnore]
        public Endereco Endereco { get; set; }

        [JsonIgnore]
        public List<Avaliacao> Avaliacoes { get; set; }
        [JsonIgnore]
        public List<Fidelidade> Fidelidades { get; set; }
        [JsonIgnore]
        public List<Reserva> Reservas { get; set; }
    }
}