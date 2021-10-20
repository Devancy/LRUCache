namespace LRUCache.LUR
{
    /**
    * Interface for a simple LRU Cache. An LRU Cache is like a map/dictionary
    * that has a maximum size. If the number of entries in the map exceeds the
    * maximum size, then the Least Recently Used (LRU) entries in the map should
    * be removed. If any key within the map is ever touched, then it should be
    * marked as the most recently used (MRU) key; i.e. farthest from the LRU key.
    */
    interface ILRUCache<K, V>
    {
        /**
        * Retrieve the maximum number of entries the cache can store.
        */
        int GetMaxSize();
        /**
        * - Put the given value into the catch at a location identified by the key
        * - If a value previously existed at the location identified by the key,
        * return it, otherwise return null
        * - Mark the key as MRU (Most Recently Used)
        * - If the cache is full, evict the LRU (Least Recently Used) key from
        * the cache
        */
        V Put(K key, V value);
        /**
        * - Return the value stored at the location identified by the key
        * - Mark the key as MRU (Most Recently Used)
        */
        V Get(K key);
        /**
        * - Return the value stored at the location identified by the key
        * - Remove the key from the cache
        */
        V Remove(K key);
    }
}
