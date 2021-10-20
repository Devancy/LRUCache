namespace LRUCache.LUR
{
    public class DoubleLinkedList<K, V>
    {
        private Node<K, V> Root { get; set; }
        public int Length { get; private set; }

        public DoubleLinkedList()
        {
            this.Root = new Node<K, V>();
            this.Length = 0;
            this.Root.Next = this.Root;
            this.Root.Previous = this.Root;
        }

        /// <summary>
        /// Adds a new node to the top of the double-linked list
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node<K, V> MoveFront(Node<K, V> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Previous != null && node.Next != null)
            {
                this.InternalIsolate(node); // removes the node if it's already in the list
            }

            var oldHead = this.Root.Next;

            // points the node to the root and the old head node
            node.Previous = this.Root;
            node.Next = oldHead;

            // updates the root node and the old head so they point to the new head
            oldHead.Previous = node;
            this.Root.Next = node;

            return node;
        }

        /// <summary>
        /// Inserts a value at the front or head of the list.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node<K, V> Unshift(Node<K, V> node)
        {
            this.MoveFront(node);
            this.Length++;

            return node;
        }

        /// <summary>
        /// Removes a node from the list.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node<K, V> Remove(Node<K, V> node)
        {
            if (this.Length == 0)
                return null;

            var removedNode = this.InternalIsolate(node);
            this.Length--;

            return removedNode;
        }

        /// <summary>
        /// Removes the least recently used node.
        /// </summary>
        /// <returns></returns>
        public Node<K, V> RemoveTail()
        {
            return this.Remove(this.Root.Previous);
        }

        /// <summary>
        /// Removes the node from the double-linked list.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node<K, V> InternalIsolate(Node<K, V> node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            node.Next = null;
            node.Previous = null;

            return node;
        }

        /// <summary>
        /// Flattens the collection.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "[";
            var node = this.Root.Next;
            while (!node.IsRoot)
            {
                result += $"{{{node.Key}-{node.Value}}}, ";
                node = node.Next;
            }

            return result.TrimEnd(',', ' ') + "]";
        }
    }
}
