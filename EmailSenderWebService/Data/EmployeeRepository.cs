using EmailSenderWebService.DTO;
using EmailSenderWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderWebService.Data;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly OrganizationContext _organizationContext;

    public EmployeeRepository(OrganizationContext organizationContext)
    {
        _organizationContext = organizationContext;
    }
    
    public async Task<IEnumerable<GetEmployeeDto>> GetEmployees(int groupId)
    {
        return await _organizationContext.Set<EmployeeGroup>()
            .Include(x => x.Employee)
            .Where(x => x.GroupId == groupId)
            .Select(x => new GetEmployeeDto
            {
                FullName = x.Employee!.FullName ?? string.Empty,
                Email = x.Employee!.Email ?? string.Empty
            })
            .ToListAsync();
    }

    public IQueryable<string> GetEmployeesEmailsByGroupId(int groupId)
    {
        var managementEmployees = _organizationContext.Set<Employee>()
            .Include(x => x.EmployeeGroups)
            .Where(x => x.EmployeeGroups.GroupId == groupId);

        var result = _organizationContext.Set<Employee>()
            .Where(x => !managementEmployees.Any(y => y.Id == x.Id))
            .Select(x => x.Email);
        
        return result;
    }
}