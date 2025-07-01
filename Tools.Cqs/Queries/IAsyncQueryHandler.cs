using Tools.Cqs.Results;

namespace Tools.Cqs.Queries
{
    public interface IAsyncQueryHandler<TQuery, TResult>
    {
        Task<ICqsResult<TResult>> ExecuteAsync(TQuery query);
    }
}
