using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.ViewModels.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T result)
        {
            IsSuccesed = true;
            ResultObj = result;
        }

        public ApiSuccessResult()
        {
            IsSuccesed = true;
        }
    }
}