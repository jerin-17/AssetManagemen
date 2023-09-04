using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole
{
    public class DepartmentFromConsole : IInputProvider<Department>
    {
        public Department GetInput()
        {
            Console.Write("Enter the department Name:");
            string departmentName = Console.ReadLine();
            if(departmentName == null)
            {
                throw new ArgumentNullException("Department name cannot be null");
            }

            return new Department
            {
                DepartmentName = departmentName
            };
        }
    }
}
