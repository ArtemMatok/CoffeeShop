using Coffee.BaseResponse;
using Coffee.ViewModels;
using System.Security.Claims;

namespace Coffee.Service
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
    }
}
