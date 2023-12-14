using Getri_API_Dapper.Models;

namespace Getri_API_Dapper.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeId(int empId);

        List<Employee> GetAllEmployees();

        int AddEmployee(Employee employee);

        int UpdateEmployee(Employee employee);

        int DeleteEmployee(int empId);
    }
}
