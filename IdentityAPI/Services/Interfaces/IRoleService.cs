
using IdentityAPI.Model;
using IdentityAPI.Model.DTOs;
using IdentityAPI.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAPI.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleViewModel>> GetRoles();
        Task<RoleViewModel> GetRole(int id);
        Task<bool> UpdateRole(int id, RoleUpdateDTO role);
        Task<int?> PostRole(RoleCreateDTO role);
        Task<int?> DeleteRole(int id);

    }
}
