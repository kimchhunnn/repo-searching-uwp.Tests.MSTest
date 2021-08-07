using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using repo_searching_uwp.Model;

namespace repo_searching_uwp.Tests.MSTest.Inheritance
{
    class ExtendedResult: Result
    {
        public override bool Equals(object obj)
        {
            if (!(obj is Result))
                return false;

            var other = obj as Result;

            if (TotalCount != other.TotalCount)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            int hashTotalCount = TotalCount == 0 ? 0 : TotalCount.GetHashCode();

            return hashTotalCount;
        }
    }
}
