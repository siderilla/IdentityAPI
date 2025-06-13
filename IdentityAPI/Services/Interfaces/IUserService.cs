using Identity.Service.Model;
using IdentityAPI.Model.DTOs;
using IdentityAPI.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetUsers();
        Task<UserViewModel> GetUser(int id);
        Task<bool> UpdateUser(int id, UserUpdateDTO user);
        Task<int?> PostUser(UserCreateDTO user);
        Task<int?> DeleteUser(int id);
    }
}
