using Identity.Service;
using IdentityAPI.Model;
using IdentityAPI.Model.DTOs;
using IdentityAPI.Model.ViewModels;
using IdentityAPI.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace IdentityAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly UserContext _context;

        public RequestService(UserContext context)
        {
            _context = context;
        }

        public async Task<List<RequestViewModel>> GetRequests()
        {
            return await _context.Requests
                .Select(r => new RequestViewModel
                {
                    Id = r.Id,
                    Text = r.Text,
                    Url = r.Url,
                    UserId = r.UserId
                })
                .ToListAsync();
        }

        public async Task<RequestViewModel> GetRequest(int id)
        {
            var entity = await _context.Requests.FindAsync(id);
            if (entity == null) return null;

            return new RequestViewModel
            {
                Id = entity.Id,
                Text = entity.Text,
                Url = entity.Url,
                UserId = entity.UserId
            };
        }


        public async Task<int> UpdateRequest(int id, RequestUpdateDTO request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null) return -1;

            var entity = await _context.Requests.FindAsync(id);
            if (entity == null) return -2;

            if (!string.IsNullOrEmpty(request.Text) && request.Text != entity.Text)
            {
                entity.Text = request.Text;
            }
            if (!string.IsNullOrEmpty(request.Url) && request.Url != entity.Url)
            {
                entity.Url = request.Url;
            }
            if (request.UserId.HasValue && request.UserId.Value != entity.UserId)
            {
                entity.UserId = request.UserId.Value;
            }

            _context.Requests.Update(entity);
            await _context.SaveChangesAsync();
            return 0;
        }

        public async Task<int?> PostRequest(RequestCreateDTO request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null) return null;

            if (request == null) return null;
            var entity = new Request
            {
                Text = request.Text,
                Url = request.Url,
                UserId = request.UserId
            };
            _context.Requests.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }


        public async Task<int?> DeleteRequest(int id)
        {
            var entity = await _context.Requests.FindAsync(id);
            if (entity == null) return null;

            _context.Requests.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
