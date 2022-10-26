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
