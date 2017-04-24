namespace NetAdvantage
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.CompilerServices;

    public class AttributeKeyEnumeratorCollection : IEnumerator, IEnumerable
    {
        private int currentIdx;
        private DataColumnCollection list;

        public AttributeKeyEnumeratorCollection(DataColumnCollection list)
        {
            this.list = list;
            this.currentIdx = -1;
        }

        public virtual IEnumerator GetEnumerator()
        {
            return this;
        }

        private static bool IsKey(DataColumn column)
        {
            return ((column.ExtendedProperties["IsKey"] != null) && Convert.ToBoolean(RuntimeHelpers.GetObjectValue(column.ExtendedProperties["IsKey"])));
        }

        public virtual bool MoveNext()
        {
            this.currentIdx++;
            while ((this.currentIdx < this.list.Count) && !IsKey(this.list[this.currentIdx]))
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

