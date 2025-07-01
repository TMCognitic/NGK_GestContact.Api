using NGK_GestContact.Api.Domain.Commands;
using NGK_GestContact.Api.Domain.Entities;
using NGK_GestContact.Api.Domain.Queries;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace NGK_GestContact.Api.Domain.Repositories
{
    public interface IContactRepository :
        IAsyncQueryHandler<GetContactByIdQuery, Contact>,
        IAsyncCommandHandler<CreateContactCommand>
    {
    }
}
