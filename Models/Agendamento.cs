namespace WebAPIArenaCactus.Models
{
    public class Agendamento
    {
        public int idAgendamento { get; set; }
        public DateTime? Data { get; set; }
        public int idCredenciado { get; set; }
        public int idCliente { get; set; }
        public int idQuadra { get; set; }
    }
}
