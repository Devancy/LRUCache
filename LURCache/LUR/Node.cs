namespace LRUCache.LUR
{
    public class Node<K, V>
    {
        public readonly bool IsRoot;
        public K Key { get; set; }
        public V Value { get; set; }
        public Node<K, V> Next { get; set; }
        public Node<K, V> Previous { get; set; }

        public Node()
        {
            IsRoot = true;
        }

        public Node(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }        
    }
}
