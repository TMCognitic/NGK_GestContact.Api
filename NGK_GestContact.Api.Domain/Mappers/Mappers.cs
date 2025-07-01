using NGK_GestContact.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGK_GestContact.Api.Domain.Mappers
{
    internal static class Mappers
    {
        internal static Contact ToContact(this IDataRecord record)
        {
            return new Contact((int)record["Id"], (string)record["Nom"], (string)record["Prenom"], record["Email"] as string, record["Tel"] as string);
        }
    }
}
