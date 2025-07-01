using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Cqs.Results
{
    public interface ICqsResult
    {
        public static ICqsResult Success()
        {
            return new CqsResult(true);
        }

        public static ICqsResult Failure(string errorMessage)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage);
            return new CqsResult(false, errorMessage);
        }

        public bool IsSuccess { get; }
        public bool IsFailure { get; }
        public string? ErrorMessage { get; }
    }

    public interface ICqsResult<TResult>
    {
        public static ICqsResult<TResult> Success(TResult data)
        {
            return new CqsResult<TResult>(true, data);
        }

        public static ICqsResult<TResult> Failure(string errorMessage)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage);
            return new CqsResult<TResult>(false, errorMessage:errorMessage);
        }

        public bool IsSuccess { get; }
        public bool IsFailure { get; }
        public string? ErrorMessage { get; }
        public TResult Data { get; }
    }
}
