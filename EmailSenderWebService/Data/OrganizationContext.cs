using EmailSenderWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderWebService.Data;

public class OrganizationContext : DbContext
{
    public OrganizationContext(DbContextOptions<OrganizationContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Group> Groups { get; set; } 
    public DbSet<EmployeeGroup> EmployeeGroups { get; set; }
}