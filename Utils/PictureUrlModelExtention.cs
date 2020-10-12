using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Utils
{
    public class PictureUrlModelExtention : IEqualityComparer<PictureUrlModel>
    {
        public bool Equals([AllowNull] PictureUrlModel x, [AllowNull] PictureUrlModel y)
        {
            if (string.Equals(x.PhotoId, y.PhotoId, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] PictureUrlModel obj)
        {
            return obj.PhotoId.GetHashCode();
        }
    }
}
