namespace NetAdvantage
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.CompilerServices;

    public class AttributeAllKeysEnumeratorCollection : IEnumerator, IEnumerable
    {
        private int currentIdx;
        private int currentTable;
        private DataColumnCollection list;
        private DataTableCollection tables;

        public AttributeAllKeysEnumeratorCollection(DataTableCollection tables)
        {
            this.tables = tables;
            this.currentTable = -1;
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
            if (this.currentTable == -1)
            {
                this.currentTable++;
                if (this.tables.Count <= this.currentTable)
                {
                    return false;
                }
                this.list = this.tables[this.currentTable].Columns;
            }
            if (this.MoveNextInList())
            {
                return true;
            }
            this.currentTable++;
            if (this.tables.Count > this.currentTable)
            {
                this.list = this.tables[this.currentTable].Columns;
                this.currentIdx = -1;
                return this.MoveNext();
            }
            return false;
        }

        private bool MoveNextInList()
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
            this.currentTable = -1;
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

