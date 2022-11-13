using EmailSenderWebService.DTO;

namespace EmailSenderWebService.Data;

public interface IEmployeeRepository
{
    Task<IEnumerable<GetEmployeeDto>> GetEmployees(int groupId);
    public IQueryable<string> GetEmployeesEmailsByGroupId(int groupId);
}