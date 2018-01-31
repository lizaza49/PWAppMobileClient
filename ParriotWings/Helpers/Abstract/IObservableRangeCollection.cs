using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ParriotWings.Helpers.Abstract
{
    public interface IObservableRangeCollection<T> : INotifyCollectionChanged, IList<T>
    {
        void AddRange(IEnumerable<T> collection);
        void AddRangeToBeginning(IEnumerable<T> collection);
        void RemoveRange(IEnumerable<T> collection);
        void Replace(T item);
        void ReplaceRange(IEnumerable<T> collection);
    }
}
