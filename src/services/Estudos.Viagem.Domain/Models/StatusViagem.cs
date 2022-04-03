using System.ComponentModel;

namespace Estudos.Viagem.Domain.Models
{
    public enum StatusViagem
    {
        [Description("Em análise")]
        EmAnalise = 1,
        Agendada = 2,
        [Description("Hotel Reservado")]
        HotelReservado = 3,
        [Description("Carro Reservado")]
        CarroReservado = 4,
        Realizada = 5,
        Cancelada = 6
    }
}