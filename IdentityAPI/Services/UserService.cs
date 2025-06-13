using Identity.Service;
using Identity.Service.Model;
using IdentityAPI.Model.DTOs;
using IdentityAPI.Model.ViewModels;
using IdentityAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _context;

        public UserService(UserContext context)
        {
            _context = context;
        }

        public async Task<List<UserViewModel>> GetUsers()
        {
            return await _context.Users
                .Select(u => new UserViewModel
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email
                })
                .ToListAsync();
        }

        public async Task<UserViewModel> GetUser(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            return new UserViewModel
            {
                Name = entity.Name,
                Surname = entity.Surname,
                Email = entity.Email
            };
        }

        public async Task<bool> UpdateUser(int id, UserUpdateDTO user)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(user.Name) && user.Name != entity.Name)
            {
                entity.Name = user.Name;
            }
            if (!string.IsNullOrEmpty(user.Surname) && user.Surname != entity.Surname)
            {
                entity.Surname = user.Surname;
            }
            if (!string.IsNullOrEmpty(user.Email) && user.Email != entity.Email)
            {
                entity.Email = user.Email;
            }
            if (!string.IsNullOrEmpty(user.Password) && user.Password != entity.Password)
            {
                entity.Password = user.Password;
            }
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<int?> PostUser(UserCreateDTO user)
        {
            if (user == null
                    || string.IsNullOrEmpty(user.Name)
                    || string.IsNullOrEmpty(user.Surname)
                    || string.IsNullOrEmpty(user.Email)
                    || string.IsNullOrEmpty(user.Password)
                )
            {
                return null;
            }
            var entity = new User
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Password = user.Password
            };

            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int?> DeleteUser(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
