using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
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
        public OperationResult(bool success, OperationMessageResult operationCode)
        {
            Success = success;
            OperationCode = operationCode;
            Message = GetEnumbDisplay(operationCode);
        }
        public OperationResult(bool success, OperationMessageResult operationCode,string customMessage)
        {
            Success = success;
            OperationCode = operationCode;
            Message = customMessage;
        }
        public OperationMessageResult OperationCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        protected string GetEnumbDisplay(OperationMessageResult en) => en.GetType()
                        .GetMember(en.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()
                        .GetName();
    }
    public class OperationResult<T> : OperationResult
    {
        public OperationResult(T? result, bool success, string message) : base(success, message)
        {
            Result = result;
        }
        public OperationResult(T? result,bool success, OperationMessageResult operationCode) : base(success,operationCode)
        {
            Result = result;
        }
        public OperationResult(T? result,bool success, OperationMessageResult operationCode, string customMessage) : base(success,operationCode,customMessage) 
        {
            Result = result;
        }

        public T? Result { get; set; }
    }



}

