namespace CreditSimulationApp.BLL.DTOs
{
    public class CreditoDTO
    {
        public int Id { get; set; }

        public decimal Monto { get; set; }

        public decimal TasaInteres { get; set; }

        public int PlazoMeses { get; set; }

        public DateTime FechaInicio { get; set; }

        public bool Pagado { get; set; }

        public int ClienteId { get; set; }

    }
}
