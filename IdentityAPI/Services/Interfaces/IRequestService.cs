
using IdentityAPI.Model.DTOs;
using IdentityAPI.Model.ViewModels;

namespace IdentityAPI.Services.Interfaces
{
    public interface IRequestService
    {
        Task<List<RequestViewModel>> GetRequests();
        Task<RequestViewModel> GetRequest(int id);
        Task<int> UpdateRequest(int id, RequestUpdateDTO request);
        Task<int?> PostRequest(RequestCreateDTO request);
        Task<int?> DeleteRequest(int id);

    }
}
