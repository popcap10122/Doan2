using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.ViewModels.Common
{
    public class ApiResult<T>
    {
        public bool IsSuccesed { get; set; }
        public string Message { get; set; }
        public T ResultObj { get; set; }
    }
}