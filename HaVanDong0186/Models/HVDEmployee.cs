using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaVanDong0186.Models
{
public class HVDEmployee
{
    [Key]
    public int? EmployeeID { get; set; }
    public string? EmployeeName { get; set; }
    public DateTime? NgaySinh { get; set; }

 }
}
