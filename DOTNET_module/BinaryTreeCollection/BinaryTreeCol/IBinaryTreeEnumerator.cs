using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCol
{
    public interface IBinaryTreeEnumerator<T> where T: IComparable<T>
    {
        IEnumerable<T> GetEnumerator(Node<T> node);
    }
}
