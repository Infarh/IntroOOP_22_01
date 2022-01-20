using ToolsLib;


namespace IntroOOP;

public static class Program
{
    public static void Main(string[] args)
    {
        RefList<string> strs_list = new RefList<string>();
        RefList<string> strs_list2 = new RefList<string>();

        var another_node = strs_list2.AddFirst("000");

        //var strs_node = new RefList<string>.Node();

        for (var i = 1; i < 10; i++)
        {
            strs_list.AddLast($"Value-{i}");
        }

        var position = strs_list.First.Next.Next;

        var node_123 = strs_list.AddAfter(position, "123");

        //strs_list.AddAfter(another_node, "321");


        var value_123 = strs_list.Remove(node_123);
        //strs_list2.AddLast(strs_list.Remove(node_123));


        strs_list.Clear();


        strs_list.AddLast("111");
        strs_list.AddLast("222");
        strs_list.AddLast("33");
        strs_list.AddLast("444");

        //strs_list.AddAfter(position, "555");

        Console.ReadLine();
    }
}