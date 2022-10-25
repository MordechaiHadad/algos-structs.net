namespace main;


class Node<T>
{
    public T? value { get; set; }
    public Node<T>? next { get; set; }
}
public class Queue<T>
{
    public int length { get; private set; }
    private Node<T>? head { get; set; }
    private Node<T>? tail { get; set; }
    public Queue()
    {
        this.head = null;
        this.tail = null;
        this.length = 0;

    }

    public void enqeue(T item)
    {
        var node = new Node<T> { value = item, next = null };
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
