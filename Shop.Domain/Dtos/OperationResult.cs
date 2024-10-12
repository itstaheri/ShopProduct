using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos
{
    public class OperationResult
    {
        public OperationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class OperationResult<T> : OperationResult
    {
        public OperationResult(T? result,bool success, string message) : base(success, message)
        {
            Result = result;
        }

        public T? Result { get; set; }
    }
}
