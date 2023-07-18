using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Models;

public partial class DepartmentsCompany 
{
    public int Id { get; set; }
    public Company Company { get; set; }
    public int CompanyId { get; set; }
    public Department Department { get; set; }
    public int DepartmentId { get; set; }
    public int NumberEmployees { get; set; }

}
