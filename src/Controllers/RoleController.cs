using PrimeSystems.Data;
using PrimeSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystems.Controllers
{
    public class RoleController
    {
        private readonly AppDbContext _context;

        public RoleController()
        {
            _context = new AppDbContext();
        }
        public List<RoleModel> GetAllRoles()
        {
            return _context.Roles.ToList();
        }
        public RoleModel? GetRoleByName(string roleName)
        {
            return _context.Roles.FirstOrDefault(r => r.Name == roleName);
        }
    }
}
