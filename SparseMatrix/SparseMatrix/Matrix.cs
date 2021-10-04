using System.Collections.Generic;

namespace SparseMatrix
{
    internal class Matrix
    {
        public Matrix()
        {

        }

        private readonly int _totalRowsNumber;
        private readonly int _totalColumnsNumber;

        public IList<Element> Elements { get; set; }
    }
}
