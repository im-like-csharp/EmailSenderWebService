﻿using System.ComponentModel.DataAnnotations;

namespace EmailSenderWebService.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public EmployeeGroup? EmployeeGroups { get; set; }
}