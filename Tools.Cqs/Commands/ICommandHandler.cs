using Tools.Cqs.Results;

namespace Tools.Cqs.Commands
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        ICqsResult Execute(TCommand command);
    }
}
