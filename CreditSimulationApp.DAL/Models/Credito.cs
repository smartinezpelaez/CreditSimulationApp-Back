using System;
using System.Collections.Generic;

namespace CreditSimulationApp.DAL.Models;

public partial class Credito
{
    public int Id { get; set; }

    public decimal Monto { get; set; }

    public decimal TasaInteres { get; set; }

    public int PlazoMeses { get; set; }

    public DateTime FechaInicio { get; set; }

    public bool Pagado { get; set; }

    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
}
