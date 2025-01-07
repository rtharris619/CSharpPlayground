using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.FSharpForFun
{
    public class FSharpForFun
    {
        public static int SumOfSquares(int n)
        {
            return Enumerable.Range(1, n).Select(i => i * i).Sum();
        }        
    }

    public static class QuickSortExtension
    {
        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> values) where T : IComparable
        {
            if (values == null || !values.Any())
            {
                return new List<T>();
            }

            var firstElement = values.First();
            var rest = values.Skip(1);

            var smallerElements = rest.Where(x => x.CompareTo(firstElement) < 0).QuickSort();

            var largerElements = rest.Where(x => x.CompareTo(firstElement) >= 0).QuickSort();

            return smallerElements.Concat(new List<T> { firstElement}).Concat(largerElements);
        }

        public static void Driver()
        {
            var sortedList = new List<int>() { 1, 5, 23, 18, 9, 1, 3 }.QuickSort();
            foreach (var value in sortedList)
            {
                Console.Write(value + " ");
            }
        }
    }

    public class WebPageDownloader
    {
        public TResult FetchUrl<TResult>(string url, Func<string, StreamReader, TResult> callback)
        {
            var req = WebRequest.Create(url);
            using (var resp = req.GetResponse())
            {
                using (var stream = resp.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        return callback(url, reader);
                    }
                }
            }
        }

        public void Driver()
        {
            Func<string, StreamReader, string> myCallback = (url, reader) =>
            {
                var html = reader.ReadToEnd();
                var html1000 = html.Substring(0, 1000);
                Console.WriteLine("Downloaded {0}. First 1000 is {1}", url, html1000);
                return html1000;
            };

            var downloader = new WebPageDownloader();
            var google = downloader.FetchUrl("http://google.com", myCallback);

            var sites = new List<string>
            {
                "http://www.bing.com",
                "http://www.google.com",
                "http://www.yahoo.com"
            };

            sites.ForEach(site => downloader.FetchUrl(site, myCallback));
        }
    }

    public static class ExtractBoilerPlate
    {
        public static int ProductWithAggregate(int n)
        {
            var initialValue = 1;
            Func<int, int, int> action = (productSoFar, x) => productSoFar * x;
            return Enumerable.Range(1, n).Aggregate(initialValue, action);
        }

        public static int SumOfOddsWithAggregate(int n)
        {
            var initialValue = 0;
            Func<int, int, int> action = (sumSoFar, x) => (x % 2 == 0) ? sumSoFar : sumSoFar + x;
            return Enumerable.Range(1, n).Aggregate(initialValue, action);
        }

        public static int AlternatingSumsWithAggregate(int n)
        {
            var initialValue = Tuple.Create(true, 0);
            Func<Tuple<bool, int>, int, Tuple<bool, int>> action = (t, x) => 
                t.Item1 ? Tuple.Create(false, t.Item2 - x) 
                        : Tuple.Create(true, t.Item2 + x);
            return Enumerable.Range(1, n).Aggregate(initialValue, action).Item2;
        }

        public class NameAndSize
        {
            public string Name;
            public int Size;
        }

        public static NameAndSize MaxNameAndSize(IList<NameAndSize> list)
        {
            if (!list.Any())
            {
                return default(NameAndSize);
            }

            var initialValue = list[0];
            Func<NameAndSize, NameAndSize, NameAndSize> action =
                (maxSoFar, x) => x.Size > maxSoFar.Size ? x : maxSoFar;
            return list.Aggregate(initialValue, action);
        }

        public static void Driver()
        {

        }
    }

    public static class FSharpForFunDriver
    {
        public static void Driver()
        {
            QuickSortExtension.Driver();
        }
    }
}
