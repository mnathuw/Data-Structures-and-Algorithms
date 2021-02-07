using System;

namespace Assignment4
{
    public class Entry<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public Entry(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}