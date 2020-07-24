using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public ApiErrorResult(string messageError)
        {
            base.IsSuccesed = false;
            base.Message = messageError;
        }

        public ApiErrorResult()
        {
        }
    }
}