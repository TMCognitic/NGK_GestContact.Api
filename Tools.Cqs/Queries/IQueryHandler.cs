using Tools.Cqs.Results;

namespace Tools.Cqs.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        ICqsResult<TResult> Execute(TQuery query);
    }
}
