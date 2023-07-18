using System;
using System.Collections.Generic;

namespace Prueba.Models;

public partial class Company
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? BusinessName { get; set; }
    public DateTime? RegisterDate { get; set; }
    public ICollection<Binnacle> Binnacles { get; set; }
    public ICollection<DepartmentsCompany> DepartmentsCompany { get; set; }
}
