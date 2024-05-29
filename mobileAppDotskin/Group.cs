using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace mobileAppDotskin
{
    public class Group<K, T> : ObservableCollection<T>
    {
        public K Nimetus { get; private set; }
        public Group(K nimetus, IEnumerable<T> items)
        {
            Nimetus = nimetus;
            foreach (T item in items)
                Items.Add(item);
        }

    }


}