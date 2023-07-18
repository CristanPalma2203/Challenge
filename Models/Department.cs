using System;
using System.Collections.Generic;

namespace Prueba.Models;

public partial class Department
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LevelOrganization { get; set; }

    public ICollection<DepartmentsCompany> DepartmentsCompany { get; set; }

}
