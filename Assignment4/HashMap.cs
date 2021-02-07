using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Assignment4
{
    public class HashMap<K, V> : Map<K, V>
    {
        public int initialCapacity;
        private double loadFactor;
        private int threshold;
        private int size;

        public Entry<K, V>[] Table { get; set; }
        private const int DEFAULT_CAPACTIY = 11;
        private const double DEFAULT_LOADFACTOR = 0.75;

        public HashMap(int initialCapacity, double loadFactor)
        {
            if (initialCapacity <= 0 || loadFactor <= 0 || loadFactor > 1)
            {
                throw new ArgumentException();
            }

            this.initialCapacity = initialCapacity;
            this.Table = new Entry<K, V>[initialCapacity];
            this.loadFactor = loadFactor;
        }

        public HashMap()
        {
            this.initialCapacity = DEFAULT_CAPACTIY;
            this.loadFactor = DEFAULT_LOADFACTOR;
        }

        public HashMap(int intialCapacity)
        {
            if(intialCapacity <= 0)
            {
                throw new ArgumentException();
            }

            this.initialCapacity = intialCapacity;
            this.loadFactor = DEFAULT_LOADFACTOR;
        }


        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Clear()
        {
            for (int i = 0; i < this.Table.Length; i++)
            {
                this.Table[i] = null;
            }
            this.size = 0;
            this.threshold = 0;
        }

        public int GetMatchingOrNextAvailableBucket(K key)
        {
            int startingPoint = key.GetHashCode() % this.initialCapacity;
            for (int i = 0; i < this.Table.Length; i++)
            {
                int index = i + startingPoint;
                if (index >= this.Table.Length)
                {
                    index = index % this.initialCapacity;
                }
                if (this.Table[index] == null || this.Table[index].Key.Equals(key))
                {
                    return index;
                }
            }
            throw new ApplicationException();
        }


        public V Get(K key)
        {
            int index = this.GetMatchingOrNextAvailableBucket(key);
            if (Table[index] == null)
            {
                return default;
            }
            return Table[index].Value;
        }

        public V Put(K key, V value)
        {
            if (key == null || value == null)
            {
                throw new ArgumentNullException();
            }


            //V oldValue = default;

            int bucket = GetMatchingOrNextAvailableBucket(key);
            int threshold = (int)(this.initialCapacity * this.loadFactor);
            if (this.size + this.threshold == threshold - 1)
            {
                ReHash();
            }
            if (Table[bucket] == null)
            {
                Entry<K, V> newEntry = new Entry<K, V>(key, value);
                this.Table[bucket] = newEntry;
                this.size++;
                return default;
            }
            else
            {
                V oldValue = this.Table[bucket].Value;
                if (oldValue == null)
                {
                    this.threshold--;
                }
                this.Table[bucket].Value = value;
                return oldValue;
            }
        }

        public V Remove(K Key)
        {
            if (Key == null)
            {
                throw new System.ArgumentNullException();
            }
            int bucket = GetMatchingOrNextAvailableBucket(Key);
            if (Table[bucket] != null)
            {
                V removedValue = Table[bucket].Value;
                if(removedValue!= null)
                {
                    Table[bucket] = new Entry<K, V>(Key, default);
                    size--;
                    threshold++;
                }
                return removedValue;
            }
            else
            {
                return default;
            }
        }

        private int ReSize()
        {
            int newSize = (Table.Length * 2) + 1;
            bool primeFound = false;
            bool evenlyDivisible = false;

            while (!primeFound)
            {
                for (int i = 3; i <= (int)Math.Sqrt(newSize); i++)
                {
                    if (newSize % i == 0)
                    {
                        evenlyDivisible = true;
                    }
                }

                if (evenlyDivisible == false)
                {
                    primeFound = true;
                }
                else
                {
                    evenlyDivisible = false;
                    newSize += 2;
                }
            }
            return newSize;
        }

        private void ReHash() 
        {
            int threshold = (int)(this.initialCapacity * this.loadFactor);
            Entry<K, V>[] existEntries = new Entry<K, V>[threshold - 1];

            Entry<K, V>[] oldTable = Table;
            int initialCapacity = this.ReSize();
            Table = new Entry<K,V>[this.initialCapacity];
            this.Clear();
            int index = 0;
            for (int i = 0; i < this.Table.Length; i++)
            {
                if (this.Table[i] != null)
                {
                    existEntries[index] = this.Table[i];
                    index++;
                }
            }

            for (int i = 0; i < existEntries.Length; i++)
            {
                if (existEntries[i].Value != null)
                {
                    this.Put(existEntries[i].Key, existEntries[i].Value);
                }
            }
        }

        public IEnumerator<K> Keys()
        {
            List<K> keyList = new List<K>();
            for (int i = 0; i < Table.Length; i++)
            {
                if (Table[i] != null && Table[i].Value != null)
                {
                    keyList.Add(Table[i].Key);
                }
            }
            IEnumerator<K> itr = keyList.GetEnumerator();

            return itr;
        }

        public IEnumerator<V> Values()
        {
            List<V> valueList = new List<V>();
            for (int i = 0; i < Table.Length; i++)
            {
                if (Table[i] != null && Table[i].Value != null)
                {
                    valueList.Add(Table[i].Value);
                }
            }

            IEnumerator<V> itr = valueList.GetEnumerator();
            return itr;

        }
    }
}
