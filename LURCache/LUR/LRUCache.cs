using System;
using System.Collections.Generic;

namespace LRUCache.LUR
{
    public class LRUCache<K, V> : ILRUCache<K, V>
    {
        private readonly int MaxSize = 0;
        private readonly DoubleLinkedList<K, V> List = new DoubleLinkedList<K, V>();
        private readonly Dictionary<K, Node<K, V>> Map = new Dictionary<K, Node<K, V>>();

        public LRUCache(int maxSize)
        {
            if (maxSize <= 0)
                throw new ArgumentException("Max size must be greater than zero");

            this.MaxSize = maxSize;
        }

        /// <summary>
        /// Returns the value stored at the location identified by the key.
        /// Marks the key as Most Recently Used.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            if (!this.Map.ContainsKey(key))
            {
                return default(V);
            }

            var node = this.Map[key];
            this.List.MoveFront(node);

            return node.Value;
        }

        /// <summary>
        /// Puts the given value into the catch at a location identified by the key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public V Put(K key, V value)
        {
            // If a value previously existed at the location identified by the key, return it
            if (this.Map.ContainsKey(key))
            {
                var node = this.Map[key];
                node.Value = value;
                this.List.MoveFront(node);

                return value;
            }
            else // otherwise return null
            {
                //  If the cache is full, evict the LRU (Least Recently Used) key from the cache
                if (this.List.Length == this.MaxSize)
                {
                    var expireNode = this.List.RemoveTail();
                    this.Map.Remove(expireNode.Key);
                }

                var newNode = new Node<K, V>(key, value);
                this.List.Unshift(newNode);
                this.Map.Add(key, newNode);

                return default(V);
            }
        }

        /// <summary>
        /// Removes the key from the cache and retrieves its value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Remove(K key)
        {
            if (!this.Map.ContainsKey(key))
            {
                return default(V);
            }

            var node = this.Map[key];
            this.List.Remove(node);
            this.Map.Remove(key);

            return node.Value;
        }

        /// <summary>
        /// Retrieves the maximum number of entries the cache can store.
        /// </summary>
        /// <returns></returns>
        public int GetMaxSize()
        {
            return this.MaxSize;
        }

        /// <summary>
        /// Gets the inner collection in a readable string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.List.ToString();
        }
    }
}
