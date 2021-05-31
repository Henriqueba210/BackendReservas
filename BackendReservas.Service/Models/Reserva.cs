using System;
using System.Text.Json.Serialization;

namespace BackendReservas.Service.Models
{
    public class Reserva
    {
        public Reserva(int reservaId, int status, double valor, DateTime dataReserva, DateTime horaInicio, DateTime horaFim, int qtdPessoas, int clienteId, int establelecimentoId)
        {
            ReservaId = reservaId;
            this.status = status;
            this.valor = valor;
            this.dataReserva = dataReserva;
            this.horaInicio = horaInicio;
            this.horaFim = horaFim;
            this.qtdPessoas = qtdPessoas;
            ClienteId = clienteId;
            EstablelecimentoId = establelecimentoId;
        }

        public int ReservaId { get; set; }
        public int status { get; set; }
        public double valor { get; set; }
        public DateTime dataReserva { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFim { get; set; }
        public int qtdPessoas { get; set; }

        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }
        public int EstablelecimentoId { get; set; }
        [JsonIgnore]
        public Estabelecimento Estabelelecimento { get; set; }
    }
}