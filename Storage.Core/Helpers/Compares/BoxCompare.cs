using Core.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Storage.Core.Helpers.Compares
{
    public class BoxCompare : IEqualityComparer<Box>
    {
        public bool Equals(Box? x, Box? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Box obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
