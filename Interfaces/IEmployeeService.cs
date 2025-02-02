using NikePro.Data;
namespace NikePro.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task EditEmployee(Employee employee);
        Task DeleteEmployee(Employee employee);
        Task AddEmployee(ApplicationUser user);
    }
}
