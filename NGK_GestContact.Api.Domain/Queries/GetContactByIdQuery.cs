using NGK_GestContact.Api.Domain.Entities;
using Tools.Cqs.Queries;

namespace NGK_GestContact.Api.Domain.Queries
{
    public class GetContactByIdQuery : IQueryDefinition<Contact>
    {
        public int Id { get; }

        public GetContactByIdQuery(int id)
        {
            Id = id;
        }
    }
}
