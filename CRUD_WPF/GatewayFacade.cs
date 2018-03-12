using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BE;
using SearchFiles;

namespace CRUD_WPF
{
    public class GatewayFacade
    {
        DepartmentServiceGateway depServiceGateway = new DepartmentServiceGateway();
        public async Task<List<Department>> GetAllDepartments()
        {
            List<Department> list = null;
            await Task.Run(() => { list = depServiceGateway.GetAllDepartments(); }
            );
            return list;
        }
        //TODO
        //Return type needs to be changed to department
        public async Task<Department> GetDepartment(int departmentNumber)
        {
            Department department = null;
            await Task.Run(() => { department = depServiceGateway.GetDepartment(departmentNumber); }
            );
            return department;
        }

        public async Task<bool> UpdateDepartment(Department updateDepartment)
        {
            bool response = false;
            await Task.Run(() => { response = depServiceGateway.UpdateDepartment(updateDepartment); }
            );
            return response;
        }

        public async Task<bool> CreateDepartment(Department newDepartment)
        {
            bool response = false;
            await Task.Run(() => { response = depServiceGateway.CreateDepartment(newDepartment); }
            );
            return response;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            bool response = false;
            await Task.Run(() => { response = depServiceGateway.DeleteDepartment(id); }
            );
            return response;
        }
    }
}
