using System;
using System.Collections.Generic;
using System.Text;

namespace FastSharp.Core
{
    public interface ICache<K,V>
    {
        V Get(K key);

        V Put(K key, V value);

        V Remove(K key);

        void Clear();

        int Size();

        IList<K> Keys();

        IList<V> Values();
    }
}
