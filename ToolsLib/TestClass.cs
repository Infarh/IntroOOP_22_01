namespace ToolsLib;

public class TestClass
{
    public static void Test()
    {
        var strs = new RefList<string>();

        var node = strs.AddFirst("123"); 


        //var strs = RefList<string>.Create();

        //var strs = RefList<string>.List;

        //var strs_node = new RefList<string>.Node();

        //strs.First = null;
        //strs.Last = null;
    }
}