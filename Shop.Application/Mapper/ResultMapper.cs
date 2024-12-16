using Shop.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Mapper
{
    public static class ResultMapper
    {
        public static ResponseDto Success(this OperationResult result)
        {
            return new ResponseDto
            {
                Message = result.Message,
                Result = null,
                StatusCode = 200
            };
        }
        public static ResponseDto Error(this OperationResult result)
        {
            return new ResponseDto
            {
                Message = result.Message,
                Result = null,
                StatusCode = 500
            };
        }
        public static ResponseDto Error<T>(this OperationResult<T> result)
        {
            return new ResponseDto
            {
                Message = result.Message,
                Result = result.Result,
                StatusCode = 500
            };
        }
        public static ResponseDto Success<T>(this OperationResult<T> result)
        {
            return new ResponseDto
            {
                Message = result.Message,
                Result = result.Result,
                StatusCode = 200
            };
        }
        public static ResponseDto BadRequest<T>(this OperationResult<T> result)
        {
            return new ResponseDto
            {
                Message = result.Message,
                Result = result.Result,
                StatusCode = 200
            };
        }
        public static ResponseDto BadRequest(this OperationResult result)
        {
            return new ResponseDto
            {
                Message = result.Message,
                Result = null,
                StatusCode = 200
            };
        }
    }
}
