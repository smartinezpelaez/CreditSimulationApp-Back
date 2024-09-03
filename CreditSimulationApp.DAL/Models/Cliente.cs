using System;
using System.Collections.Generic;

namespace CreditSimulationApp.DAL.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();
}
