using Doan.ViewModels.Common;
using Doan.ViewModels.Systems.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Doan.Application.Systems.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<bool>> RegisterCus(RegisterRequestCustomer request);

        Task<ApiResult<bool>> RegisterSup(RegisterRequestSupplier request);
    }
}