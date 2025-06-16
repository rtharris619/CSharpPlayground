namespace CSharpPlayground.Advanced;

class IteratorBlocksImpl
{
    static IEnumerable<int> Squares(IEnumerable<int> source)
    {
        foreach (var item in source)
            yield return item * item;
    }

    static IEnumerable<int> FilterMin(IEnumerable<int> source, int min)
    {
        foreach (var item in source)
            if (item > min)
                yield return item;
    }

    public static void Driver()
    {
        var items = Enumerable.Range(1, 10);

        foreach (var item in Squares(FilterMin(items, 8)))
        {
            Console.WriteLine(item);
        }
    }
}

public class IteratorBlocks
{
    public static void Driver()
    {
        IteratorBlocksImpl.Driver();
    }
}
