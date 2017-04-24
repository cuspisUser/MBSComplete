namespace NetAdvantage
{
    using System;
    using System.Collections;
    using System.Data;

    public class AttributeEnumeratorCollection : IEnumerator, IEnumerable
    {
        private int currentIdx;
        private DataColumnCollection list;

        public AttributeEnumeratorCollection(DataColumnCollection list)
        {
            this.list = list;
            this.currentIdx = -1;
        }

        public virtual IEnumerator GetEnumerator()
        {
            return this;
        }

        private static bool IsAttribute(DataColumn column)
        {
            if (column.DataType.Equals(typeof(byte[])))
            {
                return false;
            }
            if ((column.ColumnName.StartsWith("column") && column.DataType.Equals(typeof(string))) && ((column.Expression != null) && (column.Expression.Length != 0)))
            {
                return false;
            }
            return true;
        }

        public virtual bool MoveNext()
        {
            this.currentIdx++;
            while ((this.currentIdx < this.list.Count) && !IsAttribute(this.list[this.currentIdx]))
            {
                this.currentIdx++;
            }
            return (this.currentIdx < this.list.Count);
        }

        public virtual void Reset()
        {
            this.currentIdx = -1;
        }

        public virtual object Current
        {
            get
            {
                return this.list[this.currentIdx].ColumnName;
            }
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                return this.list[this.currentIdx].ColumnName;
            }
        }
    }
}

