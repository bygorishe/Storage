using Core.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Storage.Core.Helpers.Compares
{
    public class PalletCompare : IEqualityComparer<Pallet>
    {
        public bool Equals(Pallet? x, Pallet? y)
        {
            if (x.Boxes is not null && x.Boxes.Count > 0)
                if (!x.Boxes.SequenceEqual(y.Boxes, new BoxCompare()))
                    return false;
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Pallet obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
