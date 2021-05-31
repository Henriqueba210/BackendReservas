using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackendReservas.Service.Models
{
    public class Estabelecimento
    {
        public Estabelecimento(int estabelecimentoId, string email, string cnpj, string senha, string telefone, string lotacao, DateTime horaAbertura, string descricao, int enderecoId)
        {
            EstabelecimentoId = estabelecimentoId;
            Email = email;
            Cnpj = cnpj;
            Senha = senha;
            Telefone = telefone;
            Lotacao = lotacao;
            HoraAbertura = horaAbertura;
            Descricao = descricao;
            EnderecoId = enderecoId;
        }

        public int EstabelecimentoId { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Lotacao { get; set; }
        public DateTime HoraAbertura { get; set; }
        public string Descricao { get; set; }

        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        [JsonIgnore]
        public List<Avaliacao> Avaliacoes { get; set; }
        [JsonIgnore]
        public List<Fidelidade> Fidelidades { get; set; }
        [JsonIgnore]
        public List<Reserva> Reservas { get; set; }
    }
}