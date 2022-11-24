namespace main;


class QNode<T>
{
    public T? value { get; set; }
    public QNode<T>? next { get; set; }
}
public class Queue<T>
{
    public int length { get; private set; }
    private QNode<T>? head { get; set; }
    private QNode<T>? tail { get; set; }
    public Queue()
    {
        this.head = null;
        this.tail = null;
        this.length = 0;

    }

    public void enqeue(T item)
    {
        var node = new QNode<T> { value = item, next = null };
        this.length += 1;
        if (this.tail == null)
        {
            this.tail = node;
            this.head = node;
            return;
        }
        this.tail.next = node;
        this.tail = node;

    }
    public T? deque()
    {
        if (this.head == null)
        {
            return default;
        }
        this.length -= 1;
        var head = this.head;
        this.head = this.head.next;

        head.next = null;

        return head.value;
    }

    public T? peek()
    {
        if (this.head == null)
        {
            return default;
        }
        return this.head.value;
    }
}

class SNode<T>
{
    public T? value { get; set; }
    public SNode<T>? previous { get; set; }
}

public class Stack<T>
{
    public uint length { get; private set; }
    private SNode<T>? head { get; set; }


    public Stack()
    {
        this.head = null;
        this.length = 0;

    }

    public void push(T item)
    {
        var node = new SNode<T> { value = item, previous = null };
        this.length += 1;
        if (this.head == null)
        {
            this.head = node;
            return;

        }
        node.previous = this.head;
        this.head = node;

    }

    public T? pop()
    {
        this.length -= 1;
        if (this.head == null)
        {
            return default;
        }

        var head = this.head;
        this.head = head.previous;

        head.previous = null;

        return head.value;

    }

    public T? peek()
    {
        if (this.head == null)
        {
            return default;
        }
        return this.head.value;
    }

}

class Node<T>
{
    public T? value { get; set; }
    public Node<T>? previous { get; set; }
    public Node<T>? next { get; set; }
}

public class DoublyLinkedList<T>
{
    public uint length { get; private set; }
    private Node<T>? head { get; set; }
    private Node<T>? tail { get; set; }

    public DoublyLinkedList()
    {
        this.length = 0;
        this.head = null;
        this.tail = null;
    }

    public void prepend(T item)
    {
        var node = new Node<T> { value = item, previous = null, next = null };
        this.length += 1;
        if (this.head == null)
        {
            this.head = node;
            this.tail = node;
            return;
        }

        node.next = this.head;
        this.head.previous = node;
        this.head = node;

    }

    public void insertAt(T item, uint idx)
    {
        if (idx > this.length)
        {
            throw new Exception("Out of bounds");
        }


        if (idx == this.length)
        {
            this.append(item);
            return;
        }
        else if (idx == 0)
        {
            this.prepend(item);
            return;
        }

        this.length += 1;
        var current = this.getAt(idx);

        var node = new Node<T> { value = item, previous = null, next = null };

        node.next = current;
        node.previous = current?.previous;
        current!.previous = node;

        if (node.previous != null)
        {
            node.previous.next = current;
        }
    }

    public void append(T item)
    {
        this.length += 1;
        var node = new Node<T> { value = item, previous = null, next = null };
        if (this.tail == null)
        {
            this.head = node;
            this.tail = node;
            return;
        }

        node.previous = this.tail;
        this.tail!.next = node;

        this.tail = node;
    }

    public T? remove(T item)
    {
        var current = this.head;
        for (int i = 0; current != null && i < this.length; i++)
        {
            if (current.value!.Equals(item))
            {
                break;
            }
            current = current.next;
        }
        if (current == null)
        {
            return default;
        }

        return removeNode(current);
    }

    public T? get(uint idx)
    {
        return this.getAt(idx)!.value;

    }

    public T? removeAt(uint idx)
    {
        var node = this.getAt(idx);

        if (node == null)
        {
            return default;
        }
        return this.removeNode(node);

    }

    private T? removeNode(Node<T> node)
    {
        this.length -= 1;
        if (this.length == 0)
        {
            var temp = this.head!.value;
            this.head = null;
            this.tail = null;
            return temp;
        }

        if (node.previous != null)
        {
            node.previous.next = node.next;
        }
        if (node.next != null)
        {
            node.next.previous = node.previous;
        }

        if (node.Equals(this.head))
        {
            this.head = node.next;
        }
        if (node.Equals(this.tail))
        {
            this.tail = node.previous;
        }
        node.previous = null;
        node.next = null;
        return node.value;
    }

    private Node<T>? getAt(uint idx)
    {
        var current = this.head;
        for (int i = 0; current != null && i < idx; i++)
        {
            current = current.next;
        }
        return current;
    }

}

public class BinaryTree<T>
{
    public T? value { get; set; }
    public BinaryTree<T>? left { get; set; }
    public BinaryTree<T>? right { get; set; }
}

public class MinHeap
{
    public int length { get; private set; }
    private List<int> data { get; set; }


    public MinHeap()
    {
        this.data = new List<int>();
        this.length = 0;

    }

    public void insert(int value)
    {
        this.data.Add(value);
        this.heapifyUp(this.length);
        this.length += 1;
    }

    public int delete()
    {
        if (this.length == 0)
        {
            return -1;
        }

        var output = this.data[0];
        this.length -= 1;

        if (this.length == 0)
        {
            this.data = new List<int>();
            return output;
        }
        this.data[0] = this.data[this.length];
        this.heapifyDown(0);
        return output;
    }

    private void heapifyDown(int idx)
    {

        var lIdx = this.leftChild(idx);
        var rIdx = this.rightChild(idx);

        if (idx >= this.length || lIdx >= this.length)
        {
            return;
        }

        var lV = this.data[lIdx];
        var rV = this.data[rIdx];
        var v = this.data[idx];

        if (lV > rV && v > rV)
        {
            this.data[idx] = rV;
            this.data[rIdx] = v;
            this.heapifyDown(rIdx);
        }
        else if (rV > lV && v > lV)
        {
            this.data[idx] = lV;
            this.data[lIdx] = v;
            this.heapifyDown(lIdx);
        }
    }

    private void heapifyUp(int idx)
    {
        if (idx == 0)
        {
            return;
        }

        var p = this.parent(idx);
        var parentV = this.data[p];
        var v = this.data[idx];

        if (parentV > v)
        {
            this.data[idx] = parentV;
            this.data[p] = v;
            this.heapifyUp(p);

        }

    }

    private int parent(int idx)
    {
        return (idx - 1) / 2;
    }

    private int leftChild(int idx)
    {
        return idx * 2 + 1;
    }

    private int rightChild(int idx)
    {
        return idx * 2 + 2;
    }
}

public class GraphEdge
{
    public int to { get; set; }
    public int weight { get; set; }
}
