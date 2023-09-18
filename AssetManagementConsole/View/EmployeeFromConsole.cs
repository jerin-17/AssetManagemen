using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole
{
    public class EmployeeFromConsole : IInputProvider<List<EmployeeDTO>>
    {
        private readonly IDepartmentManager _departmentManager;

        public EmployeeFromConsole(IDepartmentManager departmentManager)
        {
            this._departmentManager = departmentManager;
        }

        private void iterateDepartments(List<Department> departments)
        {
            foreach(var department in departments) {
                Console.WriteLine($"{department.DepartmentId}\t{department.DepartmentName}");
            }
        }

        public List<EmployeeDTO> GetInput()
        {
            Console.Write("Enter the number of Employees:");
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            int.TryParse(Console.ReadLine(), out int employeeCount);
            for (int i = 0; i < employeeCount; ++i)
            {

                Console.WriteLine("1. Select Department");
                Console.WriteLine("2. Create Department");
                Console.Write("Option: ");
                int.TryParse(Console.ReadLine(), out int deptChoice);
                int deptId = -1;
                if (deptChoice == 1)
                {
                    iterateDepartments(_departmentManager.GetDepartments());
                    Console.Write("Select DepartmentId:");
                    int.TryParse(Console.ReadLine(), out deptId);
                }
                else if (deptChoice == 2)
                {
                    try
                    {
                        deptId = _departmentManager.CreateDepartment();

                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    return this.GetInput();
                }

                Console.Write("Enter the employeeName:");
                string employeeName = Console.ReadLine();
                if (employeeName == null)
                {
                    throw new ArgumentNullException("EMployee Name cannot be null");
                }
                var employee =  new EmployeeDTO
                {
                    EmployeeName = employeeName,
                    DepartmentId = deptId
                };
                employees.Add(employee);
            }
            return employees;
        }
    }
}
