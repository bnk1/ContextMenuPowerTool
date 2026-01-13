using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ContextMenuPowerTool
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection;
        private PropertyDescriptor? _sortProperty;

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => _isSorted;
        protected override PropertyDescriptor? SortPropertyCore => _sortProperty;
        protected override ListSortDirection SortDirectionCore => _sortDirection;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var items = (List<T>)Items;
            items.Sort((a, b) =>
            {
                object? va = prop.GetValue(a);
                object? vb = prop.GetValue(b);
                return direction == ListSortDirection.Ascending
                    ? Comparer.Default.Compare(va, vb)
                    : Comparer.Default.Compare(vb, va);
            });

            _sortProperty = prop;
            _sortDirection = direction;
            _isSorted = true;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            _isSorted = false;
            _sortProperty = null;
        }
    }
}