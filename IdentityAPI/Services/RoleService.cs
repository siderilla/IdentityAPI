using Identity.Service;
using IdentityAPI.Model;
using IdentityAPI.Model.DTOs;
using IdentityAPI.Model.ViewModels;
using IdentityAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserContext _context;

        public RoleService(UserContext context)
        {
            _context = context;
        }


        public async Task<List<RoleViewModel>> GetRoles()
        {
            return await _context.Roles
                .Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Description = r.Description
                })
                .ToListAsync();
                
        }

        public async Task<RoleViewModel> GetRole(int id)
        {
            var entity = await _context.Roles.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            return new RoleViewModel
            {
                Id = entity.Id,
                Description = entity.Description
            };
        }

        public async Task<bool> UpdateRole(int id, RoleUpdateDTO role)
        {
            var entity = await _context.Roles.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(role.Description) && role.Description != entity.Description)
            {
                entity.Description = role.Description;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int?> PostRole(RoleCreateDTO role)
        {
            if (string.IsNullOrEmpty(role.Description))
            {
                return null;
            }
            var newRole = new Role
            {
                Description = role.Description
            };
            _context.Roles.Add(newRole);
            await _context.SaveChangesAsync();
            return newRole.Id;
        }

        public async Task<int?> DeleteRole(int id)
        {
            var entity = await _context.Roles.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            _context.Roles.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
