using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGK_GestContact.Api.Domain.Extensions
{
    internal static class EnumerableAsync
    {
        internal static async Task<TResult?> SingleOrDefaultAsync<TResult>(this IAsyncEnumerable<TResult> source)         
        {
            TResult? result = default;
            bool found = false;

            await foreach (var item in source)
            {
                if (found)
                {
                    throw new InvalidOperationException("Sequence contains more than one matching element.");
                }
                result = item;
                found = true;
            }

            return found ? result : default;
        }
    }
}
