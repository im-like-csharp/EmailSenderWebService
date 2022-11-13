using System.ComponentModel.DataAnnotations;

namespace EmailSenderWebService.Models;

public class Group
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}