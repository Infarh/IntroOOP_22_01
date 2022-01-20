using System.Diagnostics;

namespace ToolsLib;

[DebuggerDisplay("RefList[items:{Count}]")]
public class RefList<T>
{
    [DebuggerDisplay("Node = {Value}")]
    public class Node
    {
        internal RefList<T>? _List;

        public T Value { get; set; }

        public Node? Next { get; set; }

        public Node? Prev { get; set; }

        internal Node(T value, RefList<T> List)
        {
            Value = value;
            _List = List;
        }
    }

    //public static async Task<RefList<T>> CreateAsync()
    //{
    //    await Task.Delay(100);

    //    var list = new RefList<T>();
    //    return list;
    //}

    //public static RefList<T> Create()
    //{
    //    var list = new RefList<T>();
    //    return list;
    //}

    private static RefList<T> __List;
    private static readonly object __SyncRoot = new();

    //public static RefList<T> List
    //{
    //    get
    //    {
    //        if (__List != null) return __List;
    //        __List = new();
    //        return __List;
    //    }
    //}

    public static RefList<T> List
    {
        get
        {
            if (__List != null) return __List;

            lock (__SyncRoot)
            {
                if (__List != null) return __List;
                __List = new();
                return __List;
            }
        }
    }

    private int _Count;

    public int Count => _Count;

    //public int Count { get; private set; }

    public Node? First { get; private set; }

    public Node? Last { get; set; }

    public RefList()
    {

    }

    public Node AddFirst(T value)
    {
        var node = new Node(value, this);
        _Count++;

        if (First is null)
        {
            First = node;
            Last = node;
            return node;
        }

        node.Next = First;
        First.Prev = node;
        First = node;

        return node;
    }

    public Node AddLast(T value)
    {
        var node = new Node(value, this);
        _Count++;

        if (Last is null)
        {
            First = node;
            Last = node;
            return node;
        }

        node.Prev = Last;
        Last.Next = node;
        Last = node;

        return node;
    }

    private bool CheckNode(Node node)
    {
        var n = First;
        while (n != null)
        {
            if (ReferenceEquals(n, node)) return true;
            n = n.Next;
        }

        return false;
    }

    public Node AddAfter(Node Position, T value)
    {
        if (!ReferenceEquals(this, Position._List))
            throw new InvalidOperationException("Попытка добавления значения после узла, не принадлежащего текущему списку");

        //if (!CheckNode(Position))
        //    throw new InvalidOperationException("Попытка добавления значения после узла, не принадлежащего текущему списку");

        if (ReferenceEquals(Position, Last))
            return AddLast(value);

        var node = new Node(value, this)
        {
            Prev = Position,
            Next = Position.Next
        };

        Position.Next = node;
        node.Next!.Prev = node;

        return node;
    }

    public Node AddBefore(Node Position, T value)
    {
        if (!ReferenceEquals(this, Position._List))
            throw new InvalidOperationException("Попытка добавления значения после узла, не принадлежащего текущему списку");

        if (ReferenceEquals(Position, First))
            return AddFirst(value);

        var node = new Node(value, this)
        {
            Next = Position,
            Prev = Position.Prev,
        };

        Position.Prev = node;
        node.Prev!.Next = node;

        return node;
    }

    public T Remove(Node node)
    {
        if (!ReferenceEquals(this, node._List))
            throw new InvalidOperationException("Попытка удаление узла, не принадлежащего текущему списку");

        node._List = null;

        if (_Count == 1)
        {
            First = null;
            Last = null;
        }
        else if (ReferenceEquals(First, node))
        {
            First = node.Next;
            First.Prev = null;
        }
        else if (ReferenceEquals(Last, node))
        {
            Last = node.Prev;
            Last.Next = null;
        }
        else
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }

        node.Next = null;
        node.Prev = null;

        _Count--;

        return node.Value;
    }

    public void Clear() // O(n)
    {
        if (_Count == 0) return;

        var node = First;
        while (node != null)
        {
            node._List = null;
            node.Prev = null;
            var tmp = node.Next;
            node.Next = null;

            node = tmp;
        }

        First = null;
        Last = null;
        _Count = 0;
    }
}
