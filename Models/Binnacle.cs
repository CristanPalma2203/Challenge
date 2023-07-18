using System;
using System.Collections.Generic;

namespace Prueba.Models;

public partial class Binnacle
{
    public int Id { get; set; }
    public string? Details { get; set; }
    public Company Company { get; set; }
    public int CompanyId { get; set; }

    public DateTime dateTime { get; set; }
}
