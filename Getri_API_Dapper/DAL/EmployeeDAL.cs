using Dapper;
using Getri_API_Dapper.Models;
using Getri_API_Dapper.Repository;
using System.Data;
using System.Data.SqlClient;

namespace Getri_API_Dapper.DAL
{
    public class EmployeeDAL : IEmployeeRepository
    {
        private readonly IConfiguration configuration;

        public IDbConnection connection 
        {
            get 
            {
                return new SqlConnection(configuration.GetConnectionString("EmployeeDapperConnection"));
            }
        }

        public EmployeeDAL(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public int AddEmployee(Employee employee)
        {
            int rowAffected = 0;
            using(IDbConnection con = connection)
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@EmpName", employee.EmpName);
                param.Add("@EmpAge", employee.EmpAge);
                param.Add("@EmpGender", employee.EmpGender);
                param.Add("@EmpAddress", employee.EmpAddress);
                param.Add("@EmpContactNo", employee.EmpContactNo);
                rowAffected = con.Execute("AddNewEmpDetails", param, commandType: CommandType.StoredProcedure);
                con.Close();                
            }

            return rowAffected;
        }

        public int DeleteEmployee(int empId)
        {
            int rowAffected = 0;
            using (IDbConnection con = connection)
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@EmpId", empId);
                rowAffected = con.Execute("DeleteEmpDetails", param, commandType: CommandType.StoredProcedure);
                con.Close();
            }

            return rowAffected;
        }

        public List<Employee> GetAllEmployees()
        {
            using(IDbConnection con = connection)
            {
                string query = "SELECT * FROM Employee";
                con.Open();
                var result = con.Query<Employee>(query);
                //con.Close();
                return result.ToList<Employee>();
            }
        }

        public Employee GetEmployeeId(int empId)
        {
            using(IDbConnection con = connection)
            {
                string query = "SELECT * FROM Employee WHERE EmpId = @EmpId";
                con.Open();
                var result = con.QueryFirst<Employee>(query, new { EmpId = empId });
                //con.Close();
                return result;
            }
        }

        public int UpdateEmployee(Employee employee)
        {
            int rowAffected = 0;
            using (IDbConnection con = connection)
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@EmpId", employee.EmpId);
                param.Add("@EmpName", employee.EmpName);
                param.Add("@EmpAge", employee.EmpAge);
                param.Add("@EmpGender", employee.EmpGender);
                param.Add("@EmpAddress", employee.EmpAddress);
                param.Add("@EmpContactNo", employee.EmpContactNo);
                rowAffected = con.Execute("UpdateNewEmpDetails", param, commandType: CommandType.StoredProcedure);
                con.Close();
            }

            return rowAffected;
        }
    }
}
