using System.ComponentModel.DataAnnotations;

namespace EmailSenderWebService.Models;

public class EmployeeGroup
{
    [Key]
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int GroupId { get; set; } 
    public Employee? Employee { get; set; }
    public Group? Group { get; set; }
}