namespace CreditSimulationApp.BLL.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public string Email { get; set; } = null!;
        public IEnumerable<CreditoDTO> Creditos { get; set; }
    }
}
